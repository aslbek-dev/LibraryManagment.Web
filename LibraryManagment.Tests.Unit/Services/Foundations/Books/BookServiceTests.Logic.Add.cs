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
        public async Task ShouldAddBookAync()
        {
            //given
            Book randomBook = CreateRandomBook();
            Book inputBook = randomBook;
            Book persistedBook = inputBook;
            Book expectedBook = persistedBook.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertBookAsync(inputBook)).ReturnsAsync(persistedBook); 
            //when
            Book actualBook = await this.bookService.AddBookAsync(inputBook);

            //than
            actualBook.Should().BeEquivalentTo(expectedBook);
            
            this.storageBrokerMock.Verify(broker =>
                broker.InsertBookAsync(inputBook), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}