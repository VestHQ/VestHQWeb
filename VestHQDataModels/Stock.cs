using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VestHQDataModels
{
    public class Stock
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }

        public string Ticker { get; set; }
        public double TickerPrice { get; set; }


    }
}