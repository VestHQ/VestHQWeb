using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class FundPriceHistoryDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(FundPriceHistory fundPriceHistory)
        {
            db.FundPriceHistories.Add(fundPriceHistory);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(FundPriceHistory fundPriceHistory)
        {
            var item = await GetFundPriceHistoryById(fundPriceHistory.Id);

            item.FundId = fundPriceHistory.FundId;
            item.Ticker = fundPriceHistory.Ticker;
            item.TickerPrice = fundPriceHistory.TickerPrice;
            item.Time = fundPriceHistory.Time;
            
            await db.SaveChangesAsync();
        }

        public async static Task DeleteData(string id)
        {
            var fundPriceHistory = await GetFundPriceHistoryById(id);
            //db.FundPriceHistories.Remove(fundPriceHistory);
            //await db.SaveChangesAsync();
            await DeleteData(fundPriceHistory);
        }

        public static async Task DeleteData(FundPriceHistory fundPriceHistory)
        {
            db.FundPriceHistories.Remove(fundPriceHistory);
            await db.SaveChangesAsync();
        }

        public async static Task<FundPriceHistory> GetFundPriceHistoryById(string id)
        {
            return await db.FundPriceHistories.FindAsync(id);
        }
        
        public async static Task<List<FundPriceHistory>> GetFundPriceHistoryByFundId(string fundId)
        {
            return await db.FundPriceHistories.Where(s => s.FundId == fundId).AsNoTracking().ToListAsync();
        }

        public async static Task<List<FundPriceHistory>> GetAllFundPriceHistorys()
        {
            return await db.FundPriceHistories.AsNoTracking().ToListAsync();
        }

    }
}
