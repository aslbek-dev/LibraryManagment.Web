using LibraryManagment.Api.Models.Rents;
using LibraryManagment.Api.Services.Foundations.Rents;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace LibraryManagment.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class RentsController : RESTFulController
    {
        private readonly IRentService rentService;
        public RentsController(IRentService rentService)
        {
            this.rentService = rentService;
        }
        
        [HttpPost]
        public async ValueTask<ActionResult<Rent>> PostRentAsync(Rent rent)
        {
            try
            {
                return Created(await this.rentService.AddRentAsync(rent));
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        
    }
