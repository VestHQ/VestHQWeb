using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VestHQDAL;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class StockLib
    {
        public async Task RefreshCurrentStockPrices()
        {
            await RefreshCurrentStockPrices("MSFT");
            await RefreshCurrentStockPrices("T");
            await RefreshCurrentStockPrices("AAPL");

        }

        public async static Task RefreshCurrentStockPrices(string ticker)
        {
            var financeUrl = string.Format("https://finance.yahoo.com/quote/{0}/?p={1}", ticker, ticker);
            string html = GetHtml(financeUrl);
            double price = GetStockPrice(html);
            var random = new Random();

            var id = random.Next().ToString();
            var newStock = new Stock()
            {
                Id = id,
                Ticker = ticker,
                TickerPrice = price,
                Time = DateTime.Now
            };

           await StockDataAccess.InsertData(newStock);


        }

        public static Double GetStockPrice(string html)
        {
            var prevClosePattern = "\"previousClose\":{\"raw\":[0-9]*(\\.)[0-9]+";
            var regex = new Regex(prevClosePattern);
            Double price = 0;
            if (regex.IsMatch(html))
            {
                var prevCloseMatch = regex.Match(html);
                string prevCloseString = prevCloseMatch.Value;
                Console.WriteLine(prevCloseString);
                var pricePattern = "[0-9]*(\\.)[0-9]+";
                var priceRegex = new Regex(pricePattern);
                if (priceRegex.IsMatch(prevCloseString))
                {
                    var priceMatch = priceRegex.Match(prevCloseString);
                    string priceString = priceMatch.Value;
                    price = Convert.ToDouble(priceString);
                }

            }
            return price;

        }

        public static string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
                return data;
            }

            return "Error: " + response.StatusDescription;

        }

    }
}
