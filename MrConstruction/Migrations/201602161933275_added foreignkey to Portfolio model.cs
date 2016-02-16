namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkeytoPortfoliomodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolios", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Portfolios", new[] { "Project_Id" });
            RenameColumn(table: "dbo.Portfolios", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.Portfolios", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Portfolios", "ProjectId");
            AddForeignKey("dbo.Portfolios", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Portfolios", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Portfolios", new[] { "ProjectId" });
            AlterColumn("dbo.Portfolios", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.Portfolios", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.Portfolios", "Project_Id");
            AddForeignKey("dbo.Portfolios", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
