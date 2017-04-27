using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VestHQDAL;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class StockLib
    {
        public async static Task InsertStock(Stock stock)
        {
            await StockDataAccess.InsertData(stock);
        }

        public async static Task UpdateStock(Stock stock)
        {
            await StockDataAccess.UpdateData(stock);
        }

        public async static Task DeleteStock(string id)
        {
            await StockDataAccess.DeleteData(id);
        }

        public static Task<List<Stock>> GetAllStocks()
        {
            var stocks = StockDataAccess.GetAllStocks();
            return stocks;
        }

        public static async Task<Stock> GetStock(string id)
        {
            var stock = await StockDataAccess.GetStockById(id);
            return stock;
        }

    }
}
