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
            return this.storageBroker.SelectAllBooks();
        }

        public async ValueTask<Book> RetrieveBookByIdAsync(Guid id)
        {
            return await this.storageBroker.SelectBookByIdAsync(id);
        }

        public async ValueTask<Book> ModifyBookAsync(Book book)
        {
            return await this.storageBroker.UpdateBookAsync(book);
        }

        public async ValueTask<Book> RemoveBookByIdAsync(Guid id)
        {
            Book inputBook = await this.storageBroker.SelectBookByIdAsync(id);
            
            return await this.storageBroker.DeleteBookAsync(inputBook);
        }
    }
}