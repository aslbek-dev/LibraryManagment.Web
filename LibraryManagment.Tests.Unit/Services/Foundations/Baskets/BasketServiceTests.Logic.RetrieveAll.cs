using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Baskets;
using Moq;
using Xunit;
namespace LibraryManagment.Tests.Unit.Services.Foundations.Baskets
{
    public partial class BasketServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllBaskets()
        {
            //given
            IQueryable<Basket> randomBaskets = CreateRandomBaskets();
            IQueryable<Basket> storageBaskets = randomBaskets;
            IQueryable<Basket> expectedBaskets = storageBaskets.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllBaskets()).Returns(expectedBaskets);
            
            //when
            IQueryable<Basket> actualBaskets = this.basketService.RetrieveAllBaskets();

            //then
            actualBaskets.Should().BeEquivalentTo(expectedBaskets);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllBaskets(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}