using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class FundPriceHistoryDataController : ApiController
    {
        //public async void PostAsync([FromBody]string value)
        // In case there is a POST request, to API/Fund, we refresh the fund prices
        public async Task PostAsync()
        {
            var fundLib = new FundPriceHistoryLib();
            await fundLib.RefreshCurrentFundPrices();
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // TODO: Add Get for fund prices
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
