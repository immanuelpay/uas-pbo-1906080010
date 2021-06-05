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
    public class BaseMataKuliahController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin, Mahasiswa")]
        // GET: AdminArea/MataKuliah
        public ActionResult Index()
        {
            return View(db.MataKuliah.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/MataKuliah/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = db.MataKuliah.Find(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/MataKuliah/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/MataKuliah/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodeMK,Nama,JumlahSKS")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                db.MataKuliah.Add(mataKuliah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mataKuliah);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/MataKuliah/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = db.MataKuliah.Find(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/MataKuliah/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodeMK,Nama,JumlahSKS")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mataKuliah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mataKuliah);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminArea/MataKuliah/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = db.MataKuliah.Find(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminArea/MataKuliah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MataKuliah mataKuliah = db.MataKuliah.Find(id);
            db.MataKuliah.Remove(mataKuliah);
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
