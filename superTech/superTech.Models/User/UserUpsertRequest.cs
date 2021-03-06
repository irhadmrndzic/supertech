using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace superTech.Models.User
{
   public  class UserUpsertRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string DateOfRegistration { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public int CityId { get; set; }

        public byte[] ProfilePicture { get; set; }
        public List<int>? Roles { get; set; } = new List<int>();

      
    }
}
