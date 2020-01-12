namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCar_OptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car_Selected_Option",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        OptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.OptionID, cascadeDelete: true)
                .Index(t => t.CarID)
                .Index(t => t.OptionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Car_Selected_Option", "OptionID", "dbo.Options");
            DropForeignKey("dbo.Car_Selected_Option", "CarID", "dbo.Cars");
            DropIndex("dbo.Car_Selected_Option", new[] { "OptionID" });
            DropIndex("dbo.Car_Selected_Option", new[] { "CarID" });
            DropTable("dbo.Car_Selected_Option");
        }
    }
}
