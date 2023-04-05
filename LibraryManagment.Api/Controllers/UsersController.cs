using LibraryManagment.Api.Models.Users;
using LibraryManagment.Api.Services.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace LibraryManagment.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class UsersController : RESTFulController
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService) =>
            this.userService = userService;
        
        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
        {
            
                return await this.userService.AddUserAsync(user);
            
        }
    }
