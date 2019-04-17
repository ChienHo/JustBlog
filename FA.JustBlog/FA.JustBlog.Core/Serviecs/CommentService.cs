using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core;

namespace FA.JustBlog.Core
{
    public class CommentService: BaseService<Comment>, ICommentService
    {
        public CommentService(IGenericRepository<Comment> genericRepository) : base(genericRepository)
        {
        }

        public IEnumerable<Comment> GetCommentByPost(string postId)
        {
            return GetAll().Where(p => p.CommentId.ToString().Equals(postId)).ToList();
        }
    }
}
