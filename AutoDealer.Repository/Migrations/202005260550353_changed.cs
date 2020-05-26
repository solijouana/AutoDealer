namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Roletitle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "ID", cascadeDelete: true);
        }
    }
}
