using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core
{
    public class PostService : BaseService<Post>, IPostService
    {
        private JustBlogContext _justBlogContext;
        public PostService(IGenericRepository<Post> genericRepository) : base(genericRepository)
        {
        }
        public int CountPostForCategory(string category)
        {
            return GetAll().Count(p => p.Category.Name.Equals(category));
        }

        public int CountPostForTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> FindPost(int year, int month, string title)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Post> FindPost(int year, int month, string title)
        //{
        //   return  JustBlogContext
        //}

        public IEnumerable<Post> GetByMonth(DateTime monthYear)
        {
            var month = monthYear.Month;
            var year = monthYear.Year;
            return GetAll().Where(p =>
                p.PostedOn.GetValueOrDefault(DateTime.MinValue).Month == month &&
                p.PostedOn.GetValueOrDefault(DateTime.MaxValue).Year == year).ToList();
        }

        public IEnumerable<Post> GetHighestPosts(int size)
        {
            return GetAll().OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IEnumerable<Post> GetLastsPost(int size)
        {
            return GetAll().OrderByDescending(t => t.PostedOn).Take(size).ToList();
        }

        public IEnumerable<Post> GetMostViewedPost(int size)
        {
            return GetAll().OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IEnumerable<Post> GetPostByCategory(string category)
        {
            return GetAll().Where(p => p.Category.Name.Contains(category)).ToList();
        }

        public IEnumerable<Post> GetPostByTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
