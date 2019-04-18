using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core;

namespace FA.JustBlog.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators,Contributor,User")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators,Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UrlSlug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _categoryService.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators,Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UrlSlug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize(Roles = "Administrators,Contributor")]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
