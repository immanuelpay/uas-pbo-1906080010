using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBO_UAS;
using PBO_UAS.Entities;

namespace PBO_UAS.Controllers.Base
{
    public class BaseSemesterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin, Mahasiswa")]
        // GET: AdminArea/Semester
        public ActionResult Index()
        {
            return View(db.Semester.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Semester/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semester.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Semester/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Semester/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeSemester,NamaSemester,TahunAjaran,Active")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Semester.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semester);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Semester/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semester.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Semester/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeSemester,NamaSemester,TahunAjaran,Active")] Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Semester/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semester semester = db.Semester.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Semester/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Semester semester = db.Semester.Find(id);
            db.Semester.Remove(semester);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
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
