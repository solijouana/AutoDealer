namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeconfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Model_ID", "dbo.Models");
            DropIndex("dbo.Cars", new[] { "Model_ID" });
            AddColumn("dbo.Models", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "CarID");
            AddForeignKey("dbo.Models", "CarID", "dbo.Cars", "ID", cascadeDelete: true);
            DropColumn("dbo.Cars", "Model_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Model_ID", c => c.Int());
            DropForeignKey("dbo.Models", "CarID", "dbo.Cars");
            DropIndex("dbo.Models", new[] { "CarID" });
            DropColumn("dbo.Models", "CarID");
            CreateIndex("dbo.Cars", "Model_ID");
            AddForeignKey("dbo.Cars", "Model_ID", "dbo.Models", "ID");
        }
    }
}
