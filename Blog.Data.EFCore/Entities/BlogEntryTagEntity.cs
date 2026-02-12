namespace Blog.Data.EFCore.Entities;

public class BlogEntryTagEntity
{
    public int BlogEntryId { get; set; }
    public BlogEntryEntity BlogEntry { get; set; } = null!;

    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;
}
