namespace MoviesDatabase.PostgreSQL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDatabase.PostgreSQL.UsersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UsersDbContext context)
        {
            context.Users.AddOrUpdate(
                user => user.Username,
                new User() { Username = "simona.tsenova", PassHash = "123456" },
                new User() { Username = "yoana.georgieva", PassHash = "123456" },
                new User() { Username = "daniel.slavov", PassHash = "123456" });
        }
    }
}
