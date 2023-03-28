using System.Collections.Immutable;
using LibraryManagment.Api.Models.Baskets;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Basket> Baskets { get; set; }
    }
}