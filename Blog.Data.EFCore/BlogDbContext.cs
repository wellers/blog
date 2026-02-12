using Blog.Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EFCore;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
	public DbSet<BlogEntryEntity> BlogEntries => Set<BlogEntryEntity>();
    public DbSet<TagEntity> Tags => Set<TagEntity>();
    public DbSet<BlogEntryTagEntity> BlogEntryTags => Set<BlogEntryTagEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogEntryEntity>(entity =>
        {
            entity.ToTable("BlogEntries");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Entry).IsRequired();
            entity.Property(e => e.PostedDate).IsRequired();
        });

        modelBuilder.Entity<TagEntity>(entity =>
        {
            entity.ToTable("Tags");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LookupID).IsRequired().HasMaxLength(128);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
        });

        modelBuilder.Entity<BlogEntryTagEntity>(entity =>
        {
            entity.ToTable("BlogEntryTags");
            entity.HasKey(e => new { e.BlogEntryId, e.TagId });

            entity.HasOne(e => e.BlogEntry)
                  .WithMany(e => e.BlogEntryTags)
                  .HasForeignKey(e => e.BlogEntryId);

            entity.HasOne(e => e.Tag)
                  .WithMany(e => e.BlogEntryTags)
                  .HasForeignKey(e => e.TagId);
        });
    }
}
