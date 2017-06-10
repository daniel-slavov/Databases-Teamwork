using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using MoviesDatabase.Models;

namespace MoviesDatabase.PostgreSQL
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext()
            : base("name=UsersConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            this.OnUserModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnUserModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasColumnName("Username")
                .HasMaxLength(30)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Username") { IsUnique = true }));

            modelBuilder.Entity<User>()
                .Property(user => user.PassHash)
                .HasColumnName("PassHash")
                .HasMaxLength(60);
        }
    }
}
