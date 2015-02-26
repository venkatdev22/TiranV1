using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiranV1.Models;

namespace TiranV1.Controllers
{
    public class ProfileController : Controller
    {
        private TiranV1DBEntities db = new TiranV1DBEntities();

        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View(db.Candidate_Tbl.ToList());
        }

        //
        // GET: /Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            if (candidate_tbl == null)
            {
                return HttpNotFound();
            }
            return View(candidate_tbl);
        }

        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidate_Tbl candidate_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Candidate_Tbl.Add(candidate_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate_tbl);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            if (candidate_tbl == null)
            {
                return HttpNotFound();
            }
            return View(candidate_tbl);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate_Tbl candidate_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate_tbl);
        }

        //
        // GET: /Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            if (candidate_tbl == null)
            {
                return HttpNotFound();
            }
            return View(candidate_tbl);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            db.Candidate_Tbl.Remove(candidate_tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}