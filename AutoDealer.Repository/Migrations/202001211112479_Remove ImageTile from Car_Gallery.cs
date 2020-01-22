namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageTilefromCar_Gallery : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Car_Gallery", "ImageTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car_Gallery", "ImageTitle", c => c.String());
        }
    }
}
