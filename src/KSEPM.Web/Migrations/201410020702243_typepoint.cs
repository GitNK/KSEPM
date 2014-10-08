namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typepoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PointType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PointType");
        }
    }
}
