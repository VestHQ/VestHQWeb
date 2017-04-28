using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class EmployeeDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(Employee employee)
        {
            var item = await GetEmployeeById(employee.Id);

            item.FirstName = employee.FirstName;
            item.LastName = employee.LastName;
            item.TwitterAccount = employee.TwitterAccount;

            await db.SaveChangesAsync();
        }

        public static async Task DeleteData(string id)
        {
            var employee = await GetEmployeeById(id);
            await DeleteData(employee);
        }

        public static async Task DeleteData(Employee employee)
        {
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
        }

        public static async Task<Employee> GetEmployeeById(string id)
        {
            return db.Employees
                .Include(e => e.Employer)
                .Where(e=>e.Id == id)
                .FirstOrDefault();

            /*var employee = await db.Employees.Where(c => c.Id == id).ToListAsync();
            return employee.FirstOrDefault();*/
        }

        public static async Task<List<Employee>> GetAllEmployees()
        {
            return await db.Employees
                .Include(e=>e.Employer)
                .AsNoTracking().ToListAsync();
            //throw new NotImplementedException();
        }

        public static async Task<List<Employee>> GetAllEmployeesForEmployer(string employerId)
        {
            return await db.Employees
                .Include(e => e.Employer)
                .Where(e=>e.EmployerId == employerId)
                .AsNoTracking().ToListAsync();
        }
    }
}
