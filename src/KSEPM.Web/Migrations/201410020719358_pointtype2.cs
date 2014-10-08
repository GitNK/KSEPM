namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pointtype2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellPoints", "PointType_ID", "dbo.PointTypes");
            DropIndex("dbo.SellPoints", new[] { "PointType_ID" });
            DropColumn("dbo.SellPoints", "PointType_ID");
            DropTable("dbo.PointTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PointTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SellPoints", "PointType_ID", c => c.Int());
            CreateIndex("dbo.SellPoints", "PointType_ID");
            AddForeignKey("dbo.SellPoints", "PointType_ID", "dbo.PointTypes", "ID");
        }
    }
}
