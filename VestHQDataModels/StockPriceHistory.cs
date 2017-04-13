using System;

namespace VestHQDataModels
{
    public class StockPriceHistory
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }

        public string Ticker { get; set; }
        public double TickerPrice { get; set; }


    }
}