using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Services.Foundations.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly IStorageBroker storageBroker;
        public BasketService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Basket> AddBasketAsync(Basket basket)
        {
            return await this.storageBroker.InsertBasketAsync(basket);
        }

        public IQueryable<Basket> RetrieveAllBaskets()
        {
            return this.storageBroker.SelectAllBaskets();
        }
        
        public async ValueTask<Basket> RetrieveBasketByIdAsync(Guid id)
        {
            return await this.storageBroker.SelectBasketByIdAsync(id);
        }

        public ValueTask<Basket> ModifyBasketAsync(Basket basket)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Basket> RemoveBasketByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}