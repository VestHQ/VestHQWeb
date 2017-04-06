using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class StockController : ApiController
    {
        //public async void PostAsync([FromBody]string value)
        public async Task PostAsync()
        {
            var stockLib = new StockLib();
            await stockLib.RefreshCurrentStockPrices();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
