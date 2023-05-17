using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task ShouldRemoveBasketById()
        {
            Guid randomId = Guid.NewGuid();
            Guid inputId = randomId;
            Basket randomBasket = CreateRandomBasket();
            Basket storageBasket = randomBasket;
            Basket inputBasket = storageBasket;
            Basket deletedBasket = inputBasket;
            Basket expectedBasket = deletedBasket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectBasketByIdAsync(inputId)).ReturnsAsync(storageBasket);
            
            this.storageBrokerMock.Setup(broker =>
                broker.DeleteBasketAsync(inputBasket)).ReturnsAsync(deletedBasket);
            
            // when
            Basket actualBasket = await this.basketService.RemoveBasketByIdAsync(inputId);

            // than
            actualBasket.Should().BeEquivalentTo(expectedBasket);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectBasketByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.DeleteBasketAsync(inputBasket), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}