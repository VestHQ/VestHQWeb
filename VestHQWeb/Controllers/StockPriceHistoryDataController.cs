using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class StockPriceHistoryDataController : ApiController
    {
        //public async void PostAsync([FromBody]string value)
        // In case there is a POST request, to API/Stock, we refresh the stock prices
        public async Task PostAsync()
        {
            var stockLib = new StockPriceHistoryLib();
            await stockLib.RefreshCurrentStockPrices();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // TODO: Add Get for stock prices
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
