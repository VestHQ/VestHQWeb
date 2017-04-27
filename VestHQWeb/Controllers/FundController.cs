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
using VestHQWeb.Models;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class FundController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Funds
        public async Task<ActionResult> Index()
        {
            var funds = await FundLib.GetAllFunds();
            return View(funds);
        }

        // GET: Funds/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var fund = await FundLib.GetFund(id.ToString());
            if (fund == null)
            {
                var errorMsg = string.Format("Fund {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fund);
        }

        // GET: Funds/Create
        public ActionResult Create()
        {
            var fund = new Fund();
            return View(fund);
        }

        // POST: Funds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Ticker")] Fund fund)
        {
            try
            {
               var rand = new Random();
                var id = rand.Next().ToString();
                fund.Id = id;
                //var fundName = collection["FundName"].ToString();
                //var symbol = co
                //var fund = new Fund()
                //{
                //    Id = id,
                //    Name = fundName,
                //    Symbol
                //};
                await FundLib.InsertFund(fund);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Funds/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var fund = await FundLib.GetFund(id.ToString());
            if (fund == null)
            {
                var errorMsg = string.Format("Fund {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fund);
        }

        // POST: Funds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Ticker")] Fund fund)
        {
            try
            {
                //var fundName = collection["FundName"].ToString();
                //var fund = new Fund()
                //{
                //    Id = id,
                //    FundName = fundName
                //};
                await FundLib.UpdateFund(fund);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Funds/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var fund = await FundLib.GetFund(id);
            if (fund == null)
            {
                var errorMsg = string.Format("Fund {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fund);
        }

        // POST: Funds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await FundLib.DeleteFund(id);

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
