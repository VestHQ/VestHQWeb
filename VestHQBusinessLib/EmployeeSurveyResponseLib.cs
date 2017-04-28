using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class EmployeeSurveyResponseLib
    {
        public async static Task InsertEmployeeSurveyResponse(EmployeeSurveyResponse employeeSurveyResponse)
        {
            await EmployeeSurveyResponseDataAccess.InsertData(employeeSurveyResponse);
        }

        public async static Task UpdateEmployeeSurveyResponse(EmployeeSurveyResponse employeeSurveyResponse)
        {
            await EmployeeSurveyResponseDataAccess.UpdateData(employeeSurveyResponse);
        }

        public async static Task DeleteEmployeeSurveyResponse(string id)
        {
            await EmployeeSurveyResponseDataAccess.DeleteData(id);
        }

        public static Task<List<EmployeeSurveyResponse>> GetAllEmployeeSurveyResponses()
        {
            var employeeSurveyResponses = EmployeeSurveyResponseDataAccess.GetAllEmployeeSurveyResponses();
            return employeeSurveyResponses;
        }

        public static async Task<EmployeeSurveyResponse> GetEmployeeSurveyResponse(string id)
        {
            var employeeSurveyResponse = await EmployeeSurveyResponseDataAccess.GetEmployeeSurveyResponseById(id);
            return employeeSurveyResponse;
        }

    }
}
