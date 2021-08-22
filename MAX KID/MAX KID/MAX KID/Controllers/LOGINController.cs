using MAX_KID.Security;
using MAX_KID.Models.Entities;
using MAX_KID.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAX_KID.Controllers
{
    public class LOGINController : Controller
    {
        //
        // GET: /LOGIN/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Account model, string returnUrl)
        {
            AccountModel am = new AccountModel();
            Account acc = am.Login(model.UserName, model.Password);
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password)
                || acc == null)
            {
                return View("Index");
            }
            else
            {
                SessionPersister.UserName = acc;
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("All", "SANPHAM");
            }
        }

        public ActionResult LogOut()
        {
            SessionPersister.UserName = null;
            return RedirectToAction("All", "SANPHAM");
        }

	}
}