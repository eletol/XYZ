namespace XYZ.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Admin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admin", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.AdminLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Admin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Admin", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.AdminRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Admin_Id = c.String(maxLength: 128),
                        RoleForAdmin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Admin", t => t.Admin_Id)
                .ForeignKey("dbo.RoleForAdmin", t => t.RoleForAdmin_Id)
                .Index(t => t.Admin_Id)
                .Index(t => t.RoleForAdmin_Id);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(),
                        MobileNumber = c.String(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ClientUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientUser", t => t.ClientUser_Id)
                .Index(t => t.ClientUser_Id);
            
            CreateTable(
                "dbo.ClientUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClientUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ClientUser", t => t.ClientUser_Id)
                .Index(t => t.ClientUser_Id);
            
            CreateTable(
                "dbo.ClientUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ClientUser_Id = c.String(maxLength: 128),
                        RoleForClient_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ClientUser", t => t.ClientUser_Id)
                .ForeignKey("dbo.RoleForClient", t => t.RoleForClient_Id)
                .Index(t => t.ClientUser_Id)
                .Index(t => t.RoleForClient_Id);
            
            CreateTable(
                "dbo.ClientUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MobileNumber = c.String(nullable: false),
                        Active = c.Boolean(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleForAdmin",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleForClient",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientUserRole", "RoleForClient_Id", "dbo.RoleForClient");
            DropForeignKey("dbo.AdminRole", "RoleForAdmin_Id", "dbo.RoleForAdmin");
            DropForeignKey("dbo.ClientUserRole", "ClientUser_Id", "dbo.ClientUser");
            DropForeignKey("dbo.ClientUserLogin", "ClientUser_Id", "dbo.ClientUser");
            DropForeignKey("dbo.ClientClaim", "ClientUser_Id", "dbo.ClientUser");
            DropForeignKey("dbo.AdminRole", "Admin_Id", "dbo.Admin");
            DropForeignKey("dbo.AdminLogin", "Admin_Id", "dbo.Admin");
            DropForeignKey("dbo.AdminClaim", "Admin_Id", "dbo.Admin");
            DropIndex("dbo.ClientUserRole", new[] { "RoleForClient_Id" });
            DropIndex("dbo.ClientUserRole", new[] { "ClientUser_Id" });
            DropIndex("dbo.ClientUserLogin", new[] { "ClientUser_Id" });
            DropIndex("dbo.ClientClaim", new[] { "ClientUser_Id" });
            DropIndex("dbo.AdminRole", new[] { "RoleForAdmin_Id" });
            DropIndex("dbo.AdminRole", new[] { "Admin_Id" });
            DropIndex("dbo.AdminLogin", new[] { "Admin_Id" });
            DropIndex("dbo.AdminClaim", new[] { "Admin_Id" });
            DropTable("dbo.RoleForClient");
            DropTable("dbo.RoleForAdmin");
            DropTable("dbo.PlayerStatus");
            DropTable("dbo.ClientUser");
            DropTable("dbo.ClientUserRole");
            DropTable("dbo.ClientUserLogin");
            DropTable("dbo.ClientClaim");
            DropTable("dbo.Admin");
            DropTable("dbo.AdminRole");
            DropTable("dbo.AdminLogin");
            DropTable("dbo.AdminClaim");
        }
    }
}
