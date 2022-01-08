using System;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Moq;

namespace Codecool.StockTrader.UnitTests
{
    [TestFixture]
    public class StockAPIServiceTest
    {
        [Test]
        public void GetPriceExistingSymbolReturnsPriceAsDouble()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const string exampleResponse = "{\"symbol\":\"AAPL\",\"price\":169.98}";
            const double expectedPrice = 169.98;

            // using NSubstitute
            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromURL(Arg.Any<string>()).ReturnsForAnyArgs(exampleResponse);

            // using Moq
            var remoteUrlReaderMock = new Mock<RemoteURLReader>();
            remoteUrlReaderMock.Setup(x => x.ReadFromURL(It.IsAny<string>())).Returns(exampleResponse);

            // using NSubstitute
            //var stockApiService = new StockAPIService(remoteUrlReader);

            // using Moq
            var stockApiService = new StockAPIService(remoteUrlReaderMock.Object);

            // act 
            double actualPrice = stockApiService.GetPrice(exampleSymbol);

            // assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void GetPriceNonExistingSymbolThrowsArgumentException()
        {
            // arrange
            const string nonexistingSymbol = "non-existing-symbol";
            const string exampleResponse = "{\"symbol\":\"AAPL\",\"price\":169.98}";

            //var remoteUrlReader = Substitute.For<RemoteURLReader>();
            //remoteUrlReader
            //    .When(x => x.ReadFromURL(Arg.Any<string>()))
            //    .Do(x => { throw new ArgumentException(); });
            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromURL(Arg.Any<string>()).ReturnsForAnyArgs(exampleResponse);

            var stockApiService = new StockAPIService(remoteUrlReader);

            // act & assert
            Assert.Throws<ArgumentException>(() => stockApiService.GetPrice(nonexistingSymbol));
        }

        [Test]
        public void GetPriceServerDownThrowsIOException()
        {
            // arrange
            const string exampleSymbol = "AAPL";

            // using NSubstitute
            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromURL(Arg.Any<string>()).ThrowsForAnyArgs<WebException>();

            // using Moq
            //var remoteUrlReaderMock = new Mock<RemoteURLReader>();
            //remoteUrlReaderMock.Setup(x => x.ReadFromURL(It.IsAny<string>())).Throws<WebException>();

            // using NSubstitute
            var stockApiService = new StockAPIService(remoteUrlReader);

            // using Moq
            //var stockApiService = new StockAPIService(remoteUrlReaderMock.Object);

            // act & assert
            Assert.Throws<WebException>(() => stockApiService.GetPrice(exampleSymbol));
        }

        [Test]
        public void GetPriceMalformedResponseFromAPIThrowsJsonReaderException()
        {
            // arrange
            const string exampleSymbol = "AAPL";
            const string malformedResponse = "\"{\"symbol\":";

            var remoteUrlReader = Substitute.For<RemoteURLReader>();
            remoteUrlReader.ReadFromURL(Arg.Any<string>()).ReturnsForAnyArgs(malformedResponse);

            var stockApiService = new StockAPIService(remoteUrlReader);

            // act & assert
            Assert.Throws<JsonReaderException>(() => stockApiService.GetPrice(exampleSymbol));
        }
    }
}
