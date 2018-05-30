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
    public class SeekerQuestionnairesController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: SeekerQuestionnaires
        public ActionResult Index()
        {
            var seekerQuestionnaires = db.SeekerQuestionnaires.Include(s => s.AspNetUser);
            return View(seekerQuestionnaires.ToList());
        }

        // GET: SeekerQuestionnaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeekerQuestionnaire seekerQuestionnaire = db.SeekerQuestionnaires.Find(id);
            if (seekerQuestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(seekerQuestionnaire);
        }

        // GET: SeekerQuestionnaires/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: SeekerQuestionnaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "seeker_quis_id,aspNetUsersId,no_suitable_opportunity,low_pay,routine,long_job_seeking,not_enough_experience,contract,kill_creativity,update_content,traning,keep_updated,field_trips")] SeekerQuestionnaire seekerQuestionnaire)
        {
            if (ModelState.IsValid)
            {
                seekerQuestionnaire.aspNetUsersId = User.Identity.GetUserId();

                db.SeekerQuestionnaires.Add(seekerQuestionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", seekerQuestionnaire.aspNetUsersId);
            return View(seekerQuestionnaire);
        }

        // GET: SeekerQuestionnaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeekerQuestionnaire seekerQuestionnaire = db.SeekerQuestionnaires.Find(id);
            if (seekerQuestionnaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", seekerQuestionnaire.aspNetUsersId);
            return View(seekerQuestionnaire);
        }

        // POST: SeekerQuestionnaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "seeker_quis_id,aspNetUsersId,no_suitable_opportunity,low_pay,routine,long_job_seeking,not_enough_experience,contract,kill_creativity,update_content,traning,keep_updated,field_trips")] SeekerQuestionnaire seekerQuestionnaire)
        {
            if (ModelState.IsValid)
            {
                seekerQuestionnaire.aspNetUsersId = User.Identity.GetUserId();

                db.Entry(seekerQuestionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", seekerQuestionnaire.aspNetUsersId);
            return View(seekerQuestionnaire);
        }

        // GET: SeekerQuestionnaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeekerQuestionnaire seekerQuestionnaire = db.SeekerQuestionnaires.Find(id);
            if (seekerQuestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(seekerQuestionnaire);
        }

        // POST: SeekerQuestionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeekerQuestionnaire seekerQuestionnaire = db.SeekerQuestionnaires.Find(id);
            db.SeekerQuestionnaires.Remove(seekerQuestionnaire);
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
