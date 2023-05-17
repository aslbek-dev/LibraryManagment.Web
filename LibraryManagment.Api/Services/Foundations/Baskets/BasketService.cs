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

        public async ValueTask<Basket> ModifyBasketAsync(Basket basket)
        {
            return await this.storageBroker.UpdateBasketAsync(basket);
        }

        public async ValueTask<Basket> RemoveBasketByIdAsync(Guid id)
        {
            Basket inputBasket = await this.storageBroker.SelectBasketByIdAsync(id);

            return await this.storageBroker.DeleteBasketAsync(inputBasket);
        }
    }
}