namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hedig_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "HedingID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "HedingID");
        }
    }
}
