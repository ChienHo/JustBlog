using System.Collections.Generic;

namespace FA.JustBlog.Core
{
    public interface ITagService:IBaseService<Tag>
    {
        IEnumerable<Tag> GetTopTag(int size);
        Tag GetTag(string name);
    }
}
