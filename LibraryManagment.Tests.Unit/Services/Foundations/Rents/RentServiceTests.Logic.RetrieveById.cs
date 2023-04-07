using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Rents;
using Moq;
using Xunit;

namespace LibraryManagment.Tests.Unit.Services.Foundations.Rents
{
    public partial class RentServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveRentByIdAsync()
        {
            //give
            Guid randomId = Guid.NewGuid();
            Guid inputId = randomId;
            Rent randomRent = CreateRandomRent();
            Rent storageRent = randomRent;
            Rent expectedRent = storageRent.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectRentByIdAsync(randomId)).ReturnsAsync(storageRent);

            //when
            Rent actualRent = 
                await this.rentService.RetrieveRentByIdAsync(inputId);

            //then
            actualRent.Should().BeEquivalentTo(expectedRent);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectRentByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}