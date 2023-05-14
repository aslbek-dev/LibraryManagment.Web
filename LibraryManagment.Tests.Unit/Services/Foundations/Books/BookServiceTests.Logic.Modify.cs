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
        public async Task ShouldModifyBook()
        {
            Book randomBook = CreateRandomBook();
            Book inputBook = randomBook;
            Book updatedBook = inputBook;
            Book expectedBook = updatedBook.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateBookAsync(inputBook)).ReturnsAsync(updatedBook);
            
            // when
            Book actualBook = await this.bookService.ModifyBookAsync(inputBook);

            // than
            actualBook.Should().BeEquivalentTo(expectedBook);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateBookAsync(inputBook), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}