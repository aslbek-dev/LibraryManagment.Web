using LibraryManagment.Api.Models.Baskets;
using LibraryManagment.Api.Services.Foundations.Baskets;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace LibraryManagment.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class BasketsController : RESTFulController
    {
        private readonly IBasketService basketService;
        public BasketsController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        
        [HttpPost]
        public async ValueTask<ActionResult<Basket>> PostBasketAsync(Basket basket)
        {
            try
            {
                return await this.basketService.AddBasketAsync(basket);
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
        
    }
