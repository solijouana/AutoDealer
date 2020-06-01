namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInSlider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "InSlider", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "InSlider");
        }
    }
}
