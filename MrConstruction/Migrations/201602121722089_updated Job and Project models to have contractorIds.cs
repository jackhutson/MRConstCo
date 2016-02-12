namespace MrConstruction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedJobandProjectmodelstohavecontractorIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jobs", name: "Contractor_Id", newName: "ContractorId");
            RenameIndex(table: "dbo.Jobs", name: "IX_Contractor_Id", newName: "IX_ContractorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Jobs", name: "IX_ContractorId", newName: "IX_Contractor_Id");
            RenameColumn(table: "dbo.Jobs", name: "ContractorId", newName: "Contractor_Id");
        }
    }
}
