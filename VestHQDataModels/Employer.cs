using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [StringLength(200), DisplayName("Employer Name")]
        public string EmployerName { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
