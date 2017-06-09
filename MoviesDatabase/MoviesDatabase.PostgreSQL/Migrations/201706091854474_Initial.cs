namespace MoviesDatabase.PostgreSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 30),
                        PassHash = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Username)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("public.Users", new[] { "Username" });
            DropTable("public.Users");
        }
    }
}
