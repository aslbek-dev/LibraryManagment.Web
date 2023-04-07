using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Services.Foundations.Users
{
    public partial interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveAllUsers();
    }
}