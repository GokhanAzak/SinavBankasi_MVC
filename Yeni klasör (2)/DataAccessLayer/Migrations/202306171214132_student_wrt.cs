namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_wrt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "WriterID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "WriterID");
        }
    }
}
