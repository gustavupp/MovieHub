namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesColumnsUserNotificationsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "ModificationDate", c => c.DateTime());
            DropColumn("dbo.Notifications", "OriginalDateTime");
            DropColumn("dbo.Notifications", "OriginalVenue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
            AddColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "ModificationDate");
        }
    }
}
