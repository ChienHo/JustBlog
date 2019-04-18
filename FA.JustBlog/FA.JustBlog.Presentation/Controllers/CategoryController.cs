using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core;

namespace FA.JustBlog.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBaseService<Category> _categoryService;
        private readonly IPostService _postService;

        public CategoryController(BaseService<Category> categoryService, PostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ShowCategory()
        {
            var allCate = _categoryService.GetAll();
            return PartialView("_MenuPartial", allCate);
        }
        public ActionResult ShowPostByCategory(string categoryName)
        {
            var posts = _postService.GetPostByCategory(categoryName);
            return PartialView("_MenuPartial", posts);
        }
    }
}