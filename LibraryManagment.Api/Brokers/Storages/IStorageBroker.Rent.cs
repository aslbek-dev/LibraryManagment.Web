using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Rent> InsertRentAsync(Rent rent);
        IQueryable<Rent> SelectAllRents();
        ValueTask<Rent> SelectRentByIdAsync(Guid id);
        ValueTask<Rent> UpdateRentAsync(Rent rent);
        ValueTask<Rent> DeleteRentAsync(Rent rent);
    }
}