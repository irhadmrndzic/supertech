
using System.Collections.Generic;

namespace superTech.Model.User
{
   public class UserModel
    {
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
        public string City { get; set; }
        public List<string> Roles { get; set; }
    }

}
