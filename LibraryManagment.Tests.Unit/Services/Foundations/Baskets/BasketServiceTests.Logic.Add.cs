using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Baskets;
using Moq;
using Xunit;

namespace LibraryMangament.Tests.Unit.Services.Foundations.Baskets
{
    public partial class BasketServiceTests
    {
        [Fact]
        public async Task ShouldAddBasketAsync()
        {
            //given
            Basket randomBasket = CreateRandomBasket();
            Basket inputBasket = randomBasket;
            Basket persistedBasket = inputBasket;
            Basket expectedBasket = persistedBasket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertBasketAsync(inputBasket)).ReturnsAsync(persistedBasket);
            //when
            Basket actualBasket = await this.basketService.AddBasketAsync(inputBasket);
            
            //than
            actualBasket.Should().BeEquivalentTo(expectedBasket);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertBasketAsync(inputBasket), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}