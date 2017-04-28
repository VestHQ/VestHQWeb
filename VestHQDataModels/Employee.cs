using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestHQDataModels
{
    public class Employee
    {
        [Key]
        public string Id { get; set; }

        [StringLength(50), Required, DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50), Required, DisplayName("Last Name")]
        public string LastName { get; set; }

        [StringLength(200), DisplayName("Twitter Account")]
        public string TwitterAccount { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }


        [ForeignKey("Employer")]
        public string EmployerId { get; set; }

        public Employer Employer { get; set; }

        [DisplayName("Employee Name")]
        public string FullName
        {
            get
            {
                return (this.FirstName + " " + this.LastName).Trim();
            }
        }

    }
}
