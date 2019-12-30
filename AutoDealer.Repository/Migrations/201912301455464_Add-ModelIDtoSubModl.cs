namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelIDtoSubModl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubModels", "Model_ID", "dbo.Models");
            DropIndex("dbo.SubModels", new[] { "Model_ID" });
            RenameColumn(table: "dbo.SubModels", name: "Model_ID", newName: "ModelID");
            AlterColumn("dbo.SubModels", "ModelID", c => c.Int(nullable: false));
            CreateIndex("dbo.SubModels", "ModelID");
            AddForeignKey("dbo.SubModels", "ModelID", "dbo.Models", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubModels", "ModelID", "dbo.Models");
            DropIndex("dbo.SubModels", new[] { "ModelID" });
            AlterColumn("dbo.SubModels", "ModelID", c => c.Int());
            RenameColumn(table: "dbo.SubModels", name: "ModelID", newName: "Model_ID");
            CreateIndex("dbo.SubModels", "Model_ID");
            AddForeignKey("dbo.SubModels", "Model_ID", "dbo.Models", "ID");
        }
    }
}
