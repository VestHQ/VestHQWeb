using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class StockDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(Stock stock)
        {
            db.Stocks.Add(stock);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(Stock stock)
        {
            var item = await GetStockById(stock.Id);
            item.Name = stock.Name;
            item.Ticker = stock.Ticker;
            await db.SaveChangesAsync();
        }

        public static async Task DeleteData(string id)
        {
            var stock = await GetStockById(id);
            await DeleteData(stock);
        }

        public static async Task DeleteData(Stock stock)
        {
            db.Stocks.Remove(stock);
            await db.SaveChangesAsync();
        }

        public static async Task<Stock> GetStockById(string id)
        {
            return await db.Stocks.FindAsync(id);
        }

        public static async Task<List<Stock>> GetAllStocks()
        {
            return await db.Stocks.AsNoTracking().ToListAsync();
        }
    }
}
