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
    public class ProducerMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProducerMembers
        public ActionResult Index()
        {
            var producerMembers = db.ProducerMembers.Include(p => p.DVDDetails).Include(p => p.ProducerDetails);
            return View(producerMembers.ToList());
        }

        // GET: ProducerMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerMember producerMember = db.ProducerMembers.Find(id);
            if (producerMember == null)
            {
                return HttpNotFound();
            }
            return View(producerMember);
        }

        // GET: ProducerMembers/Create
        public ActionResult Create()
        {
            ViewBag.DVDDetailId = new SelectList(db.DVDDetails, "Id", "DVDName");
            ViewBag.ProducerDetailId = new SelectList(db.ProducerDetails, "Id", "FirstName");
            return View();
        }

        // POST: ProducerMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DVDDetailId,ProducerDetailId")] ProducerMember producerMember)
        {
            if (ModelState.IsValid)
            {
                db.ProducerMembers.Add(producerMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDDetailId = new SelectList(db.DVDDetails, "Id", "DVDName", producerMember.DVDDetailId);
            ViewBag.ProducerDetailId = new SelectList(db.ProducerDetails, "Id", "FirstName", producerMember.ProducerDetailId);
            return View(producerMember);
        }

        // GET: ProducerMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerMember producerMember = db.ProducerMembers.Find(id);
            if (producerMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDDetailId = new SelectList(db.DVDDetails, "Id", "DVDName", producerMember.DVDDetailId);
            ViewBag.ProducerDetailId = new SelectList(db.ProducerDetails, "Id", "FirstName", producerMember.ProducerDetailId);
            return View(producerMember);
        }

        // POST: ProducerMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DVDDetailId,ProducerDetailId")] ProducerMember producerMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producerMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDDetailId = new SelectList(db.DVDDetails, "Id", "DVDName", producerMember.DVDDetailId);
            ViewBag.ProducerDetailId = new SelectList(db.ProducerDetails, "Id", "FirstName", producerMember.ProducerDetailId);
            return View(producerMember);
        }

        // GET: ProducerMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducerMember producerMember = db.ProducerMembers.Find(id);
            if (producerMember == null)
            {
                return HttpNotFound();
            }
            return View(producerMember);
        }

        // POST: ProducerMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducerMember producerMember = db.ProducerMembers.Find(id);
            db.ProducerMembers.Remove(producerMember);
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
