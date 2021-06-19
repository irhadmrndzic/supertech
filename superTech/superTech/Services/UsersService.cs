using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using superTech.Database;
using superTech.Exceptions;
using superTech.Models.User;
using superTech.Services.GenericCRUD;

namespace superTech.Services
{
    public class UsersService:IUsersService
    {
        private readonly superTechRSContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(superTechRSContext context, IMapper mapper )
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public  List<UserModel> Get(UserSearchRequest searchFilter)
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

        public  UserModel GetById(int id)
        {
            var entity = _dbContext.Users.Where(x => x.UserId == id)
                .Include(ur => ur.UsersRoles)
                .ThenInclude(r => r.FkRole)
                .Include(q => q.FkCity).SingleOrDefault();

            return _mapper.Map<UserModel>(entity);
        }

        public  UserModel Insert(UserUpsertRequest request)
        {
            var entity = _mapper.Map<User>(request);

            entity.RegistrationDate = DateTime.Parse(request.DateOfRegistration);

            entity.DateOfBirth = DateTime.Parse(request.DateOfBirth);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwords don't match!");
                }

                entity.PasswordSalt = GenerateSalt();

                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }


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

        public  UserModel Update(int id, UserUpsertRequest request)
        {
            var entity = _dbContext.Users.Find(id);
            _dbContext.Users.Attach(entity);
            _dbContext.Users.Update(entity);


            entity.DateOfBirth = DateTime.Parse(request.DateOfBirth);

            entity.RegistrationDate = DateTime.Parse(request.DateOfRegistration);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Passwords don't match!");
                }

                entity.PasswordSalt = GenerateSalt();

                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }

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

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }


        public UserModel Authenticate(string username, string password)
        {
            return null;
        }

        public UserModel Login(UsersLoginRequest request)
        {

            var entity = _dbContext.Users.Where(x => x.UserName == request.Username).Include(q => q.UsersRoles)
                .ThenInclude(r => r.FkRole).SingleOrDefault();

            if (entity == null)
            {
                throw new UserException("Wrong username or password");
            }

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            if (hash != entity.PasswordHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<UserModel>(entity);
        }
    }

}
