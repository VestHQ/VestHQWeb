using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataModels;
using System.Data.Entity;

namespace VestHQDataAccess
{
    public class EmployeeSurveyResponseDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(EmployeeSurveyResponse employeeSurveyResponse)
        {
            db.EmployeeSurveyResponses.Add(employeeSurveyResponse);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(EmployeeSurveyResponse employeeSurveyResponse)
        {
            //var item = await GetEmployeeSurveyResponseById(employeeSurveyResponse.Id);

            //item.Answer = employeeSurveyResponse.Answer;
            //item.EmployeeId = employeeSurveyResponse.EmployeeId;
            //item.Id = employeeSurveyResponse.Id;
            //item.SurveyQuestionId = employeeSurveyResponse.SurveyQuestionId;

            await db.SaveChangesAsync();
        }

        public static async Task DeleteData(string id)
        {
            var employeeSurveyResponse = await GetEmployeeSurveyResponseById(id);
            await DeleteData(employeeSurveyResponse);
        }

        public static async Task DeleteData(EmployeeSurveyResponse employeeSurveyResponse)
        {
            db.EmployeeSurveyResponses.Remove(employeeSurveyResponse);
            await db.SaveChangesAsync();
        }

        public static async Task<EmployeeSurveyResponse> GetEmployeeSurveyResponseById(string id)
        {
            return db.EmployeeSurveyResponses
                .Include(esr => esr.SurveyQuestion)
                .Include(esr => esr.Employee)
                .Where(e => e.Id == id)
                .FirstOrDefault();

        }

        public static async Task<List<EmployeeSurveyResponse>> GetAllEmployeeSurveyResponses()
        {
            return await db.EmployeeSurveyResponses
                .Include(esr => esr.SurveyQuestion)
                .Include(esr => esr.Employee)
                .AsNoTracking().ToListAsync();

        }

        public static async Task<List<EmployeeSurveyResponse>> GetAllEmployeeSurveyResponsesForEmployee(string employeeId)
        {
            return await db.EmployeeSurveyResponses
                .Include(esr => esr.SurveyQuestion)
                .Include(esr => esr.Employee)
                .Where(e => e.EmployeeId == employeeId)
                .AsNoTracking().ToListAsync();
        }

    }
}
