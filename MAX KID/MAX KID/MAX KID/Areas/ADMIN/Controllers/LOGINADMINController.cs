using MAX_KID.Areas.ADMIN.SecurityAdmin;
using MAX_KID.Models.Entities;
using MAX_KID.Models.Functions;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Areas.ADMIN.Controllers
{
    public class LOGINADMINController : Controller
    {
        //
        // GET: /ADMIN/LOGINADMIN/
        public ActionResult Index(Account model)
        {
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password)
                || am.Login(model.UserName, model.Password) == null)
            {
                return View("Index");
            }
            SessionPersister.UserName = model.UserName;
            return RedirectToAction("HOME", "HOME");
        }

        public ActionResult LogOut()
        {
            SessionPersister.UserName = null;
            return RedirectToAction("Index", "LOGINADMIN");
        }
	}
}