namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduploadclassificationenum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uploads", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uploads", "Type", c => c.String());
        }
    }
}
