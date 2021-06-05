using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PBO_UAS;
using PBO_UAS.Controllers.Base;
using PBO_UAS.Entities;

namespace PBO_UAS.Areas.MahasiswaArea.Controllers
{
    [Authorize(Roles = "Mahasiswa")]
    public class NilaiController : BaseNilaiController
    {
        public override ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var mahasiswa = db.Mahasiswa.SingleOrDefault(s => s.User.Id == userID);
            var nilai = db.Nilai.Where(n => n.Nim == mahasiswa.Nim);
            return View(nilai.ToList());
        }
    }
}
