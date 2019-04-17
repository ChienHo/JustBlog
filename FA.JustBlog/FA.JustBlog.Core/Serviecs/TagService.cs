using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core
{
    public class TagService : BaseService<Tag>, ITagService

    {
        private readonly JustBlogContext _context;
        public TagService(IGenericRepository<Tag> genericRepository, JustBlogContext context) : base(genericRepository)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetTopTag(int size)
        {
            return GetAll().OrderByDescending(p => p.Id).Take(size);
        }

        public Tag GetTag(string name)
        {
            return _context.Tags.Where(t => t.Name == name).FirstOrDefault();
        }
    }
}
