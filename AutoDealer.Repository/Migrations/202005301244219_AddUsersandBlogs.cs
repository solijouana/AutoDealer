namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersandBlogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tags = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 300),
                        UserName = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 100),
                        Phone = c.Int(),
                        ImageName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Blogs");
        }
    }
}
