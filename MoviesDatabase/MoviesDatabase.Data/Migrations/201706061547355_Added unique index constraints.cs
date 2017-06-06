namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeduniqueindexconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Year", c => c.Int());
            AlterColumn("dbo.Stars", "Age", c => c.Int());
            CreateIndex("dbo.Books", "Title", unique: true, name: "IX_BookTitle");
            CreateIndex("dbo.Genres", "Name", unique: true, name: "IX_Genre");
            CreateIndex("dbo.Movies", "Title", unique: true, name: "IX_MovieTitle");
            CreateIndex("dbo.Producers", "Name", unique: true, name: "IX_ProducerName");
            CreateIndex("dbo.Stars", new[] { "FirstName", "LastName" }, unique: true, name: "IX_FirstNameLastName");
            CreateIndex("dbo.Studios", "Name", unique: true, name: "IX_StudioName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Studios", "IX_StudioName");
            DropIndex("dbo.Stars", "IX_FirstNameLastName");
            DropIndex("dbo.Producers", "IX_ProducerName");
            DropIndex("dbo.Movies", "IX_MovieTitle");
            DropIndex("dbo.Genres", "IX_Genre");
            DropIndex("dbo.Books", "IX_BookTitle");
            AlterColumn("dbo.Stars", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Year", c => c.Int(nullable: false));
        }
    }
}
