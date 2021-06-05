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
using PBO_UAS.Controllers.Base;
using PBO_UAS.Entities;
using PBO_UAS.Models;

namespace PBO_UAS.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MahasiswaController : BaseMahasiswaController
    {

    }
}
