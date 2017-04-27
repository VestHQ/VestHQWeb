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
    public class EmployeerLib
    {
        public async static Task InsertEmployee(Employee employee)
        {
           
            await EmployeeDataAccess.InsertData(employee);
        }

        public async static Task UpdateEmployee(Employee employee)
        {
            
            await EmployeeDataAccess.UpdateData(employee);
        }

        public async static Task DeleteEmployee(string id)
        {
            
            await EmployeeDataAccess.DeleteData(id);
        }

        public static Task<List<Employee>> GetAllEmployees()
        {
            
            var employees = EmployeeDataAccess.GetAllEmployees();
            return employees;
        }

        public static async Task<Employee> GetEmployee(string id)
        {
            var employee = await EmployeeDataAccess.GetEmployeeById(id);
            return employee;
        }

    }
}
