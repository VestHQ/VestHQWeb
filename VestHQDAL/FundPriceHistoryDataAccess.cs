using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestHQDataModels;
using System.Configuration;

namespace VestHQDAL
{
    public static class FundPriceHistoryDataAccess
    {
        // Need to modify the url to http://vesthqmvp.azurewebsites.net
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        //private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<FundPriceHistory> fundPriceHistoryTable = MobileService.GetTable<FundPriceHistory>();

        public static async Task InsertData(FundPriceHistory fundPriceHistory)
        {
            await fundPriceHistoryTable.InsertAsync(fundPriceHistory);
        }

        public static async Task UpdateData(FundPriceHistory fundPriceHistory)
        {
            await fundPriceHistoryTable.UpdateAsync(fundPriceHistory);
        }

        public async static Task DeleteData(string id)
        {
            var fundPriceHistory = await GetFundPriceHistoryById(id);
            await fundPriceHistoryTable.DeleteAsync(fundPriceHistory);
        }

        public async static Task<FundPriceHistory> GetFundPriceHistoryById(string id)
        {
            var funds = fundPriceHistoryTable.Where(s => s.Id == id);

            var fundPriceHistory = funds.ToListAsync().Result.FirstOrDefault();

            return fundPriceHistory;

        }


        public async static Task<List<FundPriceHistory>> GetFundPriceHistoryByFundId(string fundId)
        {
            var funds = fundPriceHistoryTable.Where(s => s.FundId == fundId);

            var fundPriceHistory = funds.ToListAsync().Result;

            return fundPriceHistory;

        }

        public async static Task<List<FundPriceHistory>> GetAllFundPriceHistorys()
        {
            var prices = fundPriceHistoryTable.Take(10).ToListAsync().Result;
            return prices;
            //return fundPriceHistoryTable.ToListAsync().Result;
        }

    }
}
