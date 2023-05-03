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
        public async Task ShouldRemoveUserById()
        {
            //given
            Guid randomId = new Guid();
            Guid inputId = randomId;
            User randomUser = CreateRandomUser();
            User storageUser = randomUser;
            User expectedInputUser = storageUser;
            User deletedUser = expectedInputUser;
            User expectedUser = deletedUser.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(inputId)).ReturnsAsync(storageUser);
            
            this.storageBrokerMock.Setup(broker =>
                broker.DeleteUserAsync(expectedInputUser)).ReturnsAsync(deletedUser);
            
            //when
            User actualUser = await this.userService.RemoveUserByIdAsync(inputId);

            //then
            actualUser.Should().BeEquivalentTo(expectedUser);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.Verify(broker =>
                broker.DeleteUserAsync(expectedInputUser), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls(); 
        }
    }
}