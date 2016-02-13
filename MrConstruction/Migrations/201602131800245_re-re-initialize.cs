namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rereinitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Estimate = c.Decimal(precision: 18, scale: 2),
                        ContractorId = c.String(maxLength: 128),
                        State = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ContractorId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Title = c.String(),
                        CompanyName = c.String(),
                        PhoneNumber2 = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        State = c.Int(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstStart = c.DateTime(nullable: false),
                        EstCompleted = c.DateTime(nullable: false),
                        AfterPicture_Id = c.Int(),
                        BeforePicture_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uploads", t => t.AfterPicture_Id)
                .ForeignKey("dbo.Uploads", t => t.BeforePicture_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.AfterPicture_Id)
                .Index(t => t.BeforePicture_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Active = c.Boolean(nullable: false),
                        Portfolio_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Portfolio_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        AfterPicture_Id = c.Int(),
                        BeforePicture_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uploads", t => t.AfterPicture_Id)
                .ForeignKey("dbo.Uploads", t => t.BeforePicture_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.AfterPicture_Id)
                .Index(t => t.BeforePicture_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Jobs", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Projects", "BeforePicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.Projects", "AfterPicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.Uploads", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Uploads", "Portfolio_Id", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Portfolios", "BeforePicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.Portfolios", "AfterPicture_Id", "dbo.Uploads");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "ContractorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clients", "Location_Id", "dbo.Locations");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Portfolios", new[] { "Project_Id" });
            DropIndex("dbo.Portfolios", new[] { "BeforePicture_Id" });
            DropIndex("dbo.Portfolios", new[] { "AfterPicture_Id" });
            DropIndex("dbo.Uploads", new[] { "Project_Id" });
            DropIndex("dbo.Uploads", new[] { "Portfolio_Id" });
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropIndex("dbo.Projects", new[] { "BeforePicture_Id" });
            DropIndex("dbo.Projects", new[] { "AfterPicture_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Jobs", new[] { "ProjectId" });
            DropIndex("dbo.Jobs", new[] { "ContractorId" });
            DropIndex("dbo.Clients", new[] { "Location_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Portfolios");
            DropTable("dbo.Uploads");
            DropTable("dbo.Projects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Jobs");
            DropTable("dbo.Locations");
            DropTable("dbo.Clients");
        }
    }
}
