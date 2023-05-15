using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task ShouldRemoveBookById()
        {
            // given
            Guid randomId = new Guid();
            Guid inputId = randomId;
            Book randomBook = CreateRandomBook();
            Book storageBook = randomBook;
            Book expectedInputBook = storageBook;
            Book deletedBook = expectedInputBook;
            Book expectedBook = deletedBook.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectBookByIdAsync(inputId)).ReturnsAsync(storageBook);
            
            this.storageBrokerMock.Setup(broker =>
                broker.DeleteBookAsync(expectedInputBook)).ReturnsAsync(deletedBook);
            
            // when
            Book actualBook = await this.bookService.RemoveBookByIdAsync(inputId);

            // then
            actualBook.Should().BeEquivalentTo(expectedBook);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectBookByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.DeleteBookAsync(expectedInputBook), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
       

    }
}