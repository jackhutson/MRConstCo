namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedisBeforeandisAfterfromUploads : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Uploads", "IsBefore");
            DropColumn("dbo.Uploads", "IsAfter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uploads", "IsAfter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Uploads", "IsBefore", c => c.Boolean(nullable: false));
        }
    }
}
