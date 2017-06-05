namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrequiredfieldconstrained : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Producers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stars", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Stars", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Studios", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Studios", "Name", c => c.String());
            AlterColumn("dbo.Stars", "LastName", c => c.String());
            AlterColumn("dbo.Stars", "FirstName", c => c.String());
            AlterColumn("dbo.Producers", "Name", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
