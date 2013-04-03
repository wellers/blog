using Blog.Interfaces.Models;

namespace Blog.Models
{
    public class TagModel : BaseModel, ITagModel
    {
        public string LookupID { get; set; }
        public string Name { get; set; }
    }
}
