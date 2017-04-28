using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class HoldingLib
    {
        public async static Task InsertHolding(Holding holding)
        {
            await HoldingDataAccess.InsertData(holding);
        }

        public async static Task UpdateHolding(Holding holding)
        {
            await HoldingDataAccess.UpdateData(holding);
        }

        public async static Task DeleteHolding(string id)
        {
            await HoldingDataAccess.DeleteData(id);
        }

        public static Task<List<Holding>> GetAllHoldings()
        {
            var holdings = HoldingDataAccess.GetAllHoldings();
            return holdings;
        }

        public static async Task<Holding> GetHolding(string id)
        {
            var holding = await HoldingDataAccess.GetHoldingById(id);
            return holding;
        }

        public static async Task<List<Holding>> GetHoldingByEmployeeId(string employeeId)
        {
            var holdings = await HoldingDataAccess.GetHoldingByEmployeeId(employeeId);
            return holdings;
        }

    }
}
