using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core;

namespace FA.JustBlog.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators,Contributor,User")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public PostsController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View(_postService.GetAll());
        }
        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = _postService.GetById(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific 
        [Authorize(Roles = "Administrators,Contributor")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,ShortDescription,Description,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate,ImgUrl")] Post post, string valueTag, HttpPostedFileBase ImgUrl)
        {

            string fileName = "";
            if (ImgUrl != null && ImgUrl.ContentLength > 0)
            {
                try
                {
                    fileName = Path.GetFileName(ImgUrl.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Theme/img"), Path.GetFileName(ImgUrl.FileName));
                    ImgUrl.SaveAs(path);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            post.ImgUrl = fileName;
            var listTags = new List<Tag>();
            if (!string.IsNullOrEmpty(valueTag))
            {
                var listTag = valueTag.Split(new string[] {","},StringSplitOptions.RemoveEmptyEntries);
                foreach (var value in listTag)
                {
                    var tag = _tagService.GetTag(value);
                    Tag tags = new Tag();
                    if (tag == null)
                    {
                        tags = new Tag() { Name = value, Description = value };
                    }
                    listTags.Add(tags);

                }
            }
            if (ModelState.IsValid)
            {

                post.Tags = listTags;
                _postService.Add(post);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = _postService.GetById(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,ShortDescription,Description,Meta,UrlSlug,Published,PostedOn,Modified,CategoryId,ViewCount,RateCount,TotalRate,ImgUrl")] Post post , HttpPostedFileBase ImgUrl)
        {
            if (ImgUrl != null && ImgUrl.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/Theme/img"), Path.GetFileName(ImgUrl.FileName));
                ImgUrl.SaveAs(filePath);
                post.ImgUrl = ImgUrl.FileName;
            }
            if (ModelState.IsValid)
            {
               
                _postService.Update(post);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Name", post.CategoryId);
            return View(post);
        }

        [Authorize(Roles = "Administrators,Contributor")]
        public ActionResult Delete(int id)
        {
            _postService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _postService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
