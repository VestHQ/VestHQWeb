using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VestHQBusinessLib;
using VestHQDataModels;

namespace VestHQWeb.Controllers
{
    public class CustController : Controller
    {
        // GET: Cust
        public async Task<ActionResult> Index()
        {
            var customers = await CustomerLib.GetAllCustomers();
            return View(customers);
        }

        // GET: Cust/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var customer = await CustomerLib.GetCustomer(id.ToString());
            if (customer == null)
            {
                var errorMsg = string.Format("Customer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(customer);
        }

        // GET: Cust/Create
        public async Task<ActionResult> Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        // POST: Cust/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var rand = new Random();
                var id = rand.Next().ToString();
                var firstName = collection["FirstName"].ToString();
                var lastName = collection["LastName"].ToString();
                var customer = new Customer()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    EmployerId = "1" 
                };
                await CustomerLib.InsertCustomer(customer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Cust/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var customer = await CustomerLib.GetCustomer(id.ToString());
            if (customer == null)
            {
                var errorMsg = string.Format("Customer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }

            return View(customer);
        }

        // POST: Cust/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                var firstName = collection["FirstName"].ToString();
                var lastName = collection["LastName"].ToString();
                var employeeId = "1";
                var customer = new Customer()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    EmployerId = employeeId
                };
                await CustomerLib.UpdateCustomer(customer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Cust/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var customer = await CustomerLib.GetCustomer(id);
            if (customer == null)
            {
                var errorMsg = string.Format("Customer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(customer);
        }

        // POST: Cust/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                await CustomerLib.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
