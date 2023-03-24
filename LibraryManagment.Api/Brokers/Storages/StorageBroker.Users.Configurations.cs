using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.UserId);

            builder
                .Property(user => user.Name)
                .HasMaxLength(50)
                .IsRequired(true);
            
            builder
                .Property(user => user.Email)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder
                .Property(user => user.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired(true);
            
            builder
                .HasIndex(user => user.Email)
                .IsUnique(true);
        }
    }
}