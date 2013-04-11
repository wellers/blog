namespace Blog.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreaseLengthOfEntry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("BlogEntries", "Entry", c => c.String());
        }
    }
}
