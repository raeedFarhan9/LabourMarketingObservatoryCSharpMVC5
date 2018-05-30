using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaburMarketObservatoryMVC5.Models;
using Microsoft.AspNet.Identity;

namespace LaburMarketObservatoryMVC5.Controllers
{
    public class JobOffersController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: JobOffers
        public ActionResult Index()
        {
            var jobOffers = db.JobOffers.Include(j => j.AspNetUser);
            return View(jobOffers.ToList());
        }

        // GET: JobOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "advert_id,aspNetUsersId,offer_emp_num,offer_type_of_employment,offer_certificate,offer_specialization,offer_experience_years,offer_gender,offer_age,offer_address,offer_working_hours,offer_salary,offer_active,offer_publishDate")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                jobOffer.aspNetUsersId = User.Identity.GetUserId();
                jobOffer.offer_publishDate = DateTime.Now;

                db.JobOffers.Add(jobOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobOffer.aspNetUsersId);
            return View(jobOffer);
        }

        // GET: JobOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobOffer.aspNetUsersId);
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "advert_id,aspNetUsersId,offer_emp_num,offer_type_of_employment,offer_certificate,offer_specialization,offer_experience_years,offer_gender,offer_age,offer_address,offer_working_hours,offer_salary,offer_active,offer_publishDate")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                jobOffer.aspNetUsersId = User.Identity.GetUserId();
                jobOffer.offer_publishDate = DateTime.Now;

                db.Entry(jobOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobOffer.aspNetUsersId);
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            db.JobOffers.Remove(jobOffer);
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
