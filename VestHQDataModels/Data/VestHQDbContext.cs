using System.Data.Entity;
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
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPriceHistory> StockPriceHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Employer>().ToTable("Employer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Holding>().ToTable("Holding");
            modelBuilder.Entity<StockPriceHistory>().ToTable("StockPriceHistory");

            /*
            modelBuilder.Entity<StockPriceHistory>(entity =>
            {
                entity.HasKey(e => e.Id)
                .ForSqlServerIsClustered(false);
                
                entity.HasIndex(e => new { e.StockId, e.Date })
                     .IsUnique()
                     .ForSqlServerIsClustered(true)
                     .HasName("IX_StockPriceHistory_StockDate");
            }); */
        }
    }
}
