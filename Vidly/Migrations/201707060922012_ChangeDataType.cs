namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "GenreID" });
            AlterColumn("dbo.Movies", "Name", c => c.String(maxLength: 255));
            CreateIndex("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            CreateIndex("dbo.Movies", "GenreID");
        }
    }
}
