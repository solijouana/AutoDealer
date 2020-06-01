namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
            DropColumn("dbo.Blogs", "IsDelete");
        }
    }
}
