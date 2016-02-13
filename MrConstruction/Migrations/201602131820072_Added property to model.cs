namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpropertytomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uploads", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uploads", "Type");
        }
    }
}
