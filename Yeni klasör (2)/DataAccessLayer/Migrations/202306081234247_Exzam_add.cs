namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exzam_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "WriterID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "WriterID");
        }
    }
}
