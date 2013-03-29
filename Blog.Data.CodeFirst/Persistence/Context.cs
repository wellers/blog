using System.Data.Entity;
using Blog.Data.CodeFirst.Models;
using Blog.Data.CodeFirst.Migrations;

namespace Blog.Data.CodeFirst.Persistence
{
    public class Context : DbContext
    {
        public DbSet<BlogEntry> BlogEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
        }
    }
}
