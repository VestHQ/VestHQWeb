namespace VestHQDataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        TwitterAccount = c.String(maxLength: 200),
                        EmployerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employer", t => t.EmployerId)
                .Index(t => t.EmployerId);
            
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployerName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Holding",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StockId = c.String(maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        SharesOwned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Stock", t => t.StockId)
                .Index(t => t.StockId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 200),
                        Ticker = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockPriceHistory",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StockId = c.String(maxLength: 128),
                        Time = c.DateTime(nullable: false),
                        Ticker = c.String(),
                        TickerPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stock", t => t.StockId)
                .Index(t => t.StockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Holding", "StockId", "dbo.Stock");
            DropForeignKey("dbo.StockPriceHistory", "StockId", "dbo.Stock");
            DropForeignKey("dbo.Holding", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "EmployerId", "dbo.Employer");
            DropIndex("dbo.StockPriceHistory", new[] { "StockId" });
            DropIndex("dbo.Holding", new[] { "EmployeeId" });
            DropIndex("dbo.Holding", new[] { "StockId" });
            DropIndex("dbo.Employee", new[] { "EmployerId" });
            DropTable("dbo.StockPriceHistory");
            DropTable("dbo.Stock");
            DropTable("dbo.Holding");
            DropTable("dbo.Employer");
            DropTable("dbo.Employee");
        }
    }
}
