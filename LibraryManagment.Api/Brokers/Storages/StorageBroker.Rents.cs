using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Rents;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Rent> Rents { get; set; }
        
        public async ValueTask<Rent> InsertRentAsync(Rent rent) =>
            await InsertAsync<Rent>(rent);
        
        public IQueryable<Rent> SelectAllRents() =>
            SelectAll<Rent>();
        
        public async ValueTask<Rent> SelectRentByIdAsync(Guid id) =>
            await SelectAsync<Rent>(id);
        
        public async ValueTask<Rent> UpdateRentAsync(Rent rent) =>
            await UpdateAsync<Rent>(rent);
        
        public async ValueTask<Rent> DeleteRentAsync(Rent rent) =>
            await DeleteAsync(rent);
    }
}