using System;
using System.IO;

namespace Codecool.StockTrader
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            var date = DateTime.Now;
            string msg = $"{date} {message}";

            Console.WriteLine(msg);

            try
            {
                File.AppendAllText("log.txt", msg);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Log file write failed :( {e.Message}");
            }
        }
    }
}
