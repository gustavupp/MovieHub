namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIscanceldProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpcomingMovies", "isCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingMovies", "isCanceled");
        }
    }
}
