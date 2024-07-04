namespace Blog.Data.CodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateExistingBlogEntriesForTags : DbMigration
	{
		public override void Up()
		{
			Sql(@"
                INSERT INTO Tags (LookupId, Name)
                SELECT 'csharp', 'C#' UNION ALL
                SELECT 'dotnet', '.NET' UNION ALL
                SELECT 'wcf', 'WCF'");
		}

		public override void Down()
		{
			Sql("DELETE FROM Tags;");
		}
	}
}
