using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaburMarketObservatoryMVC5.Models;

namespace LaburMarketObservatoryMVC5.Controllers
{
    public class ApplicantToJobOffersController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: ApplicantToJobOffers
        public ActionResult Index()
        {
            var applicantToJobOffers = db.ApplicantToJobOffers.Include(a => a.AspNetUser).Include(a => a.JobOffer);
            return View(applicantToJobOffers.ToList());
        }

        // GET: ApplicantToJobOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantToJobOffer applicantToJobOffer = db.ApplicantToJobOffers.Find(id);
            if (applicantToJobOffer == null)
            {
                return HttpNotFound();
            }
            return View(applicantToJobOffer);
        }

        // GET: ApplicantToJobOffers/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.job_offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId");
            return View();
        }

        // POST: ApplicantToJobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "job_offer_id,aspNetUsersId,note")] ApplicantToJobOffer applicantToJobOffer)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantToJobOffers.Add(applicantToJobOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", applicantToJobOffer.aspNetUsersId);
            ViewBag.job_offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", applicantToJobOffer.job_offer_id);
            return View(applicantToJobOffer);
        }

        // GET: ApplicantToJobOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantToJobOffer applicantToJobOffer = db.ApplicantToJobOffers.Find(id);
            if (applicantToJobOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", applicantToJobOffer.aspNetUsersId);
            ViewBag.job_offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", applicantToJobOffer.job_offer_id);
            return View(applicantToJobOffer);
        }

        // POST: ApplicantToJobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "job_offer_id,aspNetUsersId,note")] ApplicantToJobOffer applicantToJobOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantToJobOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", applicantToJobOffer.aspNetUsersId);
            ViewBag.job_offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", applicantToJobOffer.job_offer_id);
            return View(applicantToJobOffer);
        }

        // GET: ApplicantToJobOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantToJobOffer applicantToJobOffer = db.ApplicantToJobOffers.Find(id);
            if (applicantToJobOffer == null)
            {
                return HttpNotFound();
            }
            return View(applicantToJobOffer);
        }

        // POST: ApplicantToJobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantToJobOffer applicantToJobOffer = db.ApplicantToJobOffers.Find(id);
            db.ApplicantToJobOffers.Remove(applicantToJobOffer);
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
