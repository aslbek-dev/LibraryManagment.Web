using LibraryManagment.Api.Models.Books;

namespace LibraryManagment.Api.Services.Foundations.Books
{
    public interface IBookService
    {
        ValueTask<Book> AddBookAsync(Book book);
        IQueryable<Book> RetrieveAllBooks();
        ValueTask<Book> RetrieveBookByIdAsync(Guid id);
        ValueTask<Book> ModifyBookAsync(Book book);
        ValueTask<Book> RemoveBookByIdAsync(Guid id);
    }
}