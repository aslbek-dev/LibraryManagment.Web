using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task ShouldRemoveRentById()
        {
            // Given
            Guid randomId = new Guid();
            Guid inputId = randomId;
            Rent randomRent = CreateRandomRent();
            Rent storageRent = randomRent;
            Rent expectedInputRent = storageRent;
            Rent deletedRent = expectedInputRent;
            Rent expectedRent = deletedRent.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectRentByIdAsync(inputId))
                    .ReturnsAsync(storageRent);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteRentAsync(expectedInputRent))
                    .ReturnsAsync(deletedRent);

            // When
            Rent actualRent = await this.rentService.RemoveRentByIdAsync(inputId);
        
            // Then
            actualRent.Should().BeEquivalentTo(expectedRent);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectRentByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.DeleteRentAsync(expectedInputRent), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}