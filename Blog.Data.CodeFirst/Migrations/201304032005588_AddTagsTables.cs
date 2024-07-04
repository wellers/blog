namespace Blog.Data.CodeFirst.Migrations
{	
	using System.Data.Entity.Migrations;

	public partial class AddTagsTables : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.BlogEntryTags",
				c => new
				{
					BlogEntryId = c.Int(nullable: false),
					TagId = c.Int(nullable: false),
					Id = c.Int(nullable: false, identity: true),
				})
				.PrimaryKey(t => new { t.BlogEntryId, t.TagId })
				.ForeignKey("dbo.BlogEntries", t => t.BlogEntryId, cascadeDelete: false)
				.ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: false)
				.Index(t => t.BlogEntryId)
				.Index(t => t.TagId);

			CreateTable(
				"dbo.Tags",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					LookupID = c.String(maxLength: 100),
					Name = c.String(maxLength: 100),
				})
				.PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropIndex("dbo.BlogEntryTags", new[] { "TagId" });
			DropIndex("dbo.BlogEntryTags", new[] { "BlogEntryId" });
			DropForeignKey("dbo.BlogEntryTags", "TagId", "dbo.Tags");
			DropForeignKey("dbo.BlogEntryTags", "BlogEntryId", "dbo.BlogEntries");
			DropTable("dbo.Tags");
			DropTable("dbo.BlogEntryTags");
		}
	}
}
