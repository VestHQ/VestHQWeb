using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class FundDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(Fund fund)
        {
            db.Funds.Add(fund);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(Fund fund)
        {
            var item = await GetFundById(fund.Id);
            item.Name = fund.Name;
            item.Ticker = fund.Ticker;
            await db.SaveChangesAsync();
        }

        public static async Task DeleteData(string id)
        {
            var fund = await GetFundById(id);
            await DeleteData(fund);
        }

        public static async Task DeleteData(Fund fund)
        {
            db.Funds.Remove(fund);
            await db.SaveChangesAsync();
        }

        public static async Task<Fund> GetFundById(string id)
        {
            return await db.Funds.FindAsync(id);
        }

        public static async Task<List<Fund>> GetAllFunds()
        {
            return await db.Funds.AsNoTracking().ToListAsync();
        }
    }
}
