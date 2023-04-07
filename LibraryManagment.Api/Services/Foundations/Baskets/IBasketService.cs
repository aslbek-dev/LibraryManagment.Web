using System.Linq;
using LibraryManagment.Api.Models.Baskets;

namespace LibraryManagment.Api.Services.Foundations.Baskets
{
    public interface IBasketService
    {
        ValueTask<Basket> AddBasketAsync(Basket basket);
        IQueryable<Basket> RetrieveAllBaskets();
        ValueTask<Basket> RetrieveBasketByIdAsync(Guid id);
        ValueTask<Basket> ModifyBasketAsync(Basket basket);
        ValueTask<Basket> RemoveBasketByIdAsync(Guid id);

    }
}