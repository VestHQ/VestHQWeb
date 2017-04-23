using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using VestHQDAL;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class StockLib
    {
        // Refreshes all of the stock prices
        public async Task RefreshCurrentStockPrices()
        {
            /*
            List<Stock> stockList;
            stockList = StockDataAccess.GetAllStocks();
            foreach (Stock stock in stockList)
                await RefreshCurrentStockPrices(stock.Ticker);
            */

            // TODO: Get stocks from stock table
            await RefreshCurrentStockPrices("MSFT");
            await RefreshCurrentStockPrices("T");
            await RefreshCurrentStockPrices("AAPL");
        }

        // Refreshes a single stock price
        public async static Task RefreshCurrentStockPrices(string ticker)
        {
            // Gets the yahoo finance url, gets its html, and parses through it to get the price
            var financeUrl = string.Format("https://finance.yahoo.com/quote/{0}/?p={1}", ticker, ticker);
            string html = GetHtml(financeUrl);
            double price = GetStockPrice(html);

            // Need to use something in the format of Ticker-Date also put in time
            DateTime dateTime = DateTime.Now;
            string idDateString = dateTime.ToString("yyyy-MM-dd-HH:mm:ss");
            var id = ticker + "-" + idDateString;

            //var random = new Random();
            //var id = random.Next().ToString();
            var newStock = new StockPriceHistory()
            {
                Id = id,
                Ticker = ticker,
                TickerPrice = price,
                Time = dateTime
            };

            // Asynchronously inserts the data
            await StockDataAccess.InsertData(newStock);
        }

        // Parses an html text twice in order to get the price data
        public static Double GetStockPrice(string html)
        {
            // First regex pass is to reduce it to the previous close area
            var prevClosePattern = "\"previousClose\":{\"raw\":[0-9]*(\\.)[0-9]+";
            var regex = new Regex(prevClosePattern);
            Double price = 0;
            if (regex.IsMatch(html))
            {
                // Extracts the value into prevCloseString
                var prevCloseMatch = regex.Match(html);
                string prevCloseString = prevCloseMatch.Value;
                Console.WriteLine(prevCloseString);

                // Second regex pass is to get the number out of it
                var pricePattern = "[0-9]*(\\.)[0-9]+";
                var priceRegex = new Regex(pricePattern);
                if (priceRegex.IsMatch(prevCloseString))
                {
                    // Finally return the price
                    var priceMatch = priceRegex.Match(prevCloseString);
                    string priceString = priceMatch.Value;
                    price = Convert.ToDouble(priceString);
                }

            }
            return price;

        }

        // Gets the html from the url through a normal HTTP request
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

            // This returns the error code and description in case call is unsuccessful
            return "Error: " + response.StatusDescription;

        }

    }
}
