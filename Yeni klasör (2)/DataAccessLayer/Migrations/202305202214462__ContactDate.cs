namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ContactDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "UserMail", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "UserMail", c => c.String());
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
