namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddbsets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OptionTitle = c.String(nullable: false, maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        Op_CategoryID = c.Int(nullable: false),
                        OptionCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Option_Category", t => t.OptionCategory_ID)
                .Index(t => t.OptionCategory_ID);
            
            CreateTable(
                "dbo.Option_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Op_CategortyTitle = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "OptionCategory_ID", "dbo.Option_Category");
            DropIndex("dbo.Options", new[] { "OptionCategory_ID" });
            DropTable("dbo.Option_Category");
            DropTable("dbo.Options");
        }
    }
}
