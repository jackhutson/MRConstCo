namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.AspNetUsers", "Jobs_Id", "dbo.Jobs");
            DropIndex("dbo.Jobs", new[] { "Location_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Jobs_Id" });
            AddColumn("dbo.Jobs", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "ContractorUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "ContractorUser_Id");
            AddForeignKey("dbo.Jobs", "ContractorUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Jobs", "Location_Id");
            DropColumn("dbo.AspNetUsers", "Jobs_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Jobs_Id", c => c.Int());
            AddColumn("dbo.Jobs", "Location_Id", c => c.Int());
            DropForeignKey("dbo.Jobs", "ContractorUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "ContractorUser_Id" });
            DropColumn("dbo.Jobs", "ContractorUser_Id");
            DropColumn("dbo.Jobs", "State");
            CreateIndex("dbo.AspNetUsers", "Jobs_Id");
            CreateIndex("dbo.Jobs", "Location_Id");
            AddForeignKey("dbo.AspNetUsers", "Jobs_Id", "dbo.Jobs", "Id");
            AddForeignKey("dbo.Jobs", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
