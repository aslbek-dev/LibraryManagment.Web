using LibraryManagment.Api.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Book> Books { get; set; }
        public async ValueTask<Book> InsertBookAsync(Book book) =>
            await InsertAsync(book);
        
        public IQueryable<Book> SelectAllBooks() =>
            SelectAll<Book>();
        
        public async ValueTask<Book> SelectBookByIdAsync(Guid Id) =>
            await SelectAsync<Book>(Id);
        
        public async ValueTask<Book> UpdateBookAsync(Book book) =>
            await UpdateAsync<Book>(book);
        
        public async ValueTask<Book> DeleteBookAsync(Book book) =>
            await DeleteAsync<Book>(book);
    }
}