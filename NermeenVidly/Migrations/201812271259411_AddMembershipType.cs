namespace NermeenVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DuraitionInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "MembershipTYpeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTYpeId");
            AddForeignKey("dbo.Customers", "MembershipTYpeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTYpeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTYpeId" });
            DropColumn("dbo.Customers", "MembershipTYpeId");
            DropColumn("dbo.Customers", "Birthdate");
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
