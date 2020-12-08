namespace ProjectForDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "ContactPhone", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Orders", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transports", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transports", "Producer", c => c.String(nullable: false));
            AlterColumn("dbo.Transports", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Transports", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transports", "ImageUrl", c => c.String());
            AlterColumn("dbo.Transports", "Description", c => c.String());
            AlterColumn("dbo.Transports", "Producer", c => c.String());
            AlterColumn("dbo.Transports", "Name", c => c.String());
            AlterColumn("dbo.Orders", "Email", c => c.String());
            AlterColumn("dbo.Orders", "ContactPhone", c => c.String());
            AlterColumn("dbo.Orders", "Address", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
        }
    }
}
