using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class StockPriceHistoryDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(StockPriceHistory stockPriceHistory)
        {
            db.StockPriceHistories.Add(stockPriceHistory);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(StockPriceHistory stockPriceHistory)
        {
            var item = await GetStockPriceHistoryById(stockPriceHistory.Id);

            item.StockId = stockPriceHistory.StockId;
            item.Ticker = stockPriceHistory.Ticker;
            item.TickerPrice = stockPriceHistory.TickerPrice;
            item.Time = stockPriceHistory.Time;
            
            await db.SaveChangesAsync();
        }

        public async static Task DeleteData(string id)
        {
            var stockPriceHistory = await GetStockPriceHistoryById(id);
            //db.StockPriceHistories.Remove(stockPriceHistory);
            //await db.SaveChangesAsync();
            await DeleteData(stockPriceHistory);
        }

        public static async Task DeleteData(StockPriceHistory stockPriceHistory)
        {
            db.StockPriceHistories.Remove(stockPriceHistory);
            await db.SaveChangesAsync();
        }

        public async static Task<StockPriceHistory> GetStockPriceHistoryById(string id)
        {
            return await db.StockPriceHistories.FindAsync(id);
        }
        
        public async static Task<List<StockPriceHistory>> GetStockPriceHistoryByStockId(string stockId)
        {
            return await db.StockPriceHistories.Where(s => s.StockId == stockId).AsNoTracking().ToListAsync();
        }

        public async static Task<List<StockPriceHistory>> GetAllStockPriceHistorys()
        {
            return await db.StockPriceHistories.AsNoTracking().ToListAsync();
        }

    }
}
