namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactNuberinCarentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ContactNumber", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "ContactNumber");
        }
    }
}
