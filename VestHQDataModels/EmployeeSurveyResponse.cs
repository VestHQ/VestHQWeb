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
    public class EmployeeSurveyResponse
    {
        [Key()]
        public string Id { get; set; }

        [ForeignKey("Employee"), DisplayName("Employee ID")]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }


        [ForeignKey("SurveyQuestion"), DisplayName("Question Id")]
        public string SurveyQuestionId { get; set; }
        public SurveyQuestion SurveyQuestion { get; set; }


        [Required]
        public string Answer { get; set; }

    }
}
