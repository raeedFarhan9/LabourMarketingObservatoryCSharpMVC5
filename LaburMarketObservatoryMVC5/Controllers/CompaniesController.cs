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
    public class CompaniesController : Controller
    {
        private LMO_DBEntities db = new LMO_DBEntities();

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.AspNetUser).Include(c => c.SystemLicensedCompany);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.licensed_comp_licenseNumber = new SelectList(db.SystemLicensedCompanies, "licensed_comp_licenseNumber", "licensed_comp_licenseNumber");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aspNetUsersId,comp_name,comp_special,comp_page_link,licensed_comp_licenseNumber,comp_image1,comp_image2")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.aspNetUsersId = User.Identity.GetUserId();

                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", company.aspNetUsersId);
            ViewBag.licensed_comp_licenseNumber = new SelectList(db.SystemLicensedCompanies, "licensed_comp_licenseNumber", "licensed_comp_licenseNumber", company.licensed_comp_licenseNumber);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", company.aspNetUsersId);
            ViewBag.licensed_comp_licenseNumber = new SelectList(db.SystemLicensedCompanies, "licensed_comp_licenseNumber", "licensed_comp_licenseNumber", company.licensed_comp_licenseNumber);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aspNetUsersId,comp_name,comp_special,comp_page_link,licensed_comp_licenseNumber,comp_image1,comp_image2")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.aspNetUsersId = User.Identity.GetUserId();

                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", company.aspNetUsersId);
            ViewBag.licensed_comp_licenseNumber = new SelectList(db.SystemLicensedCompanies, "licensed_comp_licenseNumber", "licensed_comp_licenseNumber", company.licensed_comp_licenseNumber);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
