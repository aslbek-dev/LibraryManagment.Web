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
        public async Task ShouldAddRentAsync()
        {
            //given
            Rent randomRent = CreateRandomRent();
            Rent inputRent = randomRent;
            Rent persistedRent = inputRent;
            Rent expectedRent = inputRent.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertRentAsync(inputRent)).ReturnsAsync(persistedRent);
            
            //when
            Rent actualRent = await this.rentService.AddRentAsync(inputRent);

            //than
            actualRent.Should().BeEquivalentTo(expectedRent);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertRentAsync(inputRent), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}