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
        public async Task ShouldRetrieveBasketByIdAsync()
        {
            //give
            Guid randomId = Guid.NewGuid();
            Guid inputId = randomId;
            Basket randomBasket = CreateRandomBasket();
            Basket storageBasket = randomBasket;
            Basket expectedBasket = storageBasket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectBasketByIdAsync(randomId)).ReturnsAsync(storageBasket);

            //when
            Basket actualBasket = 
                await this.basketService.RetrieveBasketByIdAsync(inputId);

            //then
            actualBasket.Should().BeEquivalentTo(expectedBasket);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectBasketByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}