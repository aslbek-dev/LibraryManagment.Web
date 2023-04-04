using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Services.Foundations.Rents
{
    public interface IRentService
    {
        ValueTask<Rent> AddRentAsync(Rent rent);
    }
}