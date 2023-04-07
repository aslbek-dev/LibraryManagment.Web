using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Books;
using Moq;
using Xunit;
namespace LibraryManagment.Tests.Unit.Services.Foundations.Books
{
    public partial class BookServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllBooks()
        {
            //given
            IQueryable<Book> randomBooks = CreateRandomBooks();
            IQueryable<Book> storageBooks = randomBooks;
            IQueryable<Book> expectedBooks = storageBooks.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllBooks()).Returns(expectedBooks);
            
            //when
            IQueryable<Book> actualBooks = this.bookService.RetrieveAllBooks();

            //then
            actualBooks.Should().BeEquivalentTo(expectedBooks);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllBooks(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}