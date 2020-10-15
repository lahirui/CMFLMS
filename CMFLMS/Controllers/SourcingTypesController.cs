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

namespace CMFLMS.Controllers
{
    public class SourcingTypesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: SourcingTypes
        public ActionResult Index()
        {
            return View(db.sourcingTypes.ToList());
        }

        // GET: SourcingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourcingType sourcingType = db.sourcingTypes.Find(id);
            if (sourcingType == null)
            {
                return HttpNotFound();
            }
            return View(sourcingType);
        }

        // GET: SourcingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SourcingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SourcingTypeId,SourcingTypeName,IsDeleted,DeletedDate")] SourcingType sourcingType)
        {
            if (ModelState.IsValid)
            {
                db.sourcingTypes.Add(sourcingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sourcingType);
        }

        // GET: SourcingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourcingType sourcingType = db.sourcingTypes.Find(id);
            if (sourcingType == null)
            {
                return HttpNotFound();
            }
            return View(sourcingType);
        }

        // POST: SourcingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SourcingTypeId,SourcingTypeName,IsDeleted,DeletedDate")] SourcingType sourcingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sourcingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sourcingType);
        }

        // GET: SourcingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourcingType sourcingType = db.sourcingTypes.Find(id);
            if (sourcingType == null)
            {
                return HttpNotFound();
            }
            return View(sourcingType);
        }

        // POST: SourcingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SourcingType sourcingType = db.sourcingTypes.Find(id);
            db.sourcingTypes.Remove(sourcingType);
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
