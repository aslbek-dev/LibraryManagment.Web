using LibraryManagment.Api.Brokers.DateTime;
using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Services.Foundations.Rents
{
    public class RentService : IRentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        public RentService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
        }
        public async ValueTask<Rent> AddRentAsync(Rent rent)
        {
            return await this.storageBroker.InsertRentAsync(rent);
        }

        public IQueryable<Rent> RetrieveAllRents()
        {
            return this.storageBroker.SelectAllRents();
        }

        public async ValueTask<Rent> RetrieveRentByIdAsync(Guid id)
        {
           return await this.storageBroker.SelectRentByIdAsync(id);
        }

        public async ValueTask<Rent> ModifyRentAsync(Rent rent)
        {
            DateTimeOffset d = this.dateTimeBroker.GetCurrentDateTime();
            Rent modifiedRent = null;
            Rent targetRent = await this.storageBroker.SelectRentByIdAsync(rent.RentId);
            if(targetRent is not null && DateTimeOffset.Equals(d, rent.RentAt))
                 modifiedRent = await this.storageBroker.UpdateRentAsync(rent);
                
            return modifiedRent;
        }

        public ValueTask<Rent> RemoveRentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}