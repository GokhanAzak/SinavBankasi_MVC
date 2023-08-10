namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exzam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(nullable: false),
                        ExamValue = c.String(),
                        WriterName = c.String(maxLength: 50),
                        WriterSurName = c.String(maxLength: 50),
                        CategoryID = c.Int(nullable: false),
                        CategoryName = c.String(maxLength: 50),
                        Duration = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ExamID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Exams");
        }
    }
}
