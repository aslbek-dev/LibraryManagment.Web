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
        public async Task ShouldRetrieveBookByIdAsync()
        {
            //give
            Guid randomId = Guid.NewGuid();
            Guid inputId = randomId;
            Book randomBook = CreateRandomBook();
            Book storageBook = randomBook;
            Book expectedBook = storageBook.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectBookByIdAsync(randomId)).ReturnsAsync(storageBook);

            //when
            Book actualBook = 
                await this.bookService.RetrieveBookByIdAsync(inputId);

            //then
            actualBook.Should().BeEquivalentTo(expectedBook);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectBookByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}