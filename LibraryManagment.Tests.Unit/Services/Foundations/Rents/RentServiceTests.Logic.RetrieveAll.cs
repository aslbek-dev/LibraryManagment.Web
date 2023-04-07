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
        public void ShouldRetrieveAllRents()
        {
            //given
            IQueryable<Rent> randomRents = CreateRandomRents();
            IQueryable<Rent> storageRents = randomRents;
            IQueryable<Rent> expectedRents = storageRents.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllRents()).Returns(expectedRents);
            
            //when
            IQueryable<Rent> actualRents = this.rentService.RetrieveAllRents();

            //then
            actualRents.Should().BeEquivalentTo(expectedRents);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllRents(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}