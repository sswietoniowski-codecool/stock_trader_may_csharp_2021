using System;

namespace Codecool.StockTrader
{
    /// <summary>
    ///     Provides a command line interface for stock trading
    /// </summary>
    public class TradingApp
    {
        private ILogger _logger;
        private Trader _trader;

        public TradingApp(Trader trader, ILogger logger)
        {
            _trader = trader;
            _logger = logger;
        }

        public void Start()
        {
            Console.WriteLine("Enter a stock symbol (for example aapl):");
            string symbol = Console.ReadLine();
            Console.WriteLine("Enter the maximum price you are willing to pay:");

            if (double.TryParse(Console.ReadLine(), out double price))
            {
                try
                {
                    if (_trader.Buy(symbol, price))
                    {
                        _logger.Log("Purchased stock!");
                    }
                    else
                    {
                        _logger.Log("Couldn't buy the stock at that price.");
                    }
                }
                catch (Exception e)
                {
                    _logger.Log($"Error while attempting to purchase the stock: {e.Message}");
                }
            }
            else
            {
                _logger.Log("Invalid input.");
            }
        }
    }
}
