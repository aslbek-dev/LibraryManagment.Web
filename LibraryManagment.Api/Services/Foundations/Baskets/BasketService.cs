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
    }
}