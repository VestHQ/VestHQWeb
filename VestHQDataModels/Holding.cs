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
        [Key]
        public string Id { get; set; } 

        /*[Key]
        [Column(Order = 0)]*/
        [ForeignKey("Fund")]
        public string FundId { get; set; }

        /*[Key]
        [Column(Order = 1)]*/
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }

        public Fund Fund { get; set; }
        public Employee Employee { get; set; }

        public int SharesOwned { get; set; }


    }
}
