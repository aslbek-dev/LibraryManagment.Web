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
        public async Task ShouldModifyRentAsync()
        {
            //given
            DateTimeOffset randomDateTime = GetRandomDateTime();
            Rent randomRent = CreateRandomRent(randomDateTime);
            Rent inputRent = randomRent;
            Rent storageRent = inputRent;
            Rent updateRent = storageRent;
            Rent expectedRent = updateRent.DeepClone();

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime()).Returns(randomDateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectRentByIdAsync(inputRent.RentId)).ReturnsAsync(storageRent);
                
            this.storageBrokerMock.Setup(broker =>
                broker.UpdateRentAsync(inputRent)).ReturnsAsync(updateRent);
            
            //when
            Rent actualRent = 
                await this.rentService.ModifyRentAsync(inputRent);
            
            //then
            actualRent.Should().BeEquivalentTo(expectedRent);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectRentByIdAsync(inputRent.RentId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.UpdateRentAsync(inputRent), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}