using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBO_UAS;
using PBO_UAS.Controllers.Base;
using PBO_UAS.Entities;

namespace PBO_UAS.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SemesterController : BaseSemesterController
    {

    }
}
