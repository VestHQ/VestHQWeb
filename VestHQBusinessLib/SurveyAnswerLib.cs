using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class SurveyAnswerLib
    {
        public static async Task<List<SurveyAnswer>> GetAllSurveyAnswers()
        {
            return await SurveyAnswerDataAccess.GetAllSurveyAnswers();
        }

        public static async Task<List<SurveyAnswer>> GetAllSurveyAnswersForQuestion(string questionId)
        {
            return await SurveyAnswerDataAccess.GetAllSurveyAnswersForQuestion(questionId);
        }

    }
}
