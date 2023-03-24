using System.Reflection;
using EFxceptions;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Models.Rents;
using LibraryManagment.Api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class  StorageBroker: EFxceptionsContext, IStorageBroker
    {
        private readonly IStorageBroker broker;
        public StorageBroker(DbContextOptions options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           ConfigureBook(modelBuilder.Entity<Book>());
           ConfigureRent(modelBuilder.Entity<Rent>());
           ConfigureUser(modelBuilder.Entity<User>());
        }
    }
}