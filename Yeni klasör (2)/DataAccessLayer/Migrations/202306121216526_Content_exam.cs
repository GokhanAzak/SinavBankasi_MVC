namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Content_exam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "CategoryID", c => c.Int(nullable: true));
            AddColumn("dbo.Contents", "ExamID", c => c.Int(nullable: true));
            CreateIndex("dbo.Contents", "CategoryID");
            CreateIndex("dbo.Contents", "ExamID");
            AddForeignKey("dbo.Contents", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: false);
            AddForeignKey("dbo.Contents", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "ExamID", "dbo.Exams");
            DropForeignKey("dbo.Contents", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "ExamID" });
            DropIndex("dbo.Contents", new[] { "CategoryID" });
            DropColumn("dbo.Contents", "ExamID");
            DropColumn("dbo.Contents", "CategoryID");
        }
    }
}
