using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VestHQDAL;
using VestHQDataAccess;
using VestHQDataModels;

namespace VestHQBusinessLib
{
    public class EmployerLib
    {
        public async static Task InsertEmployer(Employer employer)
        {
            await EmployerDataAccess.InsertData(employer);
        }

        public async static Task UpdateEmployer(Employer employer)
        {
            await EmployerDataAccess.UpdateData(employer);
        }

        public async static Task DeleteEmployer(string id)
        {
            await EmployerDataAccess.DeleteData(id);
        }

        public static Task<List<Employer>> GetAllEmployers()
        {
            var employers = EmployerDataAccess.GetAllEmployers();
            return employers;
        }

        public static async Task<Employer> GetEmployer(string id)
        {
            var employer = await EmployerDataAccess.GetEmployerById(id);
            return employer;
        }

    }
}
