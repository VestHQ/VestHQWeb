using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQDataModels
{
    public class FundPriceHistory
    {
        [Key()]
        public string Id { get; set; }

        [ForeignKey("Fund")]
        public string FundId { get; set; }

        public DateTime Time { get; set; }

        public string Ticker { get; set; }
        public double TickerPrice { get; set; }

        public Fund Fund { get; set; }


    }
}