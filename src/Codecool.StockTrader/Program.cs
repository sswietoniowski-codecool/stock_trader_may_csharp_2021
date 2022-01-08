namespace Codecool.StockTrader
{
    public static class Program
    {
        public static void Main()
        {
            ILogger logger = new FileLogger();
            RemoteURLReader remoteUrlReader = new RemoteURLReader();
            StockAPIService stockApiService = new StockAPIService(remoteUrlReader);
            Trader trader = new Trader(stockApiService, logger);
            TradingApp app = new TradingApp(trader, logger);

            app.Start();
        }
    }
}
