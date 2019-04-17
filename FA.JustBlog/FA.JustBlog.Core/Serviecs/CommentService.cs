using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core
{
    public class CommentService: BaseService<Comment>, ICommentService
    {
        public CommentService(IGenericRepository<Comment> genericRepository) : base(genericRepository)
        {
        }

        public IEnumerable<Comment> GetCommentByPost(string postId)
        {
            return GetAll().Where(p => p.Id.ToString().Equals(postId)).ToList();
        }
    }
}
