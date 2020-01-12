namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActivefieldincartable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Model_ID", c => c.Int());
            CreateIndex("dbo.Cars", "Model_ID");
            AddForeignKey("dbo.Cars", "Model_ID", "dbo.Models", "ID");
            DropColumn("dbo.Cars", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Type", c => c.String(nullable: false, maxLength: 150));
            DropForeignKey("dbo.Cars", "Model_ID", "dbo.Models");
            DropIndex("dbo.Cars", new[] { "Model_ID" });
            DropColumn("dbo.Cars", "Model_ID");
            DropColumn("dbo.Cars", "IsActive");
        }
    }
}
