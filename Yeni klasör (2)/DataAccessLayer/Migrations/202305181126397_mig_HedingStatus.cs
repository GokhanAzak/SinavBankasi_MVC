namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_HedingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hedings", "HedingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hedings", "HedingStatus");
        }
    }
}
