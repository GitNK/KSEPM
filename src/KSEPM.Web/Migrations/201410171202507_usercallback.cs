namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usercallback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCallbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCallbacks", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserCallbacks", new[] { "UserID" });
            DropTable("dbo.UserCallbacks");
        }
    }
}
