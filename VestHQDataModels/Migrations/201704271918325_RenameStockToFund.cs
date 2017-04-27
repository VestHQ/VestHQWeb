namespace VestHQDataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStockToFund : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockPriceHistory", "StockId", "dbo.Stock");
            DropForeignKey("dbo.Holding", "StockId", "dbo.Stock");
            DropIndex("dbo.Holding", new[] { "StockId" });
            DropIndex("dbo.StockPriceHistory", new[] { "StockId" });
            CreateTable(
                "dbo.FundPriceHistory",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FundId = c.String(maxLength: 128),
                        Time = c.DateTime(nullable: false),
                        Ticker = c.String(),
                        TickerPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fund", t => t.FundId)
                .Index(t => t.FundId);
            
            CreateTable(
                "dbo.Fund",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 200),
                        Ticker = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Holding", "FundId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Holding", "FundId");
            AddForeignKey("dbo.Holding", "FundId", "dbo.Fund", "Id");
            DropColumn("dbo.Holding", "StockId");
            DropTable("dbo.Stock");
            DropTable("dbo.StockPriceHistory");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 200),
                        Ticker = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Holding", "StockId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Holding", "FundId", "dbo.Fund");
            DropForeignKey("dbo.FundPriceHistory", "FundId", "dbo.Fund");
            DropIndex("dbo.Holding", new[] { "FundId" });
            DropIndex("dbo.FundPriceHistory", new[] { "FundId" });
            DropColumn("dbo.Holding", "FundId");
            DropTable("dbo.Fund");
            DropTable("dbo.FundPriceHistory");
            CreateIndex("dbo.StockPriceHistory", "StockId");
            CreateIndex("dbo.Holding", "StockId");
            AddForeignKey("dbo.Holding", "StockId", "dbo.Stock", "Id");
            AddForeignKey("dbo.StockPriceHistory", "StockId", "dbo.Stock", "Id");
        }
    }
}
