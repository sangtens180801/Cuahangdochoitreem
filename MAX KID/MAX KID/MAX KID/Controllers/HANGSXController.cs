using MAX_KID.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAX_KID.Controllers
{
    public class HANGSXController : Controller
    {
        //
        // GET: /HANGSX/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HANGSX()
        {
            var dm = new HANGSXFunctions().HANGSXs
              .Where(p => p.TenHangSX != null);
            return PartialView(dm);
        }
	}
}