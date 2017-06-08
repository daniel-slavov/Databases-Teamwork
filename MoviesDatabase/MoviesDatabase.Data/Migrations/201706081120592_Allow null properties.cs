namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Allownullproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "ProducerID", "dbo.Producers");
            DropForeignKey("dbo.Movies", "StudioID", "dbo.Studios");
            DropIndex("dbo.Movies", new[] { "ProducerID" });
            DropIndex("dbo.Movies", new[] { "StudioID" });
            AlterColumn("dbo.Movies", "ProducerID", c => c.Int());
            AlterColumn("dbo.Movies", "StudioID", c => c.Int());
            CreateIndex("dbo.Movies", "ProducerID");
            CreateIndex("dbo.Movies", "StudioID");
            AddForeignKey("dbo.Movies", "ProducerID", "dbo.Producers", "ProducerID");
            AddForeignKey("dbo.Movies", "StudioID", "dbo.Studios", "StudioID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "StudioID", "dbo.Studios");
            DropForeignKey("dbo.Movies", "ProducerID", "dbo.Producers");
            DropIndex("dbo.Movies", new[] { "StudioID" });
            DropIndex("dbo.Movies", new[] { "ProducerID" });
            AlterColumn("dbo.Movies", "StudioID", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "ProducerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "StudioID");
            CreateIndex("dbo.Movies", "ProducerID");
            AddForeignKey("dbo.Movies", "StudioID", "dbo.Studios", "StudioID", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "ProducerID", "dbo.Producers", "ProducerID", cascadeDelete: true);
        }
    }
}
