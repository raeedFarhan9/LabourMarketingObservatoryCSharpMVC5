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
    public class JobSeekersController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: JobSeekers
        public ActionResult Index()
        {
            var jobSeekers = db.JobSeekers.Include(j => j.AspNetUser);
            return View(jobSeekers.ToList());
        }

        // GET: JobSeekers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // GET: JobSeekers/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: JobSeekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aspNetUsersId,seeker_certificate,seeker_specialization,seeker_experience_years,seeker_isEmployeed,seeker_image1")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                jobSeeker.aspNetUsersId = User.Identity.GetUserId();

                db.JobSeekers.Add(jobSeeker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobSeeker.aspNetUsersId);
            return View(jobSeeker);
        }

        // GET: JobSeekers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobSeeker.aspNetUsersId);
            return View(jobSeeker);
        }

        // POST: JobSeekers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aspNetUsersId,seeker_certificate,seeker_specialization,seeker_experience_years,seeker_isEmployeed,seeker_image1")] JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                jobSeeker.aspNetUsersId = User.Identity.GetUserId();

                db.Entry(jobSeeker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", jobSeeker.aspNetUsersId);
            return View(jobSeeker);
        }

        // GET: JobSeekers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: JobSeekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            JobSeeker jobSeeker = db.JobSeekers.Find(id);
            db.JobSeekers.Remove(jobSeeker);
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
