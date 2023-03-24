using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public void ConfigureRent(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents");

            builder.HasKey(rent => rent.UserId);

            builder
                .HasOne(rent => rent.Users)
                .WithMany(user => user.Rents)
                .HasForeignKey(rent => rent.UserId);

            builder.HasKey(rent => rent.BookId);

                builder
                    .HasOne(rent => rent.Books)
                    .WithMany(book => book.Rents)
                    .HasForeignKey(rent => rent.BookId);

                
        }
    }
}