using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestHQDataModels;

namespace VestHQDAL
{
    public static class StockDataAccess
    {
        private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Stock> stockTable = MobileService.GetTable<Stock>();

        public static async Task InsertData(Stock stock)
        {
            await stockTable.InsertAsync(stock);
        }

        public static async void UpdateData(Stock stock)
        {
            await stockTable.UpdateAsync(stock);
        }

        public static async void DeleteData(Stock stock)
        {
            await stockTable.DeleteAsync(stock);
        }

        public static Stock GetStockById(string id)
        {
            var stocks = stockTable.Where(s => s.Id == id);

            var stock = stocks.ToListAsync().Result.FirstOrDefault();

            return stock;

        }

        public static List<Stock> GetAllStocks()
        {
            return stockTable.ToListAsync().Result;
        }

    }
}
