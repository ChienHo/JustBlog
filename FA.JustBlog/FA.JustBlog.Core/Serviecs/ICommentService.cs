using System;
using System.Collections.Generic;

namespace FA.JustBlog.Core
{
    public interface ICommentService:IBaseService<Comment>,IDisposable
    {
        IEnumerable<Comment> GetCommentByPost(string postId);
    }
}
