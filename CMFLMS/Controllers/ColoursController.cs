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
    public class ColoursController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Colours
        public ActionResult Index(int? page)
        {
            var colour = db.colours.OrderBy(c => c.ColourName);
            using (var con = new LibraryContext())
            {
                ViewBag.count = db.colours.ToList().Count();
            }
            return View(colour.ToList().ToPagedList(page ?? 1, 100));
        }
        public ActionResult ColourReport()
        {
            var colours = db.colours.OrderBy(c => c.ColourName);
            ViewBag.Count = db.colours.ToList().Count();
            return View(colours.ToList());
        }

        // GET: Colours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // GET: Colours/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ColourId,ColourName,Remarks")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.colours.Add(colour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colour);
        }

        // GET: Colours/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ColourId,ColourName,Remarks")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colour);
        }

        // GET: Colours/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colour colour = db.colours.Find(id);
            db.colours.Remove(colour);
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
