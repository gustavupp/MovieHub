namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToUpcomingMoviesAgain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UpcomingMovies", name: "AppUser_Id", newName: "AppUserId");
            RenameColumn(table: "dbo.UpcomingMovies", name: "MovieGenre_Id", newName: "MovieGenreId");
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_AppUser_Id", newName: "IX_AppUserId");
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_MovieGenre_Id", newName: "IX_MovieGenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_MovieGenreId", newName: "IX_MovieGenre_Id");
            RenameIndex(table: "dbo.UpcomingMovies", name: "IX_AppUserId", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.UpcomingMovies", name: "MovieGenreId", newName: "MovieGenre_Id");
            RenameColumn(table: "dbo.UpcomingMovies", name: "AppUserId", newName: "AppUser_Id");
        }
    }
}
