using System;
using System.Collections.Generic;

#nullable disable

namespace superTech.Database
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            BuyerOrders = new HashSet<BuyerOrder>();
            News = new HashSet<News>();
            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
            UsersRoles = new HashSet<UsersRole>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public int? FkCityId { get; set; }

        public virtual City FkCity { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<BuyerOrder> BuyerOrders { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UsersRole> UsersRoles { get; set; }
    }
}
