namespace VestHQDataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyQuestionsAndAnswers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSurveyResponse",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.String(maxLength: 128),
                        SurveyQuestionId = c.String(maxLength: 128),
                        Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.SurveyQuestion", t => t.SurveyQuestionId)
                .Index(t => t.EmployeeId)
                .Index(t => t.SurveyQuestionId);
            
            CreateTable(
                "dbo.SurveyQuestion",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyAnswer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SurveyQuestionId = c.String(maxLength: 128),
                        Text = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyQuestion", t => t.SurveyQuestionId)
                .Index(t => t.SurveyQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyAnswer", "SurveyQuestionId", "dbo.SurveyQuestion");
            DropForeignKey("dbo.EmployeeSurveyResponse", "SurveyQuestionId", "dbo.SurveyQuestion");
            DropForeignKey("dbo.EmployeeSurveyResponse", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.SurveyAnswer", new[] { "SurveyQuestionId" });
            DropIndex("dbo.EmployeeSurveyResponse", new[] { "SurveyQuestionId" });
            DropIndex("dbo.EmployeeSurveyResponse", new[] { "EmployeeId" });
            DropTable("dbo.SurveyAnswer");
            DropTable("dbo.SurveyQuestion");
            DropTable("dbo.EmployeeSurveyResponse");
        }
    }
}
