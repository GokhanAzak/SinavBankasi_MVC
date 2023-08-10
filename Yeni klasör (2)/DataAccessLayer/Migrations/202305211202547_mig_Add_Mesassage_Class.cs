namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_Add_Mesassage_Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Message", c => c.String());
            AlterColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contacts", "Mesasage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Mesasage", c => c.String());
            AlterColumn("dbo.Contacts", "ContactDate", c => c.Int(nullable: false));
            DropColumn("dbo.Contacts", "Message");
        }
    }
}
