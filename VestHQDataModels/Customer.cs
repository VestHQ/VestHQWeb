using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestHQDataModels
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }

        [StringLength(50), Required]
        public string FirstName { get; set; }

        [StringLength(50), Required]
        public string LastName { get; set; }

        [StringLength(200)]
        public string TwitterAccount { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }

        public Employer Employer { get; set; }

    }
}
