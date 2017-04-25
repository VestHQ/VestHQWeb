using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VestHQBusinessLib;
using VestHQDataModels;

namespace VestHQWeb.Controllers
{
    public class EmployeeDataController : ApiController
    {

        // GET api/employees
        public async Task<List<Employee>> Get()
        {
            var allEmployees =  await EmployeerLib.GetAllEmployees();
            return allEmployees;
        }

        // GET api/employees/5
        public async Task<Employee> Get(int id)
        {
            var employee = await EmployeerLib.GetEmployee(id.ToString());
            return employee;
        }

        // POST api/employees
        public async Task PostAsync(Employee employee)
        {
            await EmployeerLib.InsertEmployee(employee);
        }

        // PUT api/employees/5
        public async Task Put(int id, [FromBody]Employee employee)
        {
            await EmployeerLib.UpdateEmployee(employee);
        }

        // DELETE api/employees/5
        public async Task Delete(string id)
        {
            await EmployeerLib.DeleteEmployee(id);
        }
    }
}
