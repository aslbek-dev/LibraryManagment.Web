using LibraryManagment.Api.Models.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public class RentTypeConfiguration : IEntityTypeConfiguration<Rent>
    {

        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(rent => rent.RentId);

            builder
                .Property(rent => rent.IsReturned)
                .IsRequired(true);
                
            //relation
            builder
                .HasOne(rent => rent.Basket)
                .WithOne(basket => basket.Rent)
                .HasForeignKey<Rent>(rent => rent.BasketId);
        }
    }
}