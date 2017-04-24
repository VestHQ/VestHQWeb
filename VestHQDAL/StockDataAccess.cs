using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataModels;

namespace VestHQDAL
{
    public class StockDataAccess
    {
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Stock> stockTable = MobileService.GetTable<Stock>();

        public static async Task InsertData(Stock stock)
        {
            await stockTable.InsertAsync(stock);
        }

        public static async Task UpdateData(Stock stock)
        {
            await stockTable.UpdateAsync(stock);
        }

        public static async Task DeleteData(string id)
        {
            var stock = await GetStockById(id);
            await stockTable.DeleteAsync(stock);
        }

        public static async Task DeleteData(Stock stock)
        {
            await stockTable.DeleteAsync(stock);
        }

        public static async Task<Stock> GetStockById(string id)
        {
            var stock = await stockTable.Where(c => c.Id == id).ToListAsync();
            return stock.FirstOrDefault(); //.Result.FirstOrDefault();

        }

        public static async Task<List<Stock>> GetAllStocks()
        {
            var stocks = await stockTable.ToListAsync();
            return stocks;
        }

    }
}
