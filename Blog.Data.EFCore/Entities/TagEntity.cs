namespace Blog.Data.EFCore.Entities;

public class TagEntity
{
    public int Id { get; set; }
    public string LookupID { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ICollection<BlogEntryTagEntity> BlogEntryTags { get; set; } = [];
}
