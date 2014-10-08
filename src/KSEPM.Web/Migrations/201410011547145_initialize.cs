namespace KSEPM.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChairLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ChairMultiply = c.Double(nullable: false),
                        OptionMultiply = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        ChairLine_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ChairLines", t => t.ChairLine_ID)
                .Index(t => t.ChairLine_ID);
            
            CreateTable(
                "dbo.ChairOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Price = c.Int(),
                        IsBasic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PointTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SellPoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PointName = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PointType = c.String(),
                        PointType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PointTypes", t => t.PointType_ID)
                .Index(t => t.PointType_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Points = c.Double(nullable: false),
                        SellTime = c.DateTime(nullable: false),
                        EmployeeID = c.String(maxLength: 128),
                        ChairID = c.Int(nullable: false),
                        SellPointID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chairs", t => t.ChairID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeID)
                .ForeignKey("dbo.SellPoints", t => t.SellPointID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ChairID)
                .Index(t => t.SellPointID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        StartToWork = c.DateTime(),
                        StopToWork = c.DateTime(),
                        IsActive = c.Boolean(),
                        Description = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ChairOptionChairs",
                c => new
                    {
                        ChairOption_ID = c.Int(nullable: false),
                        Chair_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChairOption_ID, t.Chair_ID })
                .ForeignKey("dbo.ChairOptions", t => t.ChairOption_ID, cascadeDelete: true)
                .ForeignKey("dbo.Chairs", t => t.Chair_ID, cascadeDelete: true)
                .Index(t => t.ChairOption_ID)
                .Index(t => t.Chair_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sells", "SellPointID", "dbo.SellPoints");
            DropForeignKey("dbo.Sells", "EmployeeID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sells", "ChairID", "dbo.Chairs");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SellPoints", "PointType_ID", "dbo.PointTypes");
            DropForeignKey("dbo.ChairOptionChairs", "Chair_ID", "dbo.Chairs");
            DropForeignKey("dbo.ChairOptionChairs", "ChairOption_ID", "dbo.ChairOptions");
            DropForeignKey("dbo.Chairs", "ChairLine_ID", "dbo.ChairLines");
            DropIndex("dbo.ChairOptionChairs", new[] { "Chair_ID" });
            DropIndex("dbo.ChairOptionChairs", new[] { "ChairOption_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sells", new[] { "SellPointID" });
            DropIndex("dbo.Sells", new[] { "ChairID" });
            DropIndex("dbo.Sells", new[] { "EmployeeID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SellPoints", new[] { "PointType_ID" });
            DropIndex("dbo.Chairs", new[] { "ChairLine_ID" });
            DropTable("dbo.ChairOptionChairs");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sells");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SellPoints");
            DropTable("dbo.PointTypes");
            DropTable("dbo.ChairOptions");
            DropTable("dbo.Chairs");
            DropTable("dbo.ChairLines");
        }
    }
}
