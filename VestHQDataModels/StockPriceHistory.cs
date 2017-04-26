using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQDataModels
{
    public class StockPriceHistory
    {
        [Key()]
        public string Id { get; set; }

        [ForeignKey("Stock")]
        public string StockId { get; set; }

        public DateTime Time { get; set; }

        public string Ticker { get; set; }
        public double TickerPrice { get; set; }


    }
}