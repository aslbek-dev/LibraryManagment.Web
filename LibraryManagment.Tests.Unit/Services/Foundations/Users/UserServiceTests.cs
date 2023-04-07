using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Services.Foundations.Users;
using Moq;
using Tynamix.ObjectFiller;
using LibraryManagment.Api.Models.Users;

namespace LibraryManagment.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IUserService userService;
        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.userService = new UserService(
                storageBroker: this.storageBrokerMock.Object
            );
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
        
        private static User CreateRandomUser() =>
            CreateUserFiller(dates: GetRandomDateTimeOffset()).Create();
        
        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
        
        private IQueryable<User> CreateRandomUsers()
        {
            return CreateUserFiller(dates: GetRandomDateTimeOffset())
                .Create(count: GetRandomNumber()).AsQueryable();
        }

        private static Filler<User> CreateUserFiller(DateTimeOffset dates)
        {
            var filler = new Filler<User>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);
            filler.Setup()
                .OnProperty(user => user.Basket).IgnoreIt();
            
            return filler;
        }
    }

}