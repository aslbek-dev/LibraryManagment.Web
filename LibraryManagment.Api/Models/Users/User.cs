using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Baskets;
using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Models.Users
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public  DateTimeOffset Birthday { get; set; }
        public UserType UserType { get; set; }
        //EF relations
        public Basket Basket { get; set; }
    }
}