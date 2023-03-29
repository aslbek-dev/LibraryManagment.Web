using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Basket> InsertBasketAsync(Basket basket);
        IQueryable<Basket> SelectAllBaskets();
        ValueTask<Basket> SelectBasketByIdAsync(Guid Id);
        ValueTask<Basket> UpdateBasketAsync(Basket basket);
        ValueTask<Basket> DeleteBasketAsync(Basket basket);
    }
}