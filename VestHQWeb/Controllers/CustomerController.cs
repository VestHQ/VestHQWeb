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
    public class CustomerController : ApiController
    {

        // GET api/customers
        public async Task<List<Customer>> Get()
        {
            var allCustomers =  await CustomerLib.GetAllCustomers();
            return allCustomers;
        }

        // GET api/customers/5
        public async Task<Customer> Get(int id)
        {
            var customer = await CustomerLib.GetCustomer(id.ToString());
            return customer;
        }

        // POST api/customers
        public async Task PostAsync(Customer customer)
        {
            await CustomerLib.InsertCustomer(customer);
        }

        // PUT api/customers/5
        public async Task Put(int id, [FromBody]Customer customer)
        {
            await CustomerLib.UpdateCustomer(customer);
        }

        // DELETE api/customers/5
        public async Task Delete(int id)
        {
            await CustomerLib.DeleteCustomer(id);
        }
    }
}
