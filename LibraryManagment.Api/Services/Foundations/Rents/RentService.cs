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
    }
}