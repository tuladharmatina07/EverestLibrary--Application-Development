using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoLibraryV1.Models;

namespace VideoLibraryV1.Controllers
{
    public class CastDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CastDetails
        public ActionResult Index()
        {
            return View(db.CastDetails.ToList());
        }

        // GET: CastDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastDetail castDetail = db.CastDetails.Find(id);
            if (castDetail == null)
            {
                return HttpNotFound();
            }
            return View(castDetail);
        }

        // GET: CastDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CastDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,Email,DateOfBirth")] CastDetail castDetail)
        {
            if (ModelState.IsValid)
            {
                db.CastDetails.Add(castDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castDetail);
        }

        // GET: CastDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastDetail castDetail = db.CastDetails.Find(id);
            if (castDetail == null)
            {
                return HttpNotFound();
            }
            return View(castDetail);
        }

        // POST: CastDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email,DateOfBirth")] CastDetail castDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(castDetail);
        }

        // GET: CastDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastDetail castDetail = db.CastDetails.Find(id);
            if (castDetail == null)
            {
                return HttpNotFound();
            }
            return View(castDetail);
        }

        // POST: CastDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastDetail castDetail = db.CastDetails.Find(id);
            db.CastDetails.Remove(castDetail);
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
