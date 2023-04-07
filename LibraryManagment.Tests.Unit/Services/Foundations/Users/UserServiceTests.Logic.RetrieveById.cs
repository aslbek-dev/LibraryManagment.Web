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
        public async Task ShouldRetrieveUserByIdAsync()
        {
            //give
            Guid randomId = Guid.NewGuid();
            Guid inputId = randomId;
            User randomUser = CreateRandomUser();
            User storageUser = randomUser;
            User expectedUser = storageUser.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(randomId)).ReturnsAsync(storageUser);

            //when
            User actualUser = 
                await this.userService.RetrieveUserByIdAsync(inputId);

            //then
            actualUser.Should().BeEquivalentTo(expectedUser);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(inputId), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}