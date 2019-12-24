namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car_Gallery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        ImageTitle = c.String(),
                        ImageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        ProductionDate = c.String(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Fuel = c.String(nullable: false, maxLength: 100),
                        Transmition = c.String(nullable: false, maxLength: 100),
                        Doors = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 150),
                        Trip = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManufacturerName = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        ModelTitle = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        ParentID = c.Int(),
                        Model1_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.Model1_ID)
                .Index(t => t.ManufacturerId)
                .Index(t => t.Model1_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Model1_ID", "dbo.Models");
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Car_Gallery", "CarId", "dbo.Cars");
            DropIndex("dbo.Models", new[] { "Model1_ID" });
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropIndex("dbo.Car_Gallery", new[] { "CarId" });
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cars");
            DropTable("dbo.Car_Gallery");
        }
    }
}
