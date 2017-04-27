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
    public class FundDataAccess
    {
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Fund> fundTable = MobileService.GetTable<Fund>();

        public static async Task InsertData(Fund fund)
        {
            await fundTable.InsertAsync(fund);
        }

        public static async Task UpdateData(Fund fund)
        {
            await fundTable.UpdateAsync(fund);
        }

        public static async Task DeleteData(string id)
        {
            var fund = await GetFundById(id);
            await fundTable.DeleteAsync(fund);
        }

        public static async Task DeleteData(Fund fund)
        {
            await fundTable.DeleteAsync(fund);
        }

        public static async Task<Fund> GetFundById(string id)
        {
            var fund = await fundTable.Where(c => c.Id == id).ToListAsync();
            return fund.FirstOrDefault(); //.Result.FirstOrDefault();

        }

        public static async Task<List<Fund>> GetAllFunds()
        {
            var funds = await fundTable.ToListAsync();
            return funds;
        }

    }
}
