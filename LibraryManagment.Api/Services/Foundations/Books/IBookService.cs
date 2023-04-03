using LibraryManagment.Api.Models.Books;

namespace LibraryManagment.Api.Services.Foundations.Books
{
    public interface IBookService
    {
        ValueTask<Book> AddBookAsync(Book book);
    }
}