namespace NermeenVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finalize : DbMigration
    {
        public override void Up()
        {
           // AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean());
        }
    }
}
