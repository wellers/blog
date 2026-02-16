using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blog.Data.Migrations;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFCore.SqlDbContext>
{
    public EFCore.SqlDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFCore.SqlDbContext>();
        // Default connection used for design-time tools. Replace with your dev connection.
        var connection = "Server=(localdb)\\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("Blog.Data.Migrations"));
        return new EFCore.SqlDbContext(optionsBuilder.Options);
    }
}
