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
    public class ConstructionsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Constructions
        public ActionResult Index(int? page)
        {
            var constructions = db.constructions.OrderBy(c => c.ConstructionType);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.constructions.ToList().Count();
            }
            return View(constructions.ToList().ToPagedList(page ?? 1, 100));
        }
        public ActionResult ConstructionReport()
        {
            var construction = db.constructions.OrderBy(c => c.ConstructionType);
            ViewBag.Count = db.constructions.ToList().Count();
            return View(construction.ToList());
        }
        // GET: Constructions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Construction construction = db.constructions.Find(id);
            if (construction == null)
            {
                return HttpNotFound();
            }
            return View(construction);
        }

        // GET: Constructions/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Constructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConstructionId,ConstructionType,Remarks")] Construction construction)
        {
            if (ModelState.IsValid)
            {
                db.constructions.Add(construction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(construction);
        }

        // GET: Constructions/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Construction construction = db.constructions.Find(id);
            if (construction == null)
            {
                return HttpNotFound();
            }
            return View(construction);
        }

        // POST: Constructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConstructionId,ConstructionType,Remarks")] Construction construction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(construction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(construction);
        }

        // GET: Constructions/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Construction construction = db.constructions.Find(id);
            if (construction == null)
            {
                return HttpNotFound();
            }
            return View(construction);
        }

        // POST: Constructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Construction construction = db.constructions.Find(id);
            db.constructions.Remove(construction);
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
