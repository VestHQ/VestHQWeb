using System;
using System.Collections.Generic;
using System.Linq;
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
                //var id = new Guid().ToString();
                var firstName = collection["FirstName"].ToString();
                var lastName = collection["LastName"].ToString();
                var customer = new Customer() { Id = id, FirstName = firstName, LastName = lastName };
                await CustomerLib.InsertCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cust/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var customer = await CustomerLib.GetCustomer(id.ToString());
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
                var customer = new Customer() { Id = id, FirstName = firstName, LastName = lastName };
                await CustomerLib.UpdateCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cust/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Cust/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
