namespace MoviesDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                        Length = c.Int(nullable: false),
                        ProducerID = c.Int(nullable: false),
                        StudioID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerID, cascadeDelete: true)
                .ForeignKey("dbo.Studios", t => t.StudioID, cascadeDelete: true)
                .Index(t => t.ProducerID)
                .Index(t => t.StudioID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProducerID);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        StarID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StarID);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StudioID);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Movie_MovieID = c.Int(nullable: false),
                        Genre_GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieID, t.Genre_GenreID })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreID, cascadeDelete: true)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Genre_GenreID);
            
            CreateTable(
                "dbo.StarMovies",
                c => new
                    {
                        Star_StarID = c.Int(nullable: false),
                        Movie_MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Star_StarID, t.Movie_MovieID })
                .ForeignKey("dbo.Stars", t => t.Star_StarID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .Index(t => t.Star_StarID)
                .Index(t => t.Movie_MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "StudioID", "dbo.Studios");
            DropForeignKey("dbo.StarMovies", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.StarMovies", "Star_StarID", "dbo.Stars");
            DropForeignKey("dbo.Movies", "ProducerID", "dbo.Producers");
            DropForeignKey("dbo.MovieGenres", "Genre_GenreID", "dbo.Genres");
            DropForeignKey("dbo.MovieGenres", "Movie_MovieID", "dbo.Movies");
            DropForeignKey("dbo.Movies", "BookID", "dbo.Books");
            DropIndex("dbo.StarMovies", new[] { "Movie_MovieID" });
            DropIndex("dbo.StarMovies", new[] { "Star_StarID" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_GenreID" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_MovieID" });
            DropIndex("dbo.Movies", new[] { "BookID" });
            DropIndex("dbo.Movies", new[] { "StudioID" });
            DropIndex("dbo.Movies", new[] { "ProducerID" });
            DropTable("dbo.StarMovies");
            DropTable("dbo.MovieGenres");
            DropTable("dbo.Studios");
            DropTable("dbo.Stars");
            DropTable("dbo.Producers");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
