using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Services.Foundations.Baskets
{
    public interface IBasketService
    {
        ValueTask<Basket> AddBasketAsync(Basket basket);
    }
}