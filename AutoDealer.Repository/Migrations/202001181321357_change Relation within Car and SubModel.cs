namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRelationwithinCarandSubModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "SubModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "SubModelId");
            AddForeignKey("dbo.Cars", "SubModelId", "dbo.SubModels", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "SubModelId", "dbo.SubModels");
            DropIndex("dbo.Cars", new[] { "SubModelId" });
            DropColumn("dbo.Cars", "SubModelId");
        }
    }
}
