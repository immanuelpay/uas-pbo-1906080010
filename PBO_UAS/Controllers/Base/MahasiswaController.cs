using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PBO_UAS;
using PBO_UAS.Entities;
using PBO_UAS.Models;

namespace PBO_UAS.Controllers.Base
{
    [Authorize(Roles = "Admin")]
    public class BaseMahasiswaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminArea/Mahasiswa
        public ActionResult Index()
        {
            return View(db.Mahasiswa.ToList());
        }

        // GET: AdminArea/Mahasiswa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswa.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: AdminArea/Mahasiswa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/Mahasiswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nim,Nama,Jk,Angkatan,NoHp,Alamat")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                var email = $"{mahasiswa.Nim}@undana.ac.id";
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = email, Email = email };
                userManager.Create(user, mahasiswa.Nim);
                userManager.AddToRole(user.Id, "Mahasiswa");

                mahasiswa.User = user;
                db.Mahasiswa.Add(mahasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mahasiswa);
        }

        // GET: AdminArea/Mahasiswa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswa.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: AdminArea/Mahasiswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nim,Nama,Jk,Angkatan,NoHp,Alamat")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                //var email = $"{mahasiswa.Nim}@undana.ac.id";
                //var mhs = db.Mahasiswa.SingleOrDefault(s => s.Id == mahasiswa.Id);
                //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                //ApplicationUser user = userManager.FindById(mhs.User.Id);

                db.Entry(mahasiswa).State = EntityState.Modified;
                db.SaveChanges();

                //if (user != null)
                //{
                //    user.Email = email;
                //    user.UserName = email;
                //    user.PasswordHash = userManager.PasswordHasher.HashPassword(mahasiswa.Nim);
                //    userManager.Update(user);
                //}

                return RedirectToAction("Index");
            }
            return View(mahasiswa);
        }

        // GET: AdminArea/Mahasiswa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswa.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: AdminArea/Mahasiswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mahasiswa mahasiswa = db.Mahasiswa.Find(id);
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser user = userManager.FindById(mahasiswa.User.Id);
            var logins = user.Logins;
            var rolesForUser = userManager.GetRoles(mahasiswa.User.Id);

            foreach (var login in logins.ToList())
            {
                userManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    userManager.RemoveFromRole(user.Id, item);
                }
            }

            db.Mahasiswa.Remove(mahasiswa);
            userManager.Delete(user);
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
