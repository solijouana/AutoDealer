namespace AutoDealer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExistSubModelEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubModels", "SubModelTitle", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubModels", "SubModelTitle", c => c.String());
        }
    }
}
