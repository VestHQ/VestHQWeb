using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace VestHQDataModels
{
    public class VestHQContextFactory: IDbContextFactory<VestHQDbContext>
    {
        public VestHQDbContext Create()
        {
            //return new VestHQDbContext("connectionStringName");
            return new VestHQDbContext("Server=(localdb)\\mssqllocaldb;Database=Vest_LocalDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}


