using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBO_UAS.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        public virtual ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Mahasiswa"))
            {
                return RedirectToAction("Index", "Home", new { Area = "MahasiswaArea" });
            }

            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { Area = "AdminArea" });
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { Area = "" });
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}