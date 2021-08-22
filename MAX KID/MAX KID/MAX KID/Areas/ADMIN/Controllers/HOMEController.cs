using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAX_KID.Models.Functions;
using MAX_KID.Models.Entities;
using MAX_KID.Areas.ADMIN.SecurityAdmin;

namespace MAX_KID.Areas.ADMIN.Controllers
{
    public class HOMEController : Controller
    {
        //
        // GET: /ADMIN/HOME/
        public ActionResult HOME()
        {
            return View();
        }
	}
}