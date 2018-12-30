namespace NermeenVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blabla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
