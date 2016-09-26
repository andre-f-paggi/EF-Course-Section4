namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenresAndVideos : DbMigration
    {
        public override void Up()
        {
            // Adding Dummy Genres
            Sql(@"
                INSERT INTO Genres (Name) VALUES ('Horror')
                INSERT INTO Genres (Name) VALUES ('Comedy')
                INSERT INTO Genres (Name) VALUES ('Romance')
            ");

            // Adding Dummy Videos
            //Sql(@"
            //    INSERT INTO Videos (Name, ReleaseDate) VALUES ('Juon', '2014-02-02')
            //    INSERT INTO Videos (Name, ReleaseDate) VALUES ('Click', '2012-01-06')
            //    INSERT INTO Videos (Name, ReleaseDate) VALUES ('The Fault in Our Stars', '2015-06-08')
            //");
        }
        
        public override void Down()
        {
            // Clean Genres
            Sql(@"DELETE FROM Genres");

            // Clean Videos
            //Sql(@"DELETE FROM Videos");
        }
    }
}
