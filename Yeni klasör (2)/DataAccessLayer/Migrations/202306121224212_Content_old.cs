namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Content_old : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Contents", "ExamID", "dbo.Exams");
            DropIndex("dbo.Contents", new[] { "CategoryID" });
            DropIndex("dbo.Contents", new[] { "ExamID" });
            DropColumn("dbo.Contents", "CategoryID");
            DropColumn("dbo.Contents", "ExamID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ExamID", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "ExamID");
            CreateIndex("dbo.Contents", "CategoryID");
            AddForeignKey("dbo.Contents", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
