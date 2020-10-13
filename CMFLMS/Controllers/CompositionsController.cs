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

namespace CMFLMS.Controllers
{
    public class CompositionsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Compositions
        public ActionResult Index(int? page)
        {
            var compositions = db.compositions.OrderBy(c => c.CompositionName);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.compositions.ToList().Count();
            }
            return View(compositions.ToList().ToPagedList(page ?? 1, 100));
        }
        public ActionResult CompositionReport()
        {
            var composition = db.compositions.OrderBy(c => c.CompositionName);
            ViewBag.Count = db.compositions.ToList().Count();
            return View(composition.ToList());
        }

        // GET: Compositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // GET: Compositions/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompositionId,CompositionName,Remarks")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                db.compositions.Add(composition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(composition);
        }

        // GET: Compositions/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // POST: Compositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompositionId,CompositionName,Remarks")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(composition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(composition);
        }

        // GET: Compositions/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composition composition = db.compositions.Find(id);
            if (composition == null)
            {
                return HttpNotFound();
            }
            return View(composition);
        }

        // POST: Compositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Composition composition = db.compositions.Find(id);
            db.compositions.Remove(composition);
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
