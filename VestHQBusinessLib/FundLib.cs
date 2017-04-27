using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VestHQDAL;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class FundLib
    {
        public async static Task InsertFund(Fund fund)
        {
            await FundDataAccess.InsertData(fund);
        }

        public async static Task UpdateFund(Fund fund)
        {
            await FundDataAccess.UpdateData(fund);
        }

        public async static Task DeleteFund(string id)
        {
            await FundDataAccess.DeleteData(id);
        }

        public static Task<List<Fund>> GetAllFunds()
        {
            var funds = FundDataAccess.GetAllFunds();
            return funds;
        }

        public static async Task<Fund> GetFund(string id)
        {
            var fund = await FundDataAccess.GetFundById(id);
            return fund;
        }

    }
}
