namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "OptionCategory_ID", "dbo.Option_Category");
            DropIndex("dbo.Options", new[] { "OptionCategory_ID" });
            DropColumn("dbo.Options", "Op_CategoryID");
            RenameColumn(table: "dbo.Options", name: "OptionCategory_ID", newName: "Op_CategoryID");
            AlterColumn("dbo.Options", "Op_CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Options", "Op_CategoryID");
            AddForeignKey("dbo.Options", "Op_CategoryID", "dbo.Option_Category", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "Op_CategoryID", "dbo.Option_Category");
            DropIndex("dbo.Options", new[] { "Op_CategoryID" });
            AlterColumn("dbo.Options", "Op_CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Options", name: "Op_CategoryID", newName: "OptionCategory_ID");
            AddColumn("dbo.Options", "Op_CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Options", "OptionCategory_ID");
            AddForeignKey("dbo.Options", "OptionCategory_ID", "dbo.Option_Category", "ID");
        }
    }
}
