using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Rents;

namespace LibraryManagment.Api.Services.Foundations.Rents
{
    public interface IRentService
    {
        ValueTask<Rent> AddRentAsync(Rent rent);
    }
}