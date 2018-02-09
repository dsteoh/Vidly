namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'War')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }

        public override void Down()
        {
        }
    }
}
