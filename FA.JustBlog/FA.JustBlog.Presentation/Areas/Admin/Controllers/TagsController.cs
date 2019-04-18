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
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: Admin/Tags
        public ActionResult Index()
        {
            return View(_tagService.GetAll());
        }

        // GET: Admin/Tags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tag tag = _tagService.GetById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators,Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.Add(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagService.GetById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Admin/Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators,Contributor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UrlSlug,Description")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.Update(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Admin/Tags/Delete/5
        [Authorize(Roles = "Administrators,Contributor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagService.GetById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // POST: Admin/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tagService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tagService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
