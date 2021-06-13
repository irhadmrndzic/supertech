using superTech.Models.User;
using superTech.Services.GenericCRUD;

namespace superTech.Controllers
{
    public class UsersController : BaseCRUDController<UserModel, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        public UsersController(ICRUDService<UserModel, UserSearchRequest, UserUpsertRequest, UserUpsertRequest> IBaseService) : base(IBaseService)
        {

        }
    }
}