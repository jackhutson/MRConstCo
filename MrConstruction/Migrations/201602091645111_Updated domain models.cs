namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateddomainmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Estimate", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Estimate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
