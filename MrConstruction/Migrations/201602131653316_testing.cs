namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uploads", "Project_Id", "dbo.Projects");
            AddColumn("dbo.Projects", "AfterPicture_Id", c => c.Int());
            AddColumn("dbo.Projects", "BeforePicture_Id", c => c.Int());
            AddColumn("dbo.Uploads", "Project_Id1", c => c.Int());
            CreateIndex("dbo.Projects", "AfterPicture_Id");
            CreateIndex("dbo.Projects", "BeforePicture_Id");
            CreateIndex("dbo.Uploads", "Project_Id1");
            AddForeignKey("dbo.Projects", "AfterPicture_Id", "dbo.Uploads", "Id");
            AddForeignKey("dbo.Projects", "BeforePicture_Id", "dbo.Uploads", "Id");
            AddForeignKey("dbo.Uploads", "Project_Id1", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uploads", "Project_Id1", "dbo.Projects");
            DropForeignKey("dbo.Projects", "BeforePicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.Projects", "AfterPicture_Id", "dbo.Uploads");
            DropIndex("dbo.Uploads", new[] { "Project_Id1" });
            DropIndex("dbo.Projects", new[] { "BeforePicture_Id" });
            DropIndex("dbo.Projects", new[] { "AfterPicture_Id" });
            DropColumn("dbo.Uploads", "Project_Id1");
            DropColumn("dbo.Projects", "BeforePicture_Id");
            DropColumn("dbo.Projects", "AfterPicture_Id");
            AddForeignKey("dbo.Uploads", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
