namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam_writer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            AddColumn("dbo.Writers", "Exam_ExamID", c => c.Int());
            AlterColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Writers", "Exam_ExamID");
            AddForeignKey("dbo.Writers", "Exam_ExamID", "dbo.Exams", "ExamID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Writers", "Exam_ExamID", "dbo.Exams");
            DropIndex("dbo.Writers", new[] { "Exam_ExamID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            AlterColumn("dbo.Contents", "WriterID", c => c.Int());
            DropColumn("dbo.Writers", "Exam_ExamID");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
        }
    }
}
