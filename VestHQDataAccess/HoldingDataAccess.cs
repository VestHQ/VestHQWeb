using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class HoldingDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(Holding holding)
        {
            db.Holdings.Add(holding);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(Holding holding)
        {
            var item = await GetHoldingById(holding.Id);
            item.EmployeeId = holding.EmployeeId;
            item.SharesOwned = holding.SharesOwned;
            item.FundId = holding.FundId;
            await db.SaveChangesAsync();
        }

        public async static Task DeleteData(string id)
        {
            var holding = await GetHoldingById(id);
            await DeleteData(holding);
            //db.Holdings.Remove(holding);
            //await db.SaveChangesAsync();
        }

        public static async Task DeleteData(Holding holding)
        {
            db.Holdings.Remove(holding);
            await db.SaveChangesAsync();
        }

        public async static Task<Holding> GetHoldingById(string id)
        {
            return await db.Holdings.FindAsync(id);
        }

        public async static Task<List<Holding>> GetHoldingByEmployeeId(string employeeId)
        {
            return await db.Holdings.Where(s => s.EmployeeId == employeeId).AsNoTracking().ToListAsync();
        }

        public async static Task<List<Holding>> GetAllHoldings()
        {
            return await db.Holdings.AsNoTracking().ToListAsync();
        }
    }
}
