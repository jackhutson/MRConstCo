namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Jobs", new[] { "Project_Id" });
            RenameColumn(table: "dbo.Jobs", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.Jobs", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "ProjectId");
            AddForeignKey("dbo.Jobs", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Jobs", new[] { "ProjectId" });
            AlterColumn("dbo.Jobs", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.Jobs", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.Jobs", "Project_Id");
            AddForeignKey("dbo.Jobs", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
