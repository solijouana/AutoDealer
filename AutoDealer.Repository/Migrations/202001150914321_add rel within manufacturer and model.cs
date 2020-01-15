namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelwithinmanufacturerandmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "model_ID", c => c.Int());
            AddColumn("dbo.Models", "Manufacturer_ID", c => c.Int());
            CreateIndex("dbo.Models", "model_ID");
            CreateIndex("dbo.Models", "Manufacturer_ID");
            AddForeignKey("dbo.Models", "model_ID", "dbo.Models", "ID");
            AddForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers");
            DropForeignKey("dbo.Models", "model_ID", "dbo.Models");
            DropIndex("dbo.Models", new[] { "Manufacturer_ID" });
            DropIndex("dbo.Models", new[] { "model_ID" });
            DropColumn("dbo.Models", "Manufacturer_ID");
            DropColumn("dbo.Models", "model_ID");
        }
    }
}
