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
    public class SuppliersController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult Report()
        {
            var suppliers = db.suppliers.Include(s => s.categories).OrderBy(s => s.SupplierName);
            using (var con = new LibraryContext())
            {
                ViewBag.count = db.suppliers.ToList().Count();
            }
            return View(suppliers.ToList());
        }
        // GET: Suppliers
        public ActionResult Index(int? page)//
        {
            
            var suppliers = db.suppliers.Include(s => s.categories).OrderBy(s=>s.SupplierName);
            using (var con = new LibraryContext())
            {
                ViewBag.count = db.suppliers.ToList().Count();
            }
            return View(suppliers.ToList().ToPagedList(page ?? 1, 100));//
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        [AuthorizeUsers]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.categories.OrderBy(c=>c.CategoryName), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,SupplierName,ContactPerson,Address,Telephone,Email,AddedDate,CategoryId")] Supplier supplier)
        {
            
            var errors = ModelState
    .Where(x => x.Value.Errors.Count > 0)
    .Select(x => new { x.Key, x.Value.Errors })
    .ToArray();
            if (ModelState.IsValid)
            {
                db.suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.categories.OrderBy(c=>c.CategoryName), "CategoryId", "CategoryName", supplier.CategoryId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.categories.OrderBy(c=>c.CategoryName), "CategoryId", "CategoryName",  supplier.CategoryId);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,SupplierName,ContactPerson,Address,Telephone,Email,AddedDate,CategoryId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.categories.OrderBy(c=>c.CategoryName), "CategoryId", "CategoryName", supplier.CategoryId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        [Authorize(Roles = "SuperAdmin,MainAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.suppliers.Find(id);
            db.suppliers.Remove(supplier);
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
