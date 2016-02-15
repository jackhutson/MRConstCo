namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtothemodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uploads", "IsBefore", c => c.Boolean(nullable: false));
            AddColumn("dbo.Uploads", "IsAfter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uploads", "IsAfter");
            DropColumn("dbo.Uploads", "IsBefore");
        }
    }
}
