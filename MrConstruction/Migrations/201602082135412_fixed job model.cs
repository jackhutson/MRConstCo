namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedjobmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "ContractorUser_Id", newName: "Contractor_Id");
            RenameIndex(table: "dbo.Jobs", name: "IX_ContractorUser_Id", newName: "IX_Contractor_Id");
            AddColumn("dbo.Projects", "Title", c => c.String());
            DropColumn("dbo.Jobs", "Contractor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Contractor", c => c.String());
            DropColumn("dbo.Projects", "Title");
            RenameIndex(table: "dbo.Jobs", name: "IX_Contractor_Id", newName: "IX_ContractorUser_Id");
            RenameColumn(table: "dbo.Jobs", name: "Contractor_Id", newName: "ContractorUser_Id");
        }
    }
}
