using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestHQDataModels;
using System.Configuration;

namespace VestHQDAL
{
    public static class StockPriceHistoryDataAccess
    {
        // Need to modify the url to http://vesthqmvp.azurewebsites.net
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        //private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<StockPriceHistory> stockPriceHistoryTable = MobileService.GetTable<StockPriceHistory>();

        public static async Task InsertData(StockPriceHistory stockPriceHistory)
        {
            await stockPriceHistoryTable.InsertAsync(stockPriceHistory);
        }

        public static async Task UpdateData(StockPriceHistory stockPriceHistory)
        {
            await stockPriceHistoryTable.UpdateAsync(stockPriceHistory);
        }

        public async static Task DeleteData(string id)
        {
            var stockPriceHistory = await GetStockPriceHistoryById(id);
            await stockPriceHistoryTable.DeleteAsync(stockPriceHistory);
        }

        public async static Task<StockPriceHistory> GetStockPriceHistoryById(string id)
        {
            var stocks = stockPriceHistoryTable.Where(s => s.Id == id);

            var stockPriceHistory = stocks.ToListAsync().Result.FirstOrDefault();

            return stockPriceHistory;

        }


        public async static Task<List<StockPriceHistory>> GetStockPriceHistoryByStockId(string stockId)
        {
            var stocks = stockPriceHistoryTable.Where(s => s.StockId == stockId);

            var stockPriceHistory = stocks.ToListAsync().Result;

            return stockPriceHistory;

        }

        public async static Task<List<StockPriceHistory>> GetAllStockPriceHistorys()
        {
            var prices = stockPriceHistoryTable.Take(10).ToListAsync().Result;
            return prices;
            //return stockPriceHistoryTable.ToListAsync().Result;
        }

    }
}
