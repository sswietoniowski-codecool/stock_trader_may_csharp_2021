using System.Net;

namespace Codecool.StockTrader
{
    public class RemoteURLReader
    {
        public virtual string ReadFromURL(string endpoint)
        {
            using WebClient client = new WebClient();
            string s = client.DownloadString(endpoint);

            return s;
        }
    }
}
