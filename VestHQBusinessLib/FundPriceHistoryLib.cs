using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
//using VestHQDAL;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class FundPriceHistoryLib
    {
        // Refreshes all of the fund prices
        public async Task RefreshCurrentFundPrices()
        {
            /*
            List<Fund> fundList;
            fundList = FundDataAccess.GetAllFunds();
            foreach (Fund fund in fundList)
                await RefreshCurrentFundPrices(fund.Ticker);
            */

            // TODO: Get funds from fund table
            await RefreshCurrentFundPrices("VTI", "1823329208");
            await RefreshCurrentFundPrices("VOO", "1238292754");
            await RefreshCurrentFundPrices("MGC", "674192873");
        }

        // Refreshes a single fund price
        public async static Task RefreshCurrentFundPrices(string ticker, string fundId)
        {
            // Gets the yahoo finance url, gets its html, and parses through it to get the price
            var financeUrl = string.Format("https://finance.yahoo.com/quote/{0}/?p={1}", ticker, ticker);
            string html = GetHtml(financeUrl);
            double price = GetFundPrice(html);

            // Need to use something in the format of Ticker-Date also put in time
            DateTime dateTime = DateTime.Now;
            string idDateString = dateTime.ToString("yyyy-MM-dd-HH:mm:ss");
            var id = ticker + "-" + idDateString;

            //var random = new Random();
            //var id = random.Next().ToString();
            var newFundPriceHistory = new FundPriceHistory()
            {
                Id = id,
                FundId = fundId,
                Ticker = ticker,
                TickerPrice = price,
                Time = dateTime
            };

            // Asynchronously inserts the data
            await FundPriceHistoryDataAccess.InsertData(newFundPriceHistory);
        }

        // Parses an html text twice in order to get the price data
        public static Double GetFundPrice(string html)
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

        public async static Task InsertFundPriceHistory(FundPriceHistory fundPriceHistory)
        {
            await FundPriceHistoryDataAccess.InsertData(fundPriceHistory);
        }

        public async static Task UpdateFundPriceHistory(FundPriceHistory fundPriceHistory)
        {
            await FundPriceHistoryDataAccess.UpdateData(fundPriceHistory);
        }

        public async static Task DeleteFundPriceHistory(string id)
        {
            await FundPriceHistoryDataAccess.DeleteData(id);
        }

        public static async Task<List<FundPriceHistory>> GetAllFundPriceHistorys()
        {
            var fundPriceHistorys = await FundPriceHistoryDataAccess.GetAllFundPriceHistorys();
            return fundPriceHistorys;
        }

        public static async Task<FundPriceHistory> GetFundPriceHistory(string id)
        {
            var fundPriceHistory = await FundPriceHistoryDataAccess.GetFundPriceHistoryById(id);
            return fundPriceHistory;
        }

    }
}
