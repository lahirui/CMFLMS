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
    public class FinishCatoesController : Controller
    {
        private LibraryContext db = new LibraryContext();
        public ActionResult FinishingReport()
        {
            ViewBag.count = db.finishingCato.ToList().Count();
            return View(db.finishingCato.OrderBy(f => f.FinishCat).ToList());
        }
        // GET: FinishCatoes
        public ActionResult Index(int? page)
        {
            ViewBag.count = db.finishingCato.ToList().Count();
            return View(db.finishingCato.OrderBy(f=>f.FinishCat).ToList().ToPagedList(page ?? 1, 100));
        }

        // GET: FinishCatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishCato finishCato = db.finishingCato.Find(id);
            if (finishCato == null)
            {
                return HttpNotFound();
            }
            return View(finishCato);
        }

        // GET: FinishCatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinishCatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinishCatoId,FinishCat,Remarks")] FinishCato finishCato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    finishCato.FinishCat = finishCato.FinishCat.ToUpper();
                    if (finishCato.Remarks == null || finishCato.Remarks == "")
                    {
                        finishCato.Remarks = "NA";
                    }
                    finishCato.Remarks = finishCato.Remarks.ToUpper();
                    db.finishingCato.Add(finishCato);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View(finishCato);
            }
            return View(finishCato);
        }

        // GET: FinishCatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishCato finishCato = db.finishingCato.Find(id);
            if (finishCato == null)
            {
                return HttpNotFound();
            }
            return View(finishCato);
        }

        // POST: FinishCatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinishCatoId,FinishCat,Remarks")] FinishCato finishCato)
        {
            if (ModelState.IsValid)
            {
                finishCato.FinishCat = finishCato.FinishCat.ToUpper();
                finishCato.Remarks = finishCato.Remarks.ToUpper();
                db.Entry(finishCato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finishCato);
        }

        // GET: FinishCatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishCato finishCato = db.finishingCato.Find(id);
            if (finishCato == null)
            {
                return HttpNotFound();
            }
            return View(finishCato);
        }

        // POST: FinishCatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishCato finishCato = db.finishingCato.Find(id);
            db.finishingCato.Remove(finishCato);
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
