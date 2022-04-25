namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverwriteConventionsForUpcomingMoviesAndGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpcomingMovies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.UpcomingMovies", new[] { "MovieGenre_Id" });
            AlterColumn("dbo.MovieGenres", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UpcomingMovies", "Director", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UpcomingMovies", "MovieGenre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.UpcomingMovies", "MovieGenre_Id");
            AddForeignKey("dbo.UpcomingMovies", "MovieGenre_Id", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingMovies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.UpcomingMovies", new[] { "MovieGenre_Id" });
            AlterColumn("dbo.UpcomingMovies", "MovieGenre_Id", c => c.Byte());
            AlterColumn("dbo.UpcomingMovies", "Director", c => c.String());
            AlterColumn("dbo.MovieGenres", "Name", c => c.String());
            CreateIndex("dbo.UpcomingMovies", "MovieGenre_Id");
            AddForeignKey("dbo.UpcomingMovies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
    }
}
