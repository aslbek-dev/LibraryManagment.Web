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
    }
}