namespace Blog.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstBlogEntry : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO BlogEntries (Title, Entry, PostedDate)
                SELECT 'A great day has shined upon us...',
                '<div><p>This is my first blog post on my first live Dot Net blog. Hooray!</p></div>',
                GETDATE()
            ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM BlogEntries WHERE Title = 'A great day has shined upon us...'");
        }
    }
}
