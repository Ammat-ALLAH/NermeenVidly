namespace NermeenVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestDateFromMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "testDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "testDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
