using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Models.Rents;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Models.Baskets
{
    public class Basket
    {

        public Guid BasketId { get; set; }
        //This bookId is Foreign Key
        public Guid BookId { get; set; }
        // EF relations // one to many
        public IQueryable<Book> Books { get; set; }
        //This UserId is Foreign Key
        public Guid UserId { get; set; }
        // EF relations // one to one
        public User User { get; set; }
        //EF relations // one to one
        public Rent Rent { get; set; }
    }
}