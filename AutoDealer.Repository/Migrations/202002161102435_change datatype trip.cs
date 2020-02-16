namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatypetrip : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "ProductionDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "ProductionDate", c => c.String(nullable: false));
        }
    }
}
