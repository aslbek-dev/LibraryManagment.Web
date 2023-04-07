using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Services.Foundations.Rents
{
    public class RentService : IRentService
    {
        private readonly IStorageBroker storageBroker;
        public RentService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<Rent> AddRentAsync(Rent rent)
        {
            return await this.storageBroker.InsertRentAsync(rent);
        }

        public IQueryable<Rent> RetrieveAllRents()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Rent> RetrieveRentByIdAsync(Guid id)
        {
           return await this.storageBroker.SelectRentByIdAsync(id);
        }

        public ValueTask<Rent> ModifyRentAsync(Rent Rent)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Rent> RemoveRentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}