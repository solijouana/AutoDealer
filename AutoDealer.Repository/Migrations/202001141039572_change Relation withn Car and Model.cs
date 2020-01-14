namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRelationwithnCarandModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubModels", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Cars", "Model_ID", "dbo.Models");
            DropIndex("dbo.Cars", new[] { "Model_ID" });
            DropColumn("dbo.Models", "ID");
            RenameColumn(table: "dbo.Models", name: "Model_ID", newName: "ID");
            DropPrimaryKey("dbo.Models");
            AlterColumn("dbo.Models", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Models", "ID");
            CreateIndex("dbo.Models", "ID");
            AddForeignKey("dbo.SubModels", "ModelID", "dbo.Models", "CarID", cascadeDelete: true);
            DropColumn("dbo.Cars", "Model_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Model_ID", c => c.Int());
            DropForeignKey("dbo.SubModels", "ModelID", "dbo.Models");
            DropIndex("dbo.Models", new[] { "ID" });
            DropPrimaryKey("dbo.Models");
            AlterColumn("dbo.Models", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Models", "ID");
            RenameColumn(table: "dbo.Models", name: "ID", newName: "Model_ID");
            AddColumn("dbo.Models", "ID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Cars", "Model_ID");
            AddForeignKey("dbo.Cars", "Model_ID", "dbo.Models", "ID");
            AddForeignKey("dbo.SubModels", "ModelID", "dbo.Models", "ID", cascadeDelete: true);
        }
    }
}
