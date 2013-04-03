namespace Blog.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExistingBlogEntriesForTags : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO Tags (LookupId, Name)
                SELECT 'CSHARP', 'C#' UNION ALL
                SELECT 'DOTNET', '.NET' UNION ALL
                SELECT 'WCF', 'WCF'");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Tags;");
        }
    }
}
