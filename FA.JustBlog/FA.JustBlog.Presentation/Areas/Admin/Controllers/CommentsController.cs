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
    public class CommentsController : Controller
    {
        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: Admin/Comments
        public ActionResult Index()
        {
            return View(_commentService.GetAll());
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.Add(comment);
                return RedirectToAction("Index");
            }

            return View(comment);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,CommentHeader,CommentText,CommentTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.Update(comment);
                return RedirectToAction("Index");
            }
            return View(comment);
        }
        [Authorize(Roles = "Administrators,Contributor")]
        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _commentService.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _commentService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _commentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
