using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Api.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<User> AddUserAsync(User user)
        {
           return await this.storageBroker.InsertUserAsync(user);
        }

        public IQueryable<User> RetrieveAllUsers()
        {
            return this.storageBroker.SelectAllUsers();
        }
        public ValueTask<User> RetrieveUserByIdAsync(Guid id)
        {
            return this.storageBroker.SelectUserByIdAsync(id);
        }

        public async ValueTask<User> ModifyUserAsync(User user)
        {
            return await this.storageBroker.UpdateUserAsync(user);
        }

        public async ValueTask<User> RemoveUserByIdAsync(Guid id)
        {
            User inputUser = await this.storageBroker.SelectUserByIdAsync(id);
            User deletedUser = await this.storageBroker.DeleteUserAsync(inputUser);

            return deletedUser;
        }
    }
}