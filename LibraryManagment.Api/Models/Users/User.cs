using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Api.Models.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } 
        public Gender Gender { get; set; }
        public  DateTime Birthday { get; set; }
        public UserType UserType { get; set; }
    }
}