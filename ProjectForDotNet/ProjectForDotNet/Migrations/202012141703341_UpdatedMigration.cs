namespace ProjectForDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transports", "Name", c => c.String());
            AlterColumn("dbo.Transports", "Producer", c => c.String());
            AlterColumn("dbo.Transports", "Description", c => c.String());
            AlterColumn("dbo.Transports", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transports", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Transports", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Transports", "Producer", c => c.String(nullable: false));
            AlterColumn("dbo.Transports", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
