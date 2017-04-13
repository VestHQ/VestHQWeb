using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestHQDataModels;
using System.Configuration;

namespace VestHQDAL
{
    public static class StockDataAccess
    {
        // Need to modify the url to http://vesthqmvp.azurewebsites.net
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        //private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<StockPriceHistory> stockTable = MobileService.GetTable<StockPriceHistory>();

        public static async Task InsertData(StockPriceHistory stock)
        {
            await stockTable.InsertAsync(stock);
        }

        public static async void UpdateData(StockPriceHistory stock)
        {
            await stockTable.UpdateAsync(stock);
        }

        public static async void DeleteData(StockPriceHistory stock)
        {
            await stockTable.DeleteAsync(stock);
        }

        public static StockPriceHistory GetStockById(string id)
        {
            var stocks = stockTable.Where(s => s.Id == id);

            var stock = stocks.ToListAsync().Result.FirstOrDefault();

            return stock;

        }

        public static List<StockPriceHistory> GetAllStocks()
        {
            return stockTable.ToListAsync().Result;
        }

    }
}
