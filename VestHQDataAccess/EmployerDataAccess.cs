using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VestHQDataModels;

namespace VestHQDataAccess
{
    public class EmployerDataAccess
    {
        private static VestHQDbContext db = new VestHQDbContext();

        public static async Task InsertData(Employer employer)
        {
            db.Employers.Add(employer);
            await db.SaveChangesAsync();
        }

        public static async Task UpdateData(Employer employer)
        {
            var item = await GetEmployerById(employer.Id);
            item.EmployerName = employer.EmployerName;
            //db.Entry(employer).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
 
        public static async Task DeleteData(string id)
        {
            var employer = await GetEmployerById(id);
            await DeleteData(employer);
        }

        public static async Task DeleteData(Employer employer)
        {
            db.Employers.Remove(employer);
            await db.SaveChangesAsync();
         }

        public static async Task<Employer> GetEmployerById(string id)
        {
            return await db.Employers.FindAsync(id);

            /*var employer = await db.Employers.Where(c => c.Id == id).ToListAsync();
            return employer.FirstOrDefault();*/
        }

        public static async Task<List<Employer>> GetAllEmployers()
        {
            return await db.Employers.AsNoTracking().ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
