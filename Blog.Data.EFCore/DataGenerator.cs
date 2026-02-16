using Blog.Data.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EFCore;

public static class DataGenerator
{
	public static async Task InitialiseAsync(MongoDbContext context)
	{
		await context.Database.EnsureCreatedAsync();
		context.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

		var blogs = new[]
		{
			new BlogEntryEntity
			{
				Title = "My first blog entry",
				Entry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec a diam lectus. Sed sit amet ipsum mauris. Maecenas congue ligula ac quam viverra nec consectetur ante hendrerit. Donec et mollis dolor. Praesent et diam eget libero egestas mattis sit amet vitae augue.",
				PostedDate = DateTime.UtcNow,
				Tags = ["Lorem", "Ipsum", "Dolor"]
			},
			new BlogEntryEntity
			{
				Title = "My second blog entry",
				Entry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec a diam lectus. Sed sit amet ipsum mauris. Maecenas congue ligula ac quam viverra nec consectetur ante hendrerit. Donec et mollis dolor. Praesent et diam eget libero egestas mattis sit amet vitae augue.",
				PostedDate = DateTime.UtcNow,
				Tags = ["Lorem", "Ipsum", "Dolor"]
			},
			new BlogEntryEntity
			{
				Title = "My third blog entry",
				Entry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec a diam lectus. Sed sit amet ipsum mauris. Maecenas congue ligula ac quam viverra nec consectetur ante hendrerit. Donec et mollis dolor. Praesent et diam eget libero egestas mattis sit amet vitae augue.",
				PostedDate = DateTime.UtcNow,
				Tags = ["Lorem", "Ipsum", "Dolor"]
			}
		};

		await context.BlogEntries.AddRangeAsync(blogs);
		await context.SaveChangesAsync();
	}
}