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
    public class StockController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stocks
        public async Task<ActionResult> Index()
        {
            var stocks = await StockLib.GetAllStocks();
            return View(stocks);
        }

        // GET: Stocks/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var stock = await StockLib.GetStock(id.ToString());
            if (stock == null)
            {
                var errorMsg = string.Format("Stock {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            var stock = new Stock();
            return View(stock);
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Ticker")] Stock stock)
        {
            try
            {
               var rand = new Random();
                var id = rand.Next().ToString();
                stock.Id = id;
                //var stockName = collection["StockName"].ToString();
                //var symbol = co
                //var stock = new Stock()
                //{
                //    Id = id,
                //    Name = stockName,
                //    Symbol
                //};
                await StockLib.InsertStock(stock);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Stocks/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var stock = await StockLib.GetStock(id.ToString());
            if (stock == null)
            {
                var errorMsg = string.Format("Stock {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Ticker")] Stock stock)
        {
            try
            {
                //var stockName = collection["StockName"].ToString();
                //var stock = new Stock()
                //{
                //    Id = id,
                //    StockName = stockName
                //};
                await StockLib.UpdateStock(stock);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Stocks/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var stock = await StockLib.GetStock(id);
            if (stock == null)
            {
                var errorMsg = string.Format("Stock {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await StockLib.DeleteStock(id);

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
