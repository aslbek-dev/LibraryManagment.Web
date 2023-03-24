using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagment.Api.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public void ConfigureBook(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            
            builder.HasKey(book => book.BookId);

            builder
                .Property(book => book.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            
            builder
                .Property(book => book.Author)
                .IsRequired(true);
        }
    }
}