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
    public class EmployerController : Controller
    {
        // GET: Employer
        public async Task<ActionResult> Index()
        {
            var employers = await EmployerLib.GetAllEmployers();
            return View(employers);
        }

        // GET: Employer/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var employer = await EmployerLib.GetEmployer(id.ToString());
            if (employer == null)
            {
                var errorMsg = string.Format("Employer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(employer);
        }

        // GET: Employer/Create
        public async Task<ActionResult> Create()
        {
            var employer = new Employer();
            return View(employer);
        }

        // POST: Employer/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var rand = new Random();
                var id = rand.Next().ToString();
                var employerName= collection["EmployerName"].ToString();
                var employer = new Employer()
                {
                    Id = id,
                    EmployerName = employerName
                };
                await EmployerLib.InsertEmployer(employer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employer/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var employer = await EmployerLib.GetEmployer(id.ToString());
            if (employer == null)
            {
                var errorMsg = string.Format("Employer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(employer);
        }

        // POST: Employer/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                var employerName = collection["EmployerName"].ToString();
                var employer = new Employer()
                {
                    Id = id,
                    EmployerName = employerName
                };
                await EmployerLib.UpdateEmployer(employer);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();  
            }
        }

        // GET: Employer/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var employer = await EmployerLib.GetEmployer(id);
            if (employer == null)
            {
                var errorMsg = string.Format("Employer {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(employer);
        }

        // POST: Employer/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                await EmployerLib.DeleteEmployer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
