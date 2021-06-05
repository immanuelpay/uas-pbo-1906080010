using System.Web.Mvc;

namespace PBO_UAS.Areas.MahasiswaArea
{
    public class MahasiswaAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MahasiswaArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MahasiswaArea_default",
                "MahasiswaArea/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PBO_UAS.Areas.MahasiswaArea.Controllers" }
            );
        }
    }
}