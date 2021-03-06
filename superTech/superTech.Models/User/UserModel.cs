
using System.Collections.Generic;
using Newtonsoft.Json;
using superTech.Models.Roles;

namespace superTech.Models.User
{
   public class UserModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string? DateOfEmployment { get; set; }
        public string RegistrationDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public int City { get; set; }
        public string CityString { get; set; }
        public string RolesString { get; set; }
        public byte[] ProfilePicture { get; set; }

        public List<int> Roles { get; set; }
        public ICollection<UsersRolesModel> UsersRoles { get; set; }

    }

}
