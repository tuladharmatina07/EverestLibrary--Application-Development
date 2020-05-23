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
    public class MemberDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MemberDetails
        public ActionResult Index()
        {
            var memberDetails = db.MemberDetails.Include(m => m.MemberCategories);
            return View(memberDetails.ToList());
        }

        // GET: MemberDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDetail memberDetail = db.MemberDetails.Find(id);
            if (memberDetail == null)
            {
                return HttpNotFound();
            }
            return View(memberDetail);
        }

        // GET: MemberDetails/Create
        public ActionResult Create()
        {
            ViewBag.MemberCategoryId = new SelectList(db.MemberCategories, "Id", "CategoryName");
            return View();
        }

        // POST: MemberDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,Email,PhoneNumber,DateOfBirth,MemberCategoryId")] MemberDetail memberDetail)
        {
            if (ModelState.IsValid)
            {
                db.MemberDetails.Add(memberDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberCategoryId = new SelectList(db.MemberCategories, "Id", "CategoryName", memberDetail.MemberCategoryId);
            return View(memberDetail);
        }

        // GET: MemberDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDetail memberDetail = db.MemberDetails.Find(id);
            if (memberDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberCategoryId = new SelectList(db.MemberCategories, "Id", "CategoryName", memberDetail.MemberCategoryId);
            return View(memberDetail);
        }

        // POST: MemberDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Email,PhoneNumber,DateOfBirth,MemberCategoryId")] MemberDetail memberDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberCategoryId = new SelectList(db.MemberCategories, "Id", "CategoryName", memberDetail.MemberCategoryId);
            return View(memberDetail);
        }

        // GET: MemberDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberDetail memberDetail = db.MemberDetails.Find(id);
            if (memberDetail == null)
            {
                return HttpNotFound();
            }
            return View(memberDetail);
        }

        // POST: MemberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberDetail memberDetail = db.MemberDetails.Find(id);
            db.MemberDetails.Remove(memberDetail);
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
