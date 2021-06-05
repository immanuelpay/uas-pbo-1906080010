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
    public class BaseNilaiController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin, Mahasiswa")]
        // GET: AdminArea/Nilai
        public virtual ActionResult Index()
        {
            var nilai = db.Nilai.Include(n => n.MataKuliah).Include(n => n.Semester);
            return View(nilai.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Nilai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nilai nilai = db.Nilai.Find(id);
            if (nilai == null)
            {
                return HttpNotFound();
            }
            return View(nilai);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Nilai/Create
        public ActionResult Create()
        {
            ViewBag.KodeMK = new SelectList(db.MataKuliah, "KodeMK", "Nama");
            ViewBag.KodeSemester = new SelectList(db.Semester.Where(x => x.Active == true), "KodeSemester", "NamaSemester");
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Nilai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nim,KodeMK,KodeSemester,NilaiAngka,NilaiHuruf")] Nilai nilai)
        {
            if (ModelState.IsValid)
            {
                db.Nilai.Add(nilai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodeMK = new SelectList(db.MataKuliah, "KodeMK", "Nama", nilai.KodeMK);
            ViewBag.KodeSemester = new SelectList(db.Semester.Where(x => x.Active == true), "KodeSemester", "NamaSemester", nilai.KodeSemester);
            return View(nilai);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Nilai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nilai nilai = db.Nilai.Find(id);
            if (nilai == null || nilai.Semester.Active == false)
            {
                return HttpNotFound();
            }

            ViewBag.KodeMK = new SelectList(db.MataKuliah, "KodeMK", "Nama");
            ViewBag.KodeSemester = new SelectList(db.Semester.Where(x => x.Active == true), "KodeSemester", "NamaSemester");
            return View(nilai);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Nilai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nim,KodeMK,KodeSemester,NilaiAngka,NilaiHuruf")] Nilai nilai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nilai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodeMK = new SelectList(db.MataKuliah, "KodeMK", "Nama");
            ViewBag.KodeSemester = new SelectList(db.Semester.Where(x => x.Active == true), "KodeSemester", "NamaSemester");
            return View(nilai);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/Nilai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nilai nilai = db.Nilai.Find(id);
            if (nilai == null || nilai.Semester.Active == false)
            {
                return HttpNotFound();
            }
            return View(nilai);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/Nilai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nilai nilai = db.Nilai.Find(id);

            if (nilai == null || nilai.Semester.Active == false)
            {
                return HttpNotFound();
            }

            db.Nilai.Remove(nilai);
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
