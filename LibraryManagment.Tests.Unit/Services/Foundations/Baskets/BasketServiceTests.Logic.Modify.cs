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
        public async Task ShouldModifyBasket()
        {
            //given
            Basket randomBasket = CreateRandomBasket();
            Basket inputBasket = randomBasket;
            Basket modifiedBasket = inputBasket;
            Basket expectedBasket = modifiedBasket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateBasketAsync(inputBasket)).ReturnsAsync(modifiedBasket);
            
            // when
            Basket actualBasket = await this.basketService.ModifyBasketAsync(inputBasket);

            // then
            actualBasket.Should().BeEquivalentTo(expectedBasket);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateBasketAsync(inputBasket), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}