namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AplicationUserRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpcomingMovies", "Movie_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UpcomingMovies", new[] { "Movie_Id" });
            AlterColumn("dbo.UpcomingMovies", "Movie_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UpcomingMovies", "Movie_Id");
            AddForeignKey("dbo.UpcomingMovies", "Movie_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingMovies", "Movie_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UpcomingMovies", new[] { "Movie_Id" });
            AlterColumn("dbo.UpcomingMovies", "Movie_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UpcomingMovies", "Movie_Id");
            AddForeignKey("dbo.UpcomingMovies", "Movie_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
