using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestHQDataModels
{
    public class Holding
    {
        //[Key]
        //public string Id { get; set; }

        [Key]
        [ForeignKey("Stock")]
        public string StockId { get; set; }

        [Key]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        public Stock Stock { get; set; }
        public Customer Customer { get; set; }

        public int SharesOwned { get; set; }


    }
}
