using NUnit.Framework;

namespace Codecool.StockTrader.UnitTests
{
    [TestFixture]
    public class StockAPIServiceTest
    {
        [Test]
        public void GetPriceExistingSymbolReturnsPriceAsDouble()
        {
        }

        [Test]
        public void GetPriceNonExistingSymbolThrowsArgumentException()
        {
        }

        [Test]
        public void GetPriceServerDownThrowsIOException()
        {
        }

        [Test]
        public void GetPriceMalformedResponseFromAPIThrowsJsonReaderException()
        {
        }
    }
}
