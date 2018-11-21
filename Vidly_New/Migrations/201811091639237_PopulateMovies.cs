namespace Vidly_New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Hangover', 1, '08.11.1989', 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Die Hard', 2, '08.11.1989', 6)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('The Terminator', 2, '08.11.1989', 7)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Toy Story', 3, '08.11.1989', 11)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock) VALUES ('Titanic', 4, '08.11.1989', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
