namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id,Name) VALUES (1,'Heavy Metal')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (2,'Death Metal')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (3,'Black Metal')");
            Sql("INSERT INTO GENRES (Id,Name) VALUES (4,'Thrash Metal')");

        }
        
        public override void Down()
        {
            Sql("DELETE FROM GENRES WHERE Id IN (1,2,3,4)");
        }
    }
}
