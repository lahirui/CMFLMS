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
    public class FabCatoesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: FabCatoes
        public ActionResult Index(int? page)
        {
            var fabcats = db.fabcatos.OrderBy(f => f.FabricCat);
            using (var con = new LibraryContext())
            {
                ViewBag.count = con.fabcatos.ToList().Count();
            }
            return View(db.fabcatos.ToList().ToPagedList(page ?? 1, 100));
        }

        // GET: FabCatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabCato fabCato = db.fabcatos.Find(id);
            if (fabCato == null)
            {
                return HttpNotFound();
            }
            return View(fabCato);
        }

        // GET: FabCatoes/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabCatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FabCatoId,FabricCat,Remarks")] FabCato fabCato)
        {
            if (ModelState.IsValid)
            {
                db.fabcatos.Add(fabCato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabCato);
        }

        // GET: FabCatoes/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabCato fabCato = db.fabcatos.Find(id);
            if (fabCato == null)
            {
                return HttpNotFound();
            }
            return View(fabCato);
        }

        // POST: FabCatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FabCatoId,FabricCat,Remarks")] FabCato fabCato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabCato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabCato);
        }

        // GET: FabCatoes/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabCato fabCato = db.fabcatos.Find(id);
            if (fabCato == null)
            {
                return HttpNotFound();
            }
            return View(fabCato);
        }

        // POST: FabCatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FabCato fabCato = db.fabcatos.Find(id);
            db.fabcatos.Remove(fabCato);
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
