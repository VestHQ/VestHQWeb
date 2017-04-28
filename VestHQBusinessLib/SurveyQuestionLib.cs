using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class SurveyQuestionLib
    {
        public async static Task InsertSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            await SurveyQuestionDataAccess.InsertData(surveyQuestion);
        }

        public async static Task UpdateSurveyQuestion(SurveyQuestion surveyQuestion)
        {
            await SurveyQuestionDataAccess.UpdateData(surveyQuestion);
        }

        public async static Task<SurveyQuestion> DeleteSurveyQuestion(string id)
        {
            return await SurveyQuestionDataAccess.DeleteData(id);
        }

        public static Task<List<SurveyQuestion>> GetAllSurveyQuestions()
        {
            var surveyQuestions = SurveyQuestionDataAccess.GetAllSurveyQuestions();
            return surveyQuestions;
        }

        public static async Task<SurveyQuestion> GetSurveyQuestion(string id)
        {
            var surveyQuestion = await SurveyQuestionDataAccess.GetSurveyQuestionById(id);
            return surveyQuestion;
        }

    }
}
