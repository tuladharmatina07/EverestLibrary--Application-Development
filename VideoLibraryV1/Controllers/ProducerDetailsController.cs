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
    public class ProducerDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProducerDetails
        public ActionResult Index()
        {
            return View(db.ProducerDetails.ToList());
        }

        // GET: ProducerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDetail producerDetail = db.ProducerDetails.Find(id);
            if (producerDetail == null)
            {
                return HttpNotFound();
            }
            return View(producerDetail);
        }

        // GET: ProducerDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,Email,PhoneNumber,DateOfBirth")] ProducerDetail producerDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProducerDetails.Add(producerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producerDetail);
        }

        // GET: ProducerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDetail producerDetail = db.ProducerDetails.Find(id);
            if (producerDetail == null)
            {
                return HttpNotFound();
            }
            return View(producerDetail);
        }

        // POST: ProducerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email,PhoneNumber,DateOfBirth")] ProducerDetail producerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producerDetail);
        }

        // GET: ProducerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerDetail producerDetail = db.ProducerDetails.Find(id);
            if (producerDetail == null)
            {
                return HttpNotFound();
            }
            return View(producerDetail);
        }

        // POST: ProducerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerDetail producerDetail = db.ProducerDetails.Find(id);
            db.ProducerDetails.Remove(producerDetail);
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
