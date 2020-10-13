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
    public class FactoriesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Factories
        public ActionResult Index(int? page)
        {
            var factories = db.factories.OrderBy(f => f.FactoryName);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.factories.ToList().Count();
            }
            return View(factories.ToList().ToPagedList(page ?? 1, 100));
        }

        // GET: Factories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = db.factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        // GET: Factories/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FactoryId,FactoryName,Remarks")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.factories.Add(factory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factory);
        }

        // GET: Factories/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = db.factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        // POST: Factories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FactoryId,FactoryName,Remarks")] Factory factory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factory);
        }

        // GET: Factories/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factory = db.factories.Find(id);
            if (factory == null)
            {
                return HttpNotFound();
            }
            return View(factory);
        }

        // POST: Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factory factory = db.factories.Find(id);
            db.factories.Remove(factory);
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
