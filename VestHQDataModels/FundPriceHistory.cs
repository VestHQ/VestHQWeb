using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQDataModels
{
    public class FundPriceHistory
    {
        [Key()]
        public string Id { get; set; }

        [ForeignKey("Fund"), DisplayName("Fund Id")]
        public string FundId { get; set; }

        [DisplayName("Time retrieved")]
        public DateTime Time { get; set; }

        public string Ticker { get; set; }
        [DisplayName("Price")]
        public double TickerPrice { get; set; }

        public Fund Fund { get; set; }


    }
}