using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestHQDataModels
{
    public class SurveyQuestion
    {
        [Key()]
        public string Id { get; set; }

        [DisplayName("Question")]
        public string Text { get; set; }

        [Required]
        public int Order { get; set; }


    }
}
