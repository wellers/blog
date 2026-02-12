namespace Blog.Data.EFCore.Entities;

public class BlogEntryEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Entry { get; set; } = string.Empty;
    public DateTime PostedDate { get; set; }
    public ICollection<BlogEntryTagEntity> BlogEntryTags { get; set; } = new List<BlogEntryTagEntity>();
}
