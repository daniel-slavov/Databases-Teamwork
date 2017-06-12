namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Addednvarcharmaxlengthconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "Author", c => c.String(maxLength: 50));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Stars", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Stars", "LastName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Stars", "Address", c => c.String(maxLength: 60));
            AlterColumn("dbo.Studios", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Studios", "Address", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Studios", "Address", c => c.String());
            AlterColumn("dbo.Studios", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stars", "Address", c => c.String());
            AlterColumn("dbo.Stars", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Stars", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
        }
    }
}
