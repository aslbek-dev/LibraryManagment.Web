using System.Reflection;
using EFxceptions;
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}