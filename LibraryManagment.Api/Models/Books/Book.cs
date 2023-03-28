using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Baskets;
using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Models.Books
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublisherAt { get; set; }
        public int Version { get; set; }
        //EF relations// many to one
        public Basket Basket { get; set; }
    }
}