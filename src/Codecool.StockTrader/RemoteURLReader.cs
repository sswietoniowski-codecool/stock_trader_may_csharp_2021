using System.Net;

namespace Codecool.StockTrader
{
    public static class RemoteURLReader
    {
        public static string ReadFromURL(string endpoint)
        {
            using WebClient client = new WebClient();
            string s = client.DownloadString(endpoint);

            return s;
        }
    }
}
