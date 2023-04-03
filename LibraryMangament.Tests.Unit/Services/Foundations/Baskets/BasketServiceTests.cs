
using LibraryManagment.Api.Brokers.Storages;
using LibraryManagment.Api.Models.Baskets;
using LibraryManagment.Api.Services.Foundations.Baskets;
using Moq;
using Tynamix.ObjectFiller;

namespace LibraryMangament.Tests.Unit.Services.Foundations.Baskets
{
    public partial class BasketServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly BasketService basketService;

        public BasketServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.basketService = new BasketService
            (
                storageBroker: this.storageBrokerMock.Object
            );
        }

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
        
        private static Basket CreateRandomBasket() =>
            CreateBasketFiller(dates: GetRandomDateTime()).Create();

        private static Filler<Basket> CreateBasketFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Basket>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates)
                .OnProperty(basket => basket.Books).IgnoreIt()
                .OnProperty(basket => basket.Rent).IgnoreIt();

            return filler;
        }
    }
}