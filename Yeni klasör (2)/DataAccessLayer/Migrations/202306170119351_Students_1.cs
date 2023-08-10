namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Students_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(maxLength: 50),
                        HedingID = c.Int(nullable: false),
                        StudentSurName = c.String(maxLength: 50),
                        StudentMail = c.String(maxLength: 100),
                        StudentPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
