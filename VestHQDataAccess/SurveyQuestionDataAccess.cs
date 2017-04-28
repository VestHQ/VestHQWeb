using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public static class SurveyQuestionDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(SurveyQuestion surveyQuestion)
        {
            db.SurveyQuestions.Add(surveyQuestion);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(SurveyQuestion surveyQuestion)
        {
            db.Entry(surveyQuestion).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public static async Task<SurveyQuestion> DeleteData(string id)
        {
            var surveyQuestion = await GetSurveyQuestionById(id);
            return await DeleteData(surveyQuestion);
        }

        public static async Task<SurveyQuestion> DeleteData(SurveyQuestion surveyQuestion)
        {
            return await db.SurveyQuestions.FindAsync(surveyQuestion.Id);
        }

        public static async Task<SurveyQuestion> GetSurveyQuestionById(string id)
        {
            SurveyQuestion surveyQuestion 
                = db.SurveyQuestions.AsNoTracking()
                .Where(s=>s.Id == id)
                .FirstOrDefault();

            return surveyQuestion;
        }

        public static async Task<List<SurveyQuestion>> GetAllSurveyQuestions()
        {
            return await db.SurveyQuestions.AsNoTracking().ToListAsync();
        }

    }
}
