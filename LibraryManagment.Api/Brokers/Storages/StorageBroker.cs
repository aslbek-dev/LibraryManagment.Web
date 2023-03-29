using System.Reflection;
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class  StorageBroker: EFxceptionsContext, IStorageBroker
    {
        private readonly StorageBroker broker;
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private async ValueTask<T> InsertAsync<T>(T @object)
        {
            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return @object;
        }
        private IQueryable<T> SelectAll<T>() where T : class =>
            broker.Set<T>();

        private async ValueTask<T> SelectAsync<T>(params object[] objectsIds) where T : class =>
            await broker.FindAsync<T>(objectsIds);

        public async ValueTask<T> UpdateAsync<T>(T @object)
        {
            broker.Entry(@object).State = EntityState.Modified;
            await broker.SaveChangesAsync();

            return @object;
        }

        public async ValueTask<T> DeleteAsync<T>(T @object)
        {
            broker.Entry(@object).State = EntityState.Deleted;
            await broker.SaveChangesAsync();

            return @object;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                this.configuration.GetConnectionString(name: "SqlServerConnectionString");
                
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}