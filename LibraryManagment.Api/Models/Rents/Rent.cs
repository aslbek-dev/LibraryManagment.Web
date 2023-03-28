using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Baskets;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Models.Rents
{
    public class Rent
    {
        public Guid RentId { get; set; }
        public DateTime RentAt { get; set; }
        public DateTime ReturnAt { get; set; }
        public bool IsReturned { get; set; } 
        //The basketId property is the Foreign Key
        public Guid BasketId { get; set; }
        //EF relations// one to one
        public Basket Basket { get; set; }
    }
}