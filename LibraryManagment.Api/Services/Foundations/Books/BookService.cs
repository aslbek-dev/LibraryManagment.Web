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

        public async ValueTask<Book> AddBookAsync(Book book)
        {
            return await this.storageBroker.InsertBookAsync(book);
        }

        public IQueryable<Book> RetrieveAllBooks()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Book> RetrieveBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Book> ModifyBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Book> RemoveBookByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}