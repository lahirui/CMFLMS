using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMFLMS.Data;
using CMFLMS.Models.Library;
using PagedList;
using PagedList.Mvc;

namespace CMFLMS.Controllers
{
    public class YarnsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Yarns
        public ActionResult Index(int? page)
        {
            var yarns = db.yarns.OrderBy(y => y.YarnCount);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.yarns.ToList().Count();
            }
            return View(yarns.ToList().ToPagedList(page ?? 1, 100));
        }
        public ActionResult YarnReport()
        {
            var yarns = db.yarns.OrderBy(y => y.YarnCount);
            ViewBag.Count = db.yarns.ToList().Count();
            return View(yarns.ToList());
        }

        // GET: Yarns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = db.yarns.Find(id);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // GET: Yarns/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yarns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YarnId,YarnCount,Remarks")] Yarn yarn)
        {
            if (ModelState.IsValid)
            {
                db.yarns.Add(yarn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yarn);
        }

        // GET: Yarns/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = db.yarns.Find(id);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // POST: Yarns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YarnId,YarnCount,Remarks")] Yarn yarn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yarn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yarn);
        }

        // GET: Yarns/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = db.yarns.Find(id);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // POST: Yarns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yarn yarn = db.yarns.Find(id);
            db.yarns.Remove(yarn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
