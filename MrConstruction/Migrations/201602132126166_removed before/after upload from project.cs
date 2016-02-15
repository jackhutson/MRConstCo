namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedbeforeafteruploadfromproject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "AfterPicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.Projects", "BeforePicture_Id", "dbo.Uploads");
            DropIndex("dbo.Projects", new[] { "AfterPicture_Id" });
            DropIndex("dbo.Projects", new[] { "BeforePicture_Id" });
            DropColumn("dbo.Projects", "AfterPicture_Id");
            DropColumn("dbo.Projects", "BeforePicture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "BeforePicture_Id", c => c.Int());
            AddColumn("dbo.Projects", "AfterPicture_Id", c => c.Int());
            CreateIndex("dbo.Projects", "BeforePicture_Id");
            CreateIndex("dbo.Projects", "AfterPicture_Id");
            AddForeignKey("dbo.Projects", "BeforePicture_Id", "dbo.Uploads", "Id");
            AddForeignKey("dbo.Projects", "AfterPicture_Id", "dbo.Uploads", "Id");
        }
    }
}
