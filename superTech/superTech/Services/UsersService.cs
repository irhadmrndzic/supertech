using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Models.User;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class UsersService:BaseCRUDService<UserModel, UserSearchRequest, User, UserUpsertRequest, UserUpsertRequest>
    {
        public UsersService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<UserModel> Get(UserSearchRequest searchFilter)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchFilter.FirstName) &&
                !string.IsNullOrWhiteSpace((searchFilter.LastName)))
            {
                query = _dbContext.Users.Where(x => x.FirstName.ToLower().StartsWith(searchFilter.FirstName.ToLower())).Where(q=>q.LastName.ToLower().StartsWith(searchFilter.LastName.ToLower()));
            }

            if(!string.IsNullOrWhiteSpace(searchFilter.FirstName) && string.IsNullOrWhiteSpace(searchFilter.LastName))
            {
                query = _dbContext.Users.Where(x => x.FirstName.ToLower().StartsWith(searchFilter.FirstName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(searchFilter.LastName) && string.IsNullOrWhiteSpace(searchFilter.FirstName))
            {
                query = _dbContext.Users.Where(x => x.LastName.ToLower().StartsWith(searchFilter.LastName.ToLower()));
            }

            query = query.Include(x => x.FkCity).Include(q=>q.UsersRoles).ThenInclude(r=>r.FkRole);

            var list = query.ToList();

            return _mapper.Map<List<UserModel>>(list);
        }

        public override UserModel GetById(int id)
        {
            var entity = _dbContext.Users.Where(x => x.UserId == id)
                .Include(ur => ur.UsersRoles)
                .ThenInclude(r => r.FkRole)
                .Include(q => q.FkCity).SingleOrDefault();

            return _mapper.Map<UserModel>(entity);
        }

        public override UserModel Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<User>(request);

            entity.RegistrationDate = DateTime.Parse(request.DateOfRegistration);

            entity.DateOfBirth = DateTime.Parse(request.DateOfBirth);

            entity.PasswordHash = "test";
            entity.PasswordSalt = "test";

            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            entity.FkCityId = request.CityId;
            _dbContext.SaveChanges();

            foreach (var role in request.Roles)
            {
                _dbContext.UsersRoles.Add(new UsersRole()
                {
                    DateOfModification = DateTime.Now,
                    FkUserId = entity.UserId,
                    FkRoleId = role
                });
            }
            _dbContext.SaveChanges();


            var query = _dbContext.Users.Where(x => x.UserId == entity.UserId).Include(q => q.UsersRoles)
                .ThenInclude(r => r.FkRole).Include(c=>c.FkCity).SingleOrDefault();

            return _mapper.Map<UserModel>(query);
        }

        public override UserModel Update(int id, UserUpsertRequest request)
        {
            var entity = _dbContext.Users.Find(id);
            entity.DateOfBirth = DateTime.Parse(request.DateOfBirth);

            entity.RegistrationDate = DateTime.Parse(request.DateOfRegistration);


            _mapper.Map(request, entity);
            _dbContext.SaveChanges();


            foreach (var role in request.Roles)
            {
                if (role == 0)
                    break;

                if (role != 0)
                {
                 var uRoles =  _dbContext.UsersRoles.Where(x => x.FkUserId == entity.UserId);
                 foreach (var ur in uRoles)
                 {
                     _dbContext.UsersRoles.Remove(ur);
                 }
                }
            }

            foreach (var role in request.Roles)
            {

                if (role != 0)
                {
                    _dbContext.UsersRoles.Add(new UsersRole()
                    {
                        DateOfModification = DateTime.Now,
                        FkUserId = entity.UserId,
                        FkRoleId = role
                    });
                }
            }

            _dbContext.SaveChanges();

            var query = _dbContext.Users.Where(x => x.UserId == entity.UserId).Include(q => q.UsersRoles)
                .ThenInclude(r => r.FkRole).Include(c => c.FkCity).SingleOrDefault();

            return _mapper.Map<UserModel>(query);
        }
    }

}
