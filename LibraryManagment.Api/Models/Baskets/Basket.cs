using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Models.Rents;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Models.Baskets
{
    public class Basket
    {

        public Guid BasketId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        
        [JsonIgnore]
        public IQueryable<Book> Books { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Rent Rent { get; set; }
    }
}