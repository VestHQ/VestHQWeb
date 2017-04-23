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
    public class CustomerDataAccess
    {
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        //private static string mobileAppUri = ConfigurationManager.ConnectionStrings["VestHQConnection"].ConnectionString;

        //private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Customer> customerTable = MobileService.GetTable<Customer>();

        public static async Task InsertData(Customer customer)
        {
            await customerTable.InsertAsync(customer);
        }

        public static async Task UpdateData(Customer customer)
        {
            await customerTable.UpdateAsync(customer);
        }

        public static async Task DeleteData(string id)
        {
            var customer = await GetCustomerById(id);
            await customerTable.DeleteAsync(customer);
        }

        public static async Task DeleteData(Customer customer)
        {
            await customerTable.DeleteAsync(customer);
        }

        public static async Task<Customer> GetCustomerById(string id)
        {
            var customer = await customerTable.Where(c => c.Id == id).ToListAsync();
            return customer.FirstOrDefault(); //.Result.FirstOrDefault();

        }

        public static async Task<List<Customer>> GetAllCustomers()
        {

            var customers = await customerTable.ToListAsync();
            return customers;
        }

    }
}
