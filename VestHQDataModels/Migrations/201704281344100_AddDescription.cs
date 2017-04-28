namespace VestHQDataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fund", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fund", "Description");
        }
    }
}
