using MAX_KID.Models.Entities;
using MAX_KID.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAX_KID.Controllers
{
    public class LOAISPController : Controller
    {
        //
        // GET: /LOAISP/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DM_LOAISP()
        {
            var dm = new LOAISPFunctions().LOAISPs
              .Where(p => p.TenLoaiSP != null);
            return PartialView(dm);
        }

        
	}
}