using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class SurveyAnswerDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task<List<SurveyAnswer>> GetAllSurveyAnswers()
        {
            return await db.SurveyAnswers.AsNoTracking().ToListAsync();
        }

        public static async Task<List<SurveyAnswer>> GetAllSurveyAnswersForQuestion(string questionId)
        {
            return await db.SurveyAnswers
                .AsNoTracking()
                .Where(sa=>sa.SurveyQuestionId == questionId)
                .ToListAsync();
        }


    }
}
