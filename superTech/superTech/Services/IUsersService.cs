using superTech.Models.User;

namespace superTech.Services
{
   public interface IUsersService
   {
       public UserModel Login (UsersLoginRequest request);
   }
}
