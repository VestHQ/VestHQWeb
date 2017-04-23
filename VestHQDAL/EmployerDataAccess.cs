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
    public class EmployerDataAccess
    {
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Employer> employerTable = MobileService.GetTable<Employer>();

        public static async Task InsertData(Employer employer)
        {
            await employerTable.InsertAsync(employer);
        }

        public static async Task UpdateData(Employer employer)
        {
            await employerTable.UpdateAsync(employer);
        }

        public static async Task DeleteData(string id)
        {
            var employer = await GetEmployerById(id);
            await employerTable.DeleteAsync(employer);
        }

        public static async Task DeleteData(Employer employer)
        {
            await employerTable.DeleteAsync(employer);
        }

        public static async Task<Employer> GetEmployerById(string id)
        {
            var employer = await employerTable.Where(c => c.Id == id).ToListAsync();
            return employer.FirstOrDefault(); //.Result.FirstOrDefault();

        }

        public static async Task<List<Employer>> GetAllEmployers()
        {
            var employers = await employerTable.ToListAsync();
            return employers;
        }

    }
}
