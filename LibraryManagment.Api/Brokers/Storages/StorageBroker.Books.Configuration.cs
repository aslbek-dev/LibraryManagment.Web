using LibraryManagment.Api.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public class BookTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.BookId);

            builder
                .Property(book => book.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            
            builder
                .Property(book => book.Author)
                .IsRequired(true);
            
            builder
                .Property(book => book.Version)
                .IsRequired(true);
        }
    }
}