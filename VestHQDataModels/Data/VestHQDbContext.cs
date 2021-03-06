﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VestHQDataModels
{
    public class VestHQDbContext : DbContext
    {
        public VestHQDbContext(string connectionString= "name=VestHQConnectionString") : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<FundPriceHistory> FundPriceHistories { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<EmployeeSurveyResponse> EmployeeSurveyResponses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Employer>().ToTable("Employer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Fund>().ToTable("Fund");
            modelBuilder.Entity<Holding>().ToTable("Holding");
            modelBuilder.Entity<FundPriceHistory>().ToTable("FundPriceHistory");
            modelBuilder.Entity<SurveyQuestion>().ToTable("SurveyQuestion");
            modelBuilder.Entity<SurveyAnswer>().ToTable("SurveyAnswer");
            modelBuilder.Entity<EmployeeSurveyResponse>().ToTable("EmployeeSurveyResponse");

        }
    }
}
