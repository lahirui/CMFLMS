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
    public class KnitsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Knits
        public ActionResult Index(int? page)
        {
            var knits = db.knits.OrderBy(k => k.KnitType);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.knits.ToList().Count();
            }
            return View(knits.ToList().ToPagedList(page ?? 1, 100));
        }

        public ActionResult KnitReport()
        {
            var knits = db.knits.OrderBy(k => k.KnitType);
            ViewBag.Count = db.knits.ToList().Count();
            return View(knits.ToList());
        }
        // GET: Knits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knit knit = db.knits.Find(id);
            if (knit == null)
            {
                return HttpNotFound();
            }
            return View(knit);
        }

        // GET: Knits/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KnitId,KnitType,Remarks")] Knit knit)
        {
            if (ModelState.IsValid)
            {
                db.knits.Add(knit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knit);
        }

        // GET: Knits/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knit knit = db.knits.Find(id);
            if (knit == null)
            {
                return HttpNotFound();
            }
            return View(knit);
        }

        // POST: Knits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KnitId,KnitType,Remarks")] Knit knit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knit);
        }

        // GET: Knits/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knit knit = db.knits.Find(id);
            if (knit == null)
            {
                return HttpNotFound();
            }
            return View(knit);
        }

        // POST: Knits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knit knit = db.knits.Find(id);
            db.knits.Remove(knit);
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
