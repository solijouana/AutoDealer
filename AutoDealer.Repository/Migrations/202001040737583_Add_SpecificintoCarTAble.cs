namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SpecificintoCarTAble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Specific", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Specific");
        }
    }
}
