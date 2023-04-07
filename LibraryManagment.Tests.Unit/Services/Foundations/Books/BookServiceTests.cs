using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Books;
using LibraryManagment.Api.Services.Foundations.Books;
using Moq;
using Tynamix.ObjectFiller;

namespace LibraryManagment.Tests.Unit.Services.Foundations.Books
{
    public partial class BookServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IBookService bookService;
        public BookServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.bookService = new BookService(
                storageBroker: this.storageBrokerMock.Object);
        }
        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 11).GetValue();
        
        private static IQueryable<Book> CreateRandomBooks()
        {
            return CreateBookFiller(dates: GetRandomDateTimeOffset())
                .Create(count: GetRandomNumber()).AsQueryable();
        }

        private static Book CreateRandomBook() =>
            CreateBookFiller(dates: GetRandomDateTimeOffset()).Create();
        private static Filler<Book> CreateBookFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Book>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);
            filler.Setup()
                .OnProperty(book => book.Basket).IgnoreIt();
            
            return filler;
        }
        
    }
}