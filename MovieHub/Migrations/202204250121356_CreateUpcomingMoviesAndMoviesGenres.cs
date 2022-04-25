namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUpcomingMoviesAndMoviesGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpcomingMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReleaseDate = c.DateTime(nullable: false),
                        RunningTime = c.Int(nullable: false),
                        Director = c.String(),
                        Movie_Id = c.String(maxLength: 128),
                        MovieGenre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Movie_Id)
                .ForeignKey("dbo.MovieGenres", t => t.MovieGenre_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.MovieGenre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpcomingMovies", "MovieGenre_Id", "dbo.MovieGenres");
            DropForeignKey("dbo.UpcomingMovies", "Movie_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UpcomingMovies", new[] { "MovieGenre_Id" });
            DropIndex("dbo.UpcomingMovies", new[] { "Movie_Id" });
            DropTable("dbo.UpcomingMovies");
            DropTable("dbo.MovieGenres");
        }
    }
}
