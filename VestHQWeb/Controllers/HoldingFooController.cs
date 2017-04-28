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

namespace VestHQWeb.Controllers
{
    public class HoldingFooController : Controller
    {
        private VestHQDbContext db = new VestHQDbContext();

        // GET: HoldingFoo
        public async Task<ActionResult> Index()
        {
            var holdings = db.Holdings.Include(h => h.Employee).Include(h => h.Fund);
            return View(await holdings.ToListAsync());
        }

        // GET: HoldingFoo/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holding holding = await db.Holdings.FindAsync(id);
            if (holding == null)
            {
                return HttpNotFound();
            }
            return View(holding);
        }

        // GET: HoldingFoo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.FundId = new SelectList(db.Funds, "Id", "Name");
            return View();
        }

        // POST: HoldingFoo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FundId,EmployeeId,SharesOwned")] Holding holding)
        {
            if (ModelState.IsValid)
            {
                db.Holdings.Add(holding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", holding.EmployeeId);
            ViewBag.FundId = new SelectList(db.Funds, "Id", "Name", holding.FundId);
            return View(holding);
        }

        // GET: HoldingFoo/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holding holding = await db.Holdings.FindAsync(id);
            if (holding == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", holding.EmployeeId);
            ViewBag.FundId = new SelectList(db.Funds, "Id", "Name", holding.FundId);
            return View(holding);
        }

        // POST: HoldingFoo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FundId,EmployeeId,SharesOwned")] Holding holding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holding).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", holding.EmployeeId);
            ViewBag.FundId = new SelectList(db.Funds, "Id", "Name", holding.FundId);
            return View(holding);
        }

        // GET: HoldingFoo/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Holding holding = await db.Holdings.FindAsync(id);
            if (holding == null)
            {
                return HttpNotFound();
            }
            return View(holding);
        }

        // POST: HoldingFoo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Holding holding = await db.Holdings.FindAsync(id);
            db.Holdings.Remove(holding);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
