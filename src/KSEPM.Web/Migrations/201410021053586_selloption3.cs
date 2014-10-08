namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selloption3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellChairOptions",
                c => new
                    {
                        Sell_ID = c.Int(nullable: false),
                        ChairOption_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sell_ID, t.ChairOption_ID })
                .ForeignKey("dbo.Sells", t => t.Sell_ID, cascadeDelete: true)
                .ForeignKey("dbo.ChairOptions", t => t.ChairOption_ID, cascadeDelete: true)
                .Index(t => t.Sell_ID)
                .Index(t => t.ChairOption_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellChairOptions", "ChairOption_ID", "dbo.ChairOptions");
            DropForeignKey("dbo.SellChairOptions", "Sell_ID", "dbo.Sells");
            DropIndex("dbo.SellChairOptions", new[] { "ChairOption_ID" });
            DropIndex("dbo.SellChairOptions", new[] { "Sell_ID" });
            DropTable("dbo.SellChairOptions");
        }
    }
}
