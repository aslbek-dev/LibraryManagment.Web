using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Rents;
using LibraryManagment.Api.Services.Foundations.Rents;
using Moq;
using Tynamix.ObjectFiller;

namespace LibraryMangament.Tests.Unit.Services.Foundations.Rents
{
    public partial class RentServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IRentService rentService;
        public RentServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.rentService = new RentService
            (
                storageBroker: storageBrokerMock.Object
            );
        }
        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
        
        private static Rent CreateRandomRent() =>
            CreateRentFiller(GetRandomDateTime()).Create();
        private static Filler<Rent> CreateRentFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Rent>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates)
                .OnProperty(rent => rent.Basket).IgnoreIt();
            
            return filler;
        }
    }
}