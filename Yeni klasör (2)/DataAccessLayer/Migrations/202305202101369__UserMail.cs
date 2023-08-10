namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _UserMail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "UserMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "UserMail");
        }
    }
}
