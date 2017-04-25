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
    public class EmployeeDataAccess
    {
        private static string mobileAppUri = ConfigurationManager.AppSettings["VestHQMobileAppUri"];
        //private static string mobileAppUri = ConfigurationManager.ConnectionStrings["VestHQConnection"].ConnectionString;

        //private static string mobileAppUri = @"http://dgvesthqmo.azurewebsites.net";
        private static MobileServiceClient MobileService = new MobileServiceClient(mobileAppUri);
        private static IMobileServiceTable<Employee> employeeTable = MobileService.GetTable<Employee>();

        public static async Task InsertData(Employee employee)
        {
            await employeeTable.InsertAsync(employee);
        }

        public static async Task UpdateData(Employee employee)
        {
            await employeeTable.UpdateAsync(employee);
        }

        public static async Task DeleteData(string id)
        {
            var employee = await GetEmployeeById(id);
            await employeeTable.DeleteAsync(employee);
        }

        public static async Task DeleteData(Employee employee)
        {
            await employeeTable.DeleteAsync(employee);
        }

        public static async Task<Employee> GetEmployeeById(string id)
        {
            var employee = await employeeTable.Where(c => c.Id == id).ToListAsync();
            return employee.FirstOrDefault(); //.Result.FirstOrDefault();

        }

        public static async Task<List<Employee>> GetAllEmployees()
        {

            var employees = await employeeTable.ToListAsync();
            return employees;
        }

    }
}
