using LibraryManagment.Api.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
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