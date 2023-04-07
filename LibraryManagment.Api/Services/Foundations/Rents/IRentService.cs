using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Services.Foundations.Rents
{
    public interface IRentService
    {
        ValueTask<Rent> AddRentAsync(Rent rent);
        IQueryable<Rent> RetrieveAllRents();
        ValueTask<Rent> RetrieveRentByIdAsync(Guid id);
        ValueTask<Rent> ModifyRentAsync(Rent Rent);
        ValueTask<Rent> RemoveRentByIdAsync(Guid id);
    }
}