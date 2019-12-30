namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubModelsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "Model1_ID", "dbo.Models");
            DropIndex("dbo.Models", new[] { "Model1_ID" });
            CreateTable(
                "dbo.SubModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubModelTitle = c.String(),
                        Model_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Models", t => t.Model_ID)
                .Index(t => t.Model_ID);
            
            DropColumn("dbo.Models", "ParentID");
            DropColumn("dbo.Models", "Model1_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Model1_ID", c => c.Int());
            AddColumn("dbo.Models", "ParentID", c => c.Int());
            DropForeignKey("dbo.SubModels", "Model_ID", "dbo.Models");
            DropIndex("dbo.SubModels", new[] { "Model_ID" });
            DropTable("dbo.SubModels");
            CreateIndex("dbo.Models", "Model1_ID");
            AddForeignKey("dbo.Models", "Model1_ID", "dbo.Models", "ID");
        }
    }
}
