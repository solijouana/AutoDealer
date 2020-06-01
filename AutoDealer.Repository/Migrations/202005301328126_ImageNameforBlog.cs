namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageNameforBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImageName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "ImageName");
        }
    }
}
