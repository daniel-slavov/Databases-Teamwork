namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignkeys : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies DROP CONSTRAINT [FK_dbo.Movies_dbo.Books_BookID]");
            Sql("ALTER TABLE Movies ADD CONSTRAINT [FK_dbo.Movies_dbo.Books_BookID] FOREIGN KEY(BookID) REFERENCES Books(BookID) ON DELETE SET NULL");

            Sql("ALTER TABLE Movies DROP CONSTRAINT [FK_dbo.Movies_dbo.Studios_StudioID]");
            Sql("ALTER TABLE Movies ADD CONSTRAINT [FK_dbo.Movies_dbo.Studios_StudioID] FOREIGN KEY(StudioID) REFERENCES Studios(StudioID) ON DELETE SET NULL");
        }
        
        public override void Down()
        {
        }
    }
}
