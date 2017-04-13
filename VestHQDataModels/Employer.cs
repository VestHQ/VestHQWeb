using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestHQDataModels
{
    public class Employer
    {
        [Key]
        public string Id { get; set; }

        [StringLength(200)]
        public string EmployerName { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
