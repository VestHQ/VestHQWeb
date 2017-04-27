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
    public class FundPriceHistoryController : Controller
    {
        // GET: FundPriceHistory
        public async Task<ActionResult> Index()
        {
            var fundPriceHistorys = await FundPriceHistoryLib.GetAllFundPriceHistorys();
            return View(fundPriceHistorys);
        }

        // GET: FundPriceHistory/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var fundPriceHistory = await FundPriceHistoryLib.GetFundPriceHistory(id.ToString());
            if (fundPriceHistory == null)
            {
                var errorMsg = string.Format("FundPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fundPriceHistory);
        }

        // GET: FundPriceHistory/Create
        public async Task<ActionResult> Create()
        {
            var fundPriceHistory = new FundPriceHistory();
            return View(fundPriceHistory);
        }

        // POST: FundPriceHistory/Create
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
                var fundPriceHistory = new FundPriceHistory()
                {
                    Id = id,
                    Ticker = ticker,
                    TickerPrice = tickerPrice,
                    Time = time
                };
                await FundPriceHistoryLib.InsertFundPriceHistory(fundPriceHistory);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: FundPriceHistory/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var fundPriceHistory = await FundPriceHistoryLib.GetFundPriceHistory(id.ToString());
            if (fundPriceHistory == null)
            {
                var errorMsg = string.Format("FundPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fundPriceHistory);
        }

        // POST: FundPriceHistory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                var ticker = collection["Ticker"].ToString();
                var tickerPrice = Convert.ToDouble(collection["Ticker"]);
                var time = Convert.ToDateTime(collection["Time"]);
                var fundPriceHistory = new FundPriceHistory()
                {
                    Id = id,
                    Ticker = ticker,
                    TickerPrice = tickerPrice,
                    Time = time
                };

                //var fundPriceHistoryName = collection["FundPriceHistoryName"].ToString();
                //var fundPriceHistory = new FundPriceHistory()
                //{
                //    Id = id,
                //    FundPriceHistoryName = fundPriceHistoryName
                //};
                await FundPriceHistoryLib.UpdateFundPriceHistory(fundPriceHistory);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: FundPriceHistory/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var fundPriceHistory = await FundPriceHistoryLib.GetFundPriceHistory(id);
            if (fundPriceHistory == null)
            {
                var errorMsg = string.Format("FundPriceHistory {0} not found.", id);
                throw new HttpException(404, errorMsg);
            }
            return View(fundPriceHistory);
        }

        // POST: FundPriceHistory/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            try
            {
                await FundPriceHistoryLib.DeleteFundPriceHistory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
