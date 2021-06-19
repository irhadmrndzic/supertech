using superTech.Models.User;
using System.Collections.Generic;

namespace superTech.Services
{
   public interface IUsersService
   {
       public UserModel Login (UsersLoginRequest request);
       public List<UserModel> Get(UserSearchRequest searchFilter);
       public  UserModel GetById(int id);
       public UserModel Insert(UserUpsertRequest request);
       public UserModel Update(int id, UserUpsertRequest request);

   }
}
