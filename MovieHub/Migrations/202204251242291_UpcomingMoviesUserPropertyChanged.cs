namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpcomingMoviesUserPropertyChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UpcomingMovies", name: "Movie_Id", newName: "AppUser_Id");
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_Movie_Id", newName: "IX_AppUser_Id");
            AddColumn("dbo.UpcomingMovies", "MovieName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpcomingMovies", "MovieName");
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_AppUser_Id", newName: "IX_Movie_Id");
            RenameColumn(table: "dbo.UpcomingMovies", name: "AppUser_Id", newName: "Movie_Id");
        }
    }
}
