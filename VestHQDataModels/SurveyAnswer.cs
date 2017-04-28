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
    public class SurveyAnswer
    {
        [Key()]
        public string Id { get; set; }

        [ForeignKey("SurveyQuestion")]
        public string SurveyQuestionId { get; set; }

        public SurveyQuestion SurveyQuestion { get; set; }


        [DisplayName("Answer"), Required]
        public string Text { get; set; }

        [Required]
        public int Order { get; set; }


    }
}
