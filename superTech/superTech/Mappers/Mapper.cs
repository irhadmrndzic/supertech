using System.Linq;
using AutoMapper;
using superTech.Database;
using superTech.Models.Category;
using superTech.Models.City;
using superTech.Models.Product;
using superTech.Models.Roles;
using superTech.Models.User;

namespace superTech.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Role, RolesModel>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<UsersRole, UsersRolesModel>().ReverseMap();


            CreateMap<User, UserModel>()
                .ForMember(x => x.Roles, a => a.MapFrom(src => src.UsersRoles.Select(s => s.FkRole.Name)))
                .ForMember(g => g.City, gr => gr.MapFrom(sr => sr.FkCity.CityId))
                .ForMember(c => c.CityString, c => c.MapFrom(c => c.FkCity.Name))
                .ForMember(r => r.RolesString, rs => rs.MapFrom(src => string.Join("," , src.UsersRoles.Select(x=>x.FkRole.Name))))
                .ForMember(c => c.Roles, c => c.MapFrom(c => c.UsersRoles.Select(q=>q.FkRoleId)))
                .ReverseMap();



            CreateMap<User, UserUpsertRequest>().ReverseMap();



            CreateMap<User, UserUpsertRequest>()
                .ForMember(x=>x.CityId,q=>q.MapFrom(src=>src.FkCityId))
                .ReverseMap();


            CreateMap<Product,ProductUpsertRequest>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();

            CreateMap<City, CityUpsertRequest>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();
        }
    }
}
