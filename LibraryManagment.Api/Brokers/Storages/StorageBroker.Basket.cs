using LibraryManagment.Api.Models.Baskets;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Basket> Baskets { get; set; }

        public async ValueTask<Basket> InsertBasketAsync(Basket basket) =>
            await InsertAsync<Basket>(basket);
        
        public IQueryable<Basket> SelectAllBaskets() =>
            SelectAll<Basket>();

        public async ValueTask<Basket> SelectBasketByIdAsync(Guid Id) =>
            await SelectAsync<Basket>(Id);
        
        public async ValueTask<Basket> UpdateBasketAsync(Basket basket) =>
            await UpdateAsync(basket);
        
        public async ValueTask<Basket> DeleteBasketAsync(Basket basket) =>
            await DeleteAsync(basket);
    }
}