using System.Text.Json.Serialization;
using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Models.Rents
{
    public class Rent
    {
        public Guid RentId { get; set; }
        public DateTimeOffset RentAt { get; set; }
        public DateTimeOffset ReturnAt { get; set; }
        public bool IsReturned { get; set; } 
        //The basketId property is the Foreign Key
        public Guid BasketId { get; set; }
        [JsonIgnore]
        public Basket Basket { get; set; }
    }
}