namespace MovieHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (3, 'Drama')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (4, 'Fantasy')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (6, 'Mystery')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (7, 'Romance')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (8, 'Thriller')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MovieGenres WHERE Id IN (1,2,3,4,5,6,7,8)");
        }
    }
}
