using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryManagment.Api.Models.Baskets;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public class BasketTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(basket => basket.BasketId);
                
            builder
                .HasOne(basket => basket.User)
                .WithOne(user => user.Basket)
                .HasForeignKey<Basket>(basket => basket.UserId)
                .IsRequired(true);
            
            builder
                .HasMany(basket => basket.Books)
                .WithOne(book => book.Basket)
                .HasForeignKey(basket => basket.BookId)
                .IsRequired(true);
        }
    }
}