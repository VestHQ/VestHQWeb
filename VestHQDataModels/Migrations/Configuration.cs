namespace VestHQDataModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<VestHQDataModels.VestHQDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VestHQDataModels.VestHQDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var employers = new List<Employer>
            {
                new Employer {EmployerName ="TestCompany2", Id="001" }
            };
            employers.ForEach(s => context.Employers.AddOrUpdate(p => p.EmployerName, s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee {Id="00001", EmployerId="001", FirstName = "2Gianni", LastName = "Chen" },
                new Employee {Id="00002", EmployerId="001", FirstName = "2David", LastName = "Giard" }
            };

            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var stocks = new List<Stock>
            {
                new Stock {Id="00001",Name="Vanguard2 Total Stock Market ETF", Ticker="VTI",  },
                new Stock {Id="00002",Name="Vanguard2 S&P 500 ETF", Ticker="VOO",  },
                new Stock {Id="00003",Name="Vanguard2 Mega Cap ETF", Ticker="MGC" }
            };

            stocks.ForEach(s => context.Stocks.AddOrUpdate(p => p.Ticker, s));
            context.SaveChanges();

            /*
            var stockhistories = new List<StockPriceHistory>
            {
                new StockPriceHistory {Id="", StockId="", Ticker="", TickerPrice=0, Time=DateTime.Now }
            };

            foreach (StockPriceHistory sh in stockhistories)
            {
                var stockhistoryInDataBase = context.StockPriceHistories.Where(
                    s =>
                         s.StockId == sh.StockId &&
                         s.Time == sh.Time).SingleOrDefault();
                if (stockhistoryInDataBase == null)
                {
                    context.StockPriceHistories.Add(sh);
                }
            }
            context.SaveChanges();

            var holdings = new List<Holding>
            {
                new Holding {Id="", EmployeeId="", StockId="", SharesOwned=0 }
            };

            foreach (Holding h in holdings)
            {
                var holdingInDataBase = context.Holdings.Where(
                    s =>
                         s.StockId == h.StockId &&
                         s.EmployeeId == h.EmployeeId).SingleOrDefault();
                if (holdingInDataBase == null)
                {
                    context.Holdings.Add(h);
                }
            }
            context.SaveChanges(); */

        }
    }
}
