using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }
    }
}