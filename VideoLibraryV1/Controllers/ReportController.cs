using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibraryV1.Models;

namespace VideoLibraryV1.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DateTime currentDate;

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        //Task1
        public ActionResult FilterByLastName(string LastName)
        {
            ViewBag.LastName = db.CastDetails.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                return View();
            }
            var data = db.CastMembers.Include("DVDDetails").Include("CastDetails")
                .Where(x => x.CastDetails.LastName == LastName).ToList();
            return View(data);
        }
        //Task 2
        public ActionResult FilterByLastNameDVDOnShelf(string LastName)
        {
            ViewBag.LastName = db.CastDetails.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                return View();
            }
            List<DVDDetail> data = (from dd in db.DVDDetails
                                      join cm in db.CastMembers on dd.Id equals cm.DVDDetailId
                                      join cd in db.CastDetails on cm.CastDetailId equals cd.Id
                                      join l in db.Loans on dd.Id equals l.DVDDetailId into loans
                                      from l in loans.Where(ln => ln.ReturnedDate == null).DefaultIfEmpty()
                                      where cd.LastName.Contains(LastName)
                                      select dd).Distinct().ToList();
            return View(data);

        }

        //Task 4
        public ActionResult Fourth()
        {
            List<FourthFunction> data = new List<FourthFunction>();

            var dVDDetails = (from dd in db.DVDDetails
                              orderby dd.ReleasedDate
                              select dd).ToList();

            foreach (DVDDetail dVDDetail in dVDDetails)
            {
                FourthFunction datas = new FourthFunction();
                datas.DVDDetail = dVDDetail;
                datas.ProducerDetails = (from pm in db.ProducerMembers
                                         join p in db.ProducerDetails on pm.Id equals p.Id
                                         where pm.DVDDetailId == dVDDetail.Id
                                         select p).ToList();
                datas.CastDetails = (from cm in db.CastMembers
                                     join cd in db.CastDetails on cm.CastDetailId equals cd.Id
                                     where cm.DVDDetailId == dVDDetail.Id
                                     orderby cd.LastName
                                     select cd).ToList();
                data.Add(datas);
            }

            return View(data);
        }

            //Task3
        public ActionResult FilterByLastLoaned(string LastName)

        {
            ViewBag.LastName = db.MemberDetails.ToList();
            if (String.IsNullOrEmpty(LastName))
            {
                return View();
            }
            currentDate = DateTime.Now;
            var data = db.Loans.Where(x => DbFunctions.DiffDays(x.IssuedDate, currentDate) < 31)
                .Include("MemberDetails").Where(y => y.MemberDetails.LastName == LastName).ToList();
            return View(data);

        }


        /* public ActionResult FunctionNo8()
         {
             var data = (from l in db.Loans
                             // where l.ReturnedDate == null
                         group l by new { l.MemberId } into table1
                         select new LoanViewModel
                         {
                             NumberOfLoans = table1.Count(),
                             MemberId = table1.Key.MemberId,


                         }).ToList();

             var d = (from l i
 */


    }
}