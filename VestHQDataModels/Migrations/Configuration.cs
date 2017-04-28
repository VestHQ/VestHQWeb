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

            var funds = new List<Fund>
            {
                new Fund {Id="00001",Name="Vanguard2 Total Fund Market ETF", Ticker="VTI",  },
                new Fund {Id="00002",Name="Vanguard2 S&P 500 ETF", Ticker="VOO",  },
                new Fund {Id="00003",Name="Vanguard2 Mega Cap ETF", Ticker="MGC" }
            };
            funds.ForEach(s => context.Funds.AddOrUpdate(p => p.Ticker, s));
            context.SaveChanges();

            var surveyQuestions = new List<SurveyQuestion>
            {
                new SurveyQuestion {Text="How confident do you feel about retirement?", Order=1, Id="001"},
                new SurveyQuestion {Text="Adding up all your accounts (cash, savings/checking accounts, mutual funds, stocks, etc.), what is the total value of your money?", Order=2, Id="002"},
                new SurveyQuestion {Text="If the market were to go into another recession over the next decade, how would you expect your 401(k) to turn out?", Order=3, Id="003"},
                new SurveyQuestion {Text="If a friend or family member described you, they would say you are:", Order=4, Id="004"},
                new SurveyQuestion {Text="Imagine you invested $1000 over five years. Which outcome would you rather see?", Order=5, Id="005"},
                new SurveyQuestion {Text="Would you rather have a stable job for the rest of your career and keep your current salary, or would you rather get a new job that increases your salary 10% a year but you don’t know how long you’ll be able to keep that job?", Order=6, Id="006"}
            };

            surveyQuestions.ForEach(s => context.SurveyQuestions.AddOrUpdate(p => p.Text, s));
            context.SaveChanges();

            var surveyAnswers = new List<SurveyAnswer>
            {
                new SurveyAnswer {Text="Confident", SurveyQuestionId="001", Order=1, Id="001"},
                new SurveyAnswer {Text="Comfortable", SurveyQuestionId="001", Order=2, Id="002"},
                new SurveyAnswer {Text="Neutral", SurveyQuestionId="001", Order=3, Id="003"},
                new SurveyAnswer {Text="Worried", SurveyQuestionId="001", Order=4, Id="004"},
                new SurveyAnswer {Text="Panicked", SurveyQuestionId="001", Order=5, Id="005"},


                new SurveyAnswer {Text="less than $5,000", SurveyQuestionId="002", Order=1, Id="006"},
                new SurveyAnswer {Text="$5,000 - $10,000", SurveyQuestionId="002", Order=2, Id="007"},
                new SurveyAnswer {Text="$10,000 - $50,000", SurveyQuestionId="002", Order=3, Id="008"},
                new SurveyAnswer {Text="$50,000 - $100,000", SurveyQuestionId="002", Order=4, Id="009"},
                new SurveyAnswer {Text="$100,000 - $250,000", SurveyQuestionId="002", Order=5, Id="010"},
                new SurveyAnswer {Text="$250,000+", SurveyQuestionId="002", Order=5, Id="011"},

                new SurveyAnswer {Text="Lose a lot of money", SurveyQuestionId="003", Order=1, Id="012"},
                new SurveyAnswer {Text="Lose a little money", SurveyQuestionId="003", Order=2, Id="013"},
                new SurveyAnswer {Text="Keep around the same levels", SurveyQuestionId="003", Order=3, Id="014"},
                new SurveyAnswer {Text="Make a little more than deposited", SurveyQuestionId="003", Order=4, Id="015"},
                new SurveyAnswer {Text="Make more than the market", SurveyQuestionId="003", Order=5, Id="016"},

                new SurveyAnswer {Text="Pretty cautious", SurveyQuestionId="004", Order=1, Id="017"},
                new SurveyAnswer {Text="In the middle", SurveyQuestionId="004", Order=2, Id="018"},
                new SurveyAnswer {Text="A risk-taker", SurveyQuestionId="004", Order=3, Id="019"},
          
                new SurveyAnswer {Text="Have a chance to grow or lose 12%, ending with either $1762 or $527", SurveyQuestionId="005", Order=1, Id="020"},
                new SurveyAnswer {Text="Have a chance to grow or lose 8%, ending with either $1470 or $660", SurveyQuestionId="005", Order=2, Id="021"},
                new SurveyAnswer {Text="Have a chance to grow or lose 2%, ending with either $1105 or $904", SurveyQuestionId="005", Order=3, Id="022"},

                new SurveyAnswer {Text="I would for sure pick the safe job with the same salary", SurveyQuestionId="006", Order=1, Id="023"},
                new SurveyAnswer {Text="I would probably pick the safe job with the same salary", SurveyQuestionId="006", Order=2, Id="024"},
                new SurveyAnswer {Text="Not sure", SurveyQuestionId="006", Order=3, Id="025"},
                new SurveyAnswer {Text="I would probably pick the 10% salary increase but less stable job", SurveyQuestionId="006", Order=4, Id="026"},
                new SurveyAnswer {Text="I would for sure pick the 10% salary increase but less stable job", SurveyQuestionId="006", Order=5, Id="027"},
            };

            surveyAnswers.ForEach(s => context.SurveyAnswers.AddOrUpdate(p => p.Text, s));
            context.SaveChanges();

            /*
            var fundhistories = new List<FundPriceHistory>
            {
                new FundPriceHistory {Id="", FundId="", Ticker="", TickerPrice=0, Time=DateTime.Now }
            };

            foreach (FundPriceHistory sh in fundhistories)
            {
                var fundhistoryInDataBase = context.FundPriceHistories.Where(
                    s =>
                         s.FundId == sh.FundId &&
                         s.Time == sh.Time).SingleOrDefault();
                if (fundhistoryInDataBase == null)
                {
                    context.FundPriceHistories.Add(sh);
                }
            }
            context.SaveChanges();

            var holdings = new List<Holding>
            {
                new Holding {Id="", EmployeeId="", FundId="", SharesOwned=0 }
            };

            foreach (Holding h in holdings)
            {
                var holdingInDataBase = context.Holdings.Where(
                    s =>
                         s.FundId == h.FundId &&
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
