using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Users;
using Moq;
using Xunit;

namespace LibraryManagment.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldModifyUserAsync()
        {
            //given
            User randomUser = CreateRandomUser();
            User inputUser = randomUser;
            User storageUser = inputUser.DeepClone();
            User updatedUser = inputUser;
            User expectedUser = updatedUser.DeepClone();
            Guid userId = inputUser.UserId;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(userId))
                    .ReturnsAsync(storageUser);
            
            this.storageBrokerMock.Setup(broker =>
                broker.UpdateUserAsync(inputUser))
                    .ReturnsAsync(updatedUser);
        
            //when
            User actualUser = 
                await this.userService.ModifyUserAsync(inputUser);
            
            //then
            actualUser.Should().BeEquivalentTo(expectedUser);

            // this.storageBrokerMock.Verify(broker =>
            //     broker.SelectUserByIdAsync(userId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.UpdateUserAsync(inputUser), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}