using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VestHQDataModels;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class HoldingController : Controller
    {
        private VestHQDbContext db = new VestHQDbContext();

        // GET: Holding
        public async Task<ActionResult> Index()
        {
            var holdings = await HoldingLib.GetAllHoldings();
            return View(holdings);
        }

        // GET: Holding/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var holding = await HoldingLib.GetHolding(id.ToString());
            if (holding == null)
            {
                var errorMsg = string.Format("Holding {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(holding);
        }

        // GET: Holding/Create
        public async Task<ActionResult> Create()
        {
            var employeesList = await EmployeerLib.GetAllEmployees();
            var fundsList = await FundLib.GetAllFunds();

            ViewBag.EmployeeId =  new SelectList(employeesList, "Id", "LastName");
            ViewBag.FundId = new SelectList(fundsList, "Id", "Name");
            return View();

        }

        // POST: Holding/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HoldingId,EmployeeId,FundId,SharesOwned")] Holding holding)
        {
            try
            {
                var rand = new Random();
                var id = rand.Next().ToString();
                holding.Id = id;
                await HoldingLib.InsertHolding(holding);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Holding/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var employeesList = await EmployeerLib.GetAllEmployees();
            var fundsList = await FundLib.GetAllFunds();

            var holding = await HoldingLib.GetHolding(id.ToString());
            if (holding == null)
            {
                var errorMsg = string.Format("Holding {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            ViewBag.EmployeeId = new SelectList(employeesList, "Id", "LastName", holding.EmployeeId);
            ViewBag.FundId = new SelectList(fundsList, "Id", "Name", holding.FundId);

            return View(holding);
        }

        // POST: Holding/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HoldingId,EmployeeId,FundId,SharesOwned")] Holding holding)
        {
            try
            {
                await HoldingLib.UpdateHolding(holding);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Holding/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var holding = await HoldingLib.GetHolding(id);
            if (holding == null)
            {
                var errorMsg = string.Format("Holding {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(holding);
        }

        // POST: Holding/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await HoldingLib.DeleteHolding(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
