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
    public class SkillsController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: Skills
        public ActionResult Index()
        {
            var skills = db.Skills.Include(s => s.JobOffer).Include(s => s.JobSeeker);
            return View(skills.ToList());
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            ViewBag.offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId");
            ViewBag.seeker_id = new SelectList(db.JobSeekers, "aspNetUsersId", "seeker_certificate");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "skill_id,offer_id,seeker_id,skill_name")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", skill.offer_id);
            ViewBag.seeker_id = new SelectList(db.JobSeekers, "aspNetUsersId", "seeker_certificate", skill.seeker_id);
            return View(skill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", skill.offer_id);
            ViewBag.seeker_id = new SelectList(db.JobSeekers, "aspNetUsersId", "seeker_certificate", skill.seeker_id);
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "skill_id,offer_id,seeker_id,skill_name")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.offer_id = new SelectList(db.JobOffers, "advert_id", "aspNetUsersId", skill.offer_id);
            ViewBag.seeker_id = new SelectList(db.JobSeekers, "aspNetUsersId", "seeker_certificate", skill.seeker_id);
            return View(skill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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
