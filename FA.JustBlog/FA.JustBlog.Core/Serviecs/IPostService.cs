using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core
{
    public interface IPostService : IBaseService<Post>
    {
        IEnumerable<Post> GetLastsPost(int size);
        IEnumerable<Post> GetByMonth(DateTime monthYear);
        int CountPostForCategory(string category);
        IEnumerable<Post> GetPostByCategory(string category);
        int CountPostForTag(string tag);
        IEnumerable<Post> GetPostByTag(string tag);
        IEnumerable<Post> GetMostViewedPost(int size);
        IEnumerable<Post> GetHighestPosts(int size);
        Post FindPost(int year, int month, string title);
    }
}