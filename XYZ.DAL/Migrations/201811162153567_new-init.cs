namespace XYZ.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newinit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminClaim", "CreationDate", c => c.DateTime());
            AddColumn("dbo.AdminClaim", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.AdminLogin", "CreationDate", c => c.DateTime());
            AddColumn("dbo.AdminLogin", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.AdminRole", "CreationDate", c => c.DateTime());
            AddColumn("dbo.AdminRole", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.Admin", "CreationDate", c => c.DateTime());
            AddColumn("dbo.Admin", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.RoleForAdmin", "CreationDate", c => c.DateTime());
            AddColumn("dbo.RoleForAdmin", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.RoleForUser", "CreationDate", c => c.DateTime());
            AddColumn("dbo.RoleForUser", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.UserRole", "CreationDate", c => c.DateTime());
            AddColumn("dbo.UserRole", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.User", "CreationDate", c => c.DateTime());
            AddColumn("dbo.User", "LastUpdate", c => c.DateTime());
            AddColumn("dbo.UserLogin", "CreationDate", c => c.DateTime());
            AddColumn("dbo.UserLogin", "LastUpdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLogin", "LastUpdate");
            DropColumn("dbo.UserLogin", "CreationDate");
            DropColumn("dbo.User", "LastUpdate");
            DropColumn("dbo.User", "CreationDate");
            DropColumn("dbo.UserRole", "LastUpdate");
            DropColumn("dbo.UserRole", "CreationDate");
            DropColumn("dbo.RoleForUser", "LastUpdate");
            DropColumn("dbo.RoleForUser", "CreationDate");
            DropColumn("dbo.RoleForAdmin", "LastUpdate");
            DropColumn("dbo.RoleForAdmin", "CreationDate");
            DropColumn("dbo.Admin", "LastUpdate");
            DropColumn("dbo.Admin", "CreationDate");
            DropColumn("dbo.AdminRole", "LastUpdate");
            DropColumn("dbo.AdminRole", "CreationDate");
            DropColumn("dbo.AdminLogin", "LastUpdate");
            DropColumn("dbo.AdminLogin", "CreationDate");
            DropColumn("dbo.AdminClaim", "LastUpdate");
            DropColumn("dbo.AdminClaim", "CreationDate");
        }
    }
}
