using System.Text.Json.Serialization;
using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Models.Books
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublisherAt { get; set; }
        public int Version { get; set; }
        [JsonIgnore]
        public Basket Basket { get; set; }
    }
}