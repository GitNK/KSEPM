namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usercallback2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserCallbacks", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserCallbacks", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserCallbacks", "UpdatedDate");
            DropColumn("dbo.UserCallbacks", "CreatedDate");
        }
    }
}
