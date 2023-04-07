using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid id);
        ValueTask<User> ModifyUserAsync(User User);
        ValueTask<User> RemoveUserByIdAsync(Guid id);
    }
}