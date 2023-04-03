using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Books;

namespace LibraryManagment.Api.Services.Foundations.Books
{
    public class BookService : IBookService
    {
        private readonly IStorageBroker storageBroker;
        public BookService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public ValueTask<Book> AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}