using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core;

namespace FA.JustBlog.Presentation.Controllers
{
    public class PostsController : Controller
    {

        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        ////GET: Posts
        public ActionResult Index()
        {
            var post = _postService.GetAll();
            return View(post);
        }

        [ChildActionOnly]
        public ActionResult MostViewedPosts()
        {
            var mostPost = _postService.GetMostViewedPost(5);
            return PartialView("_ListPosts", mostPost);
        }

        [ChildActionOnly]
        public ActionResult LatestPostsinside()
        {
            var lastPost = _postService.GetLastsPost(5);
            return PartialView("_ListPosts", lastPost);
        }
        public ActionResult ShowPostByCategory(string categoryName)
        {
            var posts = _postService.GetPostByCategory(categoryName);
            return View(posts);
        }
        public ActionResult Details(int year, int month, string title)
        {
            var post = _postService.FindPost(year, month, title);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }
    }
}