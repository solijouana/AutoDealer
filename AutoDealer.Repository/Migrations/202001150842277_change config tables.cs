namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeconfigtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            DropColumn("dbo.Models", "ManufacturerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "ManufacturerId");
            AddForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers", "ID", cascadeDelete: true);
        }
    }
}
