namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmanufacturerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "model_ID", "dbo.Models");
            DropForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "model_ID" });
            DropIndex("dbo.Models", new[] { "Manufacturer_ID" });
            RenameColumn(table: "dbo.Models", name: "Manufacturer_ID", newName: "ManufacturerID");
            AlterColumn("dbo.Models", "ManufacturerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "ManufacturerID");
            AddForeignKey("dbo.Models", "ManufacturerID", "dbo.Manufacturers", "ID", cascadeDelete: true);
            DropColumn("dbo.Models", "model_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "model_ID", c => c.Int());
            DropForeignKey("dbo.Models", "ManufacturerID", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "ManufacturerID" });
            AlterColumn("dbo.Models", "ManufacturerID", c => c.Int());
            RenameColumn(table: "dbo.Models", name: "ManufacturerID", newName: "Manufacturer_ID");
            CreateIndex("dbo.Models", "Manufacturer_ID");
            CreateIndex("dbo.Models", "model_ID");
            AddForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers", "ID");
            AddForeignKey("dbo.Models", "model_ID", "dbo.Models", "ID");
        }
    }
}
