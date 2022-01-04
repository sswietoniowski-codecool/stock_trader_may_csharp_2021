using System;

namespace Codecool.StockTrader
{
    /// <summary>
    ///     Provides a command line interface for stock trading
    /// </summary>
    public class TradingApp
    {
        public void Start()
        {
            Console.WriteLine("Enter a stock symbol (for example aapl):");
            string symbol = Console.ReadLine();
            Console.WriteLine("Enter the maximum price you are willing to pay:");

            if (double.TryParse(Console.ReadLine(), out double price))
            {
                try
                {
                    if (Trader.Instance.Buy(symbol, price))
                    {
                        FileLogger.Instance.Log("Purchased stock!");
                    }
                    else
                    {
                        FileLogger.Instance.Log("Couldn't buy the stock at that price.");
                    }
                }
                catch (Exception e)
                {
                    FileLogger.Instance.Log($"Error while attempting to purchase the stock: {e.Message}");
                }
            }
            else
            {
                FileLogger.Instance.Log("Invalid input.");
            }
        }
    }
}
