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
    public class CompanyQuestionnairesController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: CompanyQuestionnaires
        public ActionResult Index()
        {
            var companyQuestionnaires = db.CompanyQuestionnaires.Include(c => c.AspNetUser);
            return View(companyQuestionnaires.ToList());
        }

        // GET: CompanyQuestionnaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyQuestionnaire companyQuestionnaire = db.CompanyQuestionnaires.Find(id);
            if (companyQuestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(companyQuestionnaire);
        }

        // GET: CompanyQuestionnaires/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: CompanyQuestionnaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "comp_qus_id,aspNetUsersId,Comunication,analysis_skills,leaning,leadership,problem_solving,efficiency,practical_experience,high_pay,accepting_without_desier,emigration,focus_on_practice,update_content,team_team_work")] CompanyQuestionnaire companyQuestionnaire)
        {
            if (ModelState.IsValid)
            {
                companyQuestionnaire.aspNetUsersId = User.Identity.GetUserId();

                db.CompanyQuestionnaires.Add(companyQuestionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", companyQuestionnaire.aspNetUsersId);
            return View(companyQuestionnaire);
        }

        // GET: CompanyQuestionnaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyQuestionnaire companyQuestionnaire = db.CompanyQuestionnaires.Find(id);
            if (companyQuestionnaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", companyQuestionnaire.aspNetUsersId);
            return View(companyQuestionnaire);
        }

        // POST: CompanyQuestionnaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "comp_qus_id,aspNetUsersId,Comunication,analysis_skills,leaning,leadership,problem_solving,efficiency,practical_experience,high_pay,accepting_without_desier,emigration,focus_on_practice,update_content,team_team_work")] CompanyQuestionnaire companyQuestionnaire)
        {
            if (ModelState.IsValid)
            {
                companyQuestionnaire.aspNetUsersId = User.Identity.GetUserId();

                db.Entry(companyQuestionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", companyQuestionnaire.aspNetUsersId);
            return View(companyQuestionnaire);
        }

        // GET: CompanyQuestionnaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyQuestionnaire companyQuestionnaire = db.CompanyQuestionnaires.Find(id);
            if (companyQuestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(companyQuestionnaire);
        }

        // POST: CompanyQuestionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyQuestionnaire companyQuestionnaire = db.CompanyQuestionnaires.Find(id);
            db.CompanyQuestionnaires.Remove(companyQuestionnaire);
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
