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
//using System.Web.Http;

namespace VestHQWeb.Controllers
{
    public class StockPriceHistoryController : Controller
    {
        // GET: StockPriceHistory
        public async Task<ActionResult> Index()
        {
            var stockPriceHistorys = await StockPriceHistoryLib.GetAllStockPriceHistorys();
            return View(stockPriceHistorys);
        }

        // GET: StockPriceHistory/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var stockPriceHistory = await StockPriceHistoryLib.GetStockPriceHistory(id.ToString());
            if (stockPriceHistory == null)
            {
                var errorMsg = string.Format("StockPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stockPriceHistory);
        }

        // GET: StockPriceHistory/Create
        public async Task<ActionResult> Create()
        {
            var stockPriceHistory = new StockPriceHistory();
            return View(stockPriceHistory);
        }

        // POST: StockPriceHistory/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var rand = new Random();
                var id = rand.Next().ToString();
                var ticker = collection["Ticker"].ToString();
                var tickerPrice = Convert.ToDouble (collection["Ticker"]);
                var time = Convert.ToDateTime (collection["Time"]);
                var stockPriceHistory = new StockPriceHistory()
                {
                    Id = id,
                    Ticker = ticker,
                    TickerPrice = tickerPrice,
                    Time = time
                };
                await StockPriceHistoryLib.InsertStockPriceHistory(stockPriceHistory);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StockPriceHistory/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var stockPriceHistory = await StockPriceHistoryLib.GetStockPriceHistory(id.ToString());
            if (stockPriceHistory == null)
            {
                var errorMsg = string.Format("StockPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stockPriceHistory);
        }

        // POST: StockPriceHistory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                var ticker = collection["Ticker"].ToString();
                var tickerPrice = Convert.ToDouble(collection["Ticker"]);
                var time = Convert.ToDateTime(collection["Time"]);
                var stockPriceHistory = new StockPriceHistory()
                {
                    Id = id,
                    Ticker = ticker,
                    TickerPrice = tickerPrice,
                    Time = time
                };

                //var stockPriceHistoryName = collection["StockPriceHistoryName"].ToString();
                //var stockPriceHistory = new StockPriceHistory()
                //{
                //    Id = id,
                //    StockPriceHistoryName = stockPriceHistoryName
                //};
                await StockPriceHistoryLib.UpdateStockPriceHistory(stockPriceHistory);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StockPriceHistory/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var stockPriceHistory = await StockPriceHistoryLib.GetStockPriceHistory(id);
            if (stockPriceHistory == null)
            {
                var errorMsg = string.Format("StockPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(stockPriceHistory);
        }

        // POST: StockPriceHistory/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                await StockPriceHistoryLib.DeleteStockPriceHistory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
