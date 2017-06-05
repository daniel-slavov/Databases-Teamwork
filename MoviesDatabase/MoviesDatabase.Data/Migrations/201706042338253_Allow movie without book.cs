namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allowmoviewithoutbook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "BookID", "dbo.Books");
            DropIndex("dbo.Movies", new[] { "BookID" });
            AlterColumn("dbo.Movies", "BookID", c => c.Int());
            CreateIndex("dbo.Movies", "BookID");
            AddForeignKey("dbo.Movies", "BookID", "dbo.Books", "BookID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "BookID", "dbo.Books");
            DropIndex("dbo.Movies", new[] { "BookID" });
            AlterColumn("dbo.Movies", "BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "BookID");
            AddForeignKey("dbo.Movies", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
