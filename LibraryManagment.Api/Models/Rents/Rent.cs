using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Models.Rents
{
    public class Rent
    {
        public Guid RentId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime RentAt { get; set; }
        public DateTime ReturnAt { get; set; }
        public bool IsReturned { get; set; }
        public User Users { get; }
        public Book Books { get; }
    }
}