using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDAL;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class CustomerLib
    {
        public async static Task InsertCustomer(Customer customer)
        {
            await CustomerDataAccess.InsertData(customer);
        }

        public async static Task UpdateCustomer(Customer customer)
        {
            await CustomerDataAccess.UpdateData(customer);
        }

        public async static Task DeleteCustomer(int id)
        {
            await CustomerDataAccess.DeleteData(id);
        }

        public static Task<List<Customer>> GetAllCustomers()
        {
            var customers = CustomerDataAccess.GetAllCustomers();
            return customers;
        }

        public static async Task<Customer> GetCustomer(string id)
        {
            var customer = await CustomerDataAccess.GetCustomerById(id);
            return customer;
        }



    }
}
