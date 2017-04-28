using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VestHQBusinessLib;
using VestHQDataModels;

namespace VestHQWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var employees = await EmployeerLib.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployerEmployees/001
        public async Task<ActionResult> EmployerEmployees(string id)
        {
            var employees = await EmployeerLib.GetAllEmployeesForEmployer(id);
            return View("Index", employees);
        }


        // GET: Employee/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var employee = await EmployeerLib.GetEmployee(id.ToString());
            if (employee == null)
            {
                var errorMsg = string.Format("Employee {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(employee);
        }

        // GET: Employee/Create
        public async Task<ActionResult> Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var rand = new Random();
                var id = rand.Next().ToString();
                var firstName = collection["FirstName"].ToString();
                var lastName = collection["LastName"].ToString();
                var employee = new Employee()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    EmployerId = "001",
                    TwitterAccount = ""
                };
                await EmployeerLib.InsertEmployee(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                var employees = await EmployeerLib.GetAllEmployees();
                return View("Index", employees);
            }
            var employee = await EmployeerLib.GetEmployee(id.ToString());
            if (employee == null)
            {
                var errorMsg = string.Format("Employee {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }

            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                var firstName = collection["FirstName"].ToString();
                var lastName = collection["LastName"].ToString();
                var employerId = collection["EmployerId"]?.ToString();
                var twitterAccount = collection["TwitterAccount"]?.ToString();
                var employee = new Employee()
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    EmployerId = employerId,
                    TwitterAccount = twitterAccount
                };
                await EmployeerLib.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var employee = await EmployeerLib.GetEmployee(id);
            if (employee == null)
            {
                var errorMsg = string.Format("Employee {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                await EmployeerLib.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
