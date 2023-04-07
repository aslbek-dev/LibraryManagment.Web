using FluentAssertions;
using Force.DeepCloner;
using LibraryManagment.Api.Models.Users;
using Moq;
using Xunit;
namespace LibraryMangament.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllUsers()
        {
            //given
            IQueryable<User> randomUsers = CreateRandomUsers();
            IQueryable<User> storageUsers = randomUsers;
            IQueryable<User> expectedUsers = storageUsers.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllUsers()).Returns(expectedUsers);
            
            //when
            IQueryable<User> actualUsers = this.userService.RetrieveAllUsers();

            //then
            actualUsers.Should().BeEquivalentTo(expectedUsers);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllUsers(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}