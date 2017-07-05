namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) Values (1,'Comedy') ");
            Sql("Insert into Genres (Id,Name) Values (2,'Action') ");
            Sql("Insert into Genres (Id,Name) Values (3,'Familly') ");
            Sql("Insert into Genres (Id,Name) Values (4,'Romance') ");
            Sql("Insert into Genres (Id,Name) Values (5,'Horror') ");


        }

        public override void Down()
        {
        }
    }
}
