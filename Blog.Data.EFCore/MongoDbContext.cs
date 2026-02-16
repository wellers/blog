using Blog.Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Blog.Data.EFCore;

public class MongoDbContext(IConfiguration configuration) : DbContext
{
	public DbSet<BlogEntryEntity> BlogEntries { get; init; }

	private readonly string? _connectionString = configuration.GetConnectionString("MongoConnection") ?? throw new ArgumentNullException(nameof(_connectionString));

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMongoDB(_connectionString, "my_database");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<BlogEntryEntity>().ToCollection("BlogEntries");
	}
}