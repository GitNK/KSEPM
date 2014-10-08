namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selldaterename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sells", "SellDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sells", "SellTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sells", "SellTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sells", "SellDate");
        }
    }
}
