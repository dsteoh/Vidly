namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id,Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES (1,'Spider-man','2015-02-12 13:33:22','2016-02-12 13:33:22',5,1)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }

        public override void Down()
        {
        }
    }
}
