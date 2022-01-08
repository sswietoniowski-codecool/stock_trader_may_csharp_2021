using NUnit.Framework;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;

namespace Codecool.StockTrader.UnitTests
{
    [TestFixture]
    public class TraderTest
    {
        [Test]
        public void BuyBidLowerThanPriceReturnFalse()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const double exampleBid = 50;
            const double examplePrice = 100;

            var stockAPIService = Substitute.For<StockAPIService>();
            stockAPIService.GetPrice(exampleSymbol).Returns(examplePrice);

            var logger = Substitute.For<ILogger>();

            var trader = new Trader(stockAPIService, logger);

            // act
            var result = trader.Buy(exampleSymbol, exampleBid);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void BuyBidHigherThanPriceReturnTrue()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const double exampleBid = 100;
            const double examplePrice = 50;

            var stockAPIService = Substitute.For<StockAPIService>();
            stockAPIService.GetPrice(exampleSymbol).Returns(examplePrice);

            var logger = Substitute.For<ILogger>();

            var trader = new Trader(stockAPIService, logger);

            // act
            var result = trader.Buy(exampleSymbol, exampleBid);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void BuyNonExistingSymbolThrowsArgumentException()
        {
            // arrange
            const string nonexistingSymbol = "non-existing-symbol";
            const double exampleBid = 100;

            var stockAPIService = Substitute.For<StockAPIService>();
            stockAPIService.GetPrice(Arg.Any<string>()).ThrowsForAnyArgs<ArgumentException>();

            var logger = Substitute.For<ILogger>();

            var trader = new Trader(stockAPIService, logger);

            // act & assert
            Assert.Throws<ArgumentException>(() => trader.Buy(nonexistingSymbol, exampleBid));
        }
    }

}
