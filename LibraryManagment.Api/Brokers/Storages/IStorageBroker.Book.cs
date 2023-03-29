using LibraryManagment.Api.Models.Books;

namespace LibraryManagment.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Book> InsertBookAsync(Book book);
        IQueryable<Book> SelectAllBooks();
        ValueTask<Book> SelectBookByIdAsync(Guid Id);
        ValueTask<Book> UpdateBookAsync(Book book);
        ValueTask<Book> DeleteBookAsync(Book book);
    }
}