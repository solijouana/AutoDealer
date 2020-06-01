namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            AlterColumn("dbo.Blogs", "UserId", c => c.Int());
            CreateIndex("dbo.Blogs", "UserId");
            AddForeignKey("dbo.Blogs", "UserId", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            AlterColumn("dbo.Blogs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "UserId");
            AddForeignKey("dbo.Blogs", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
