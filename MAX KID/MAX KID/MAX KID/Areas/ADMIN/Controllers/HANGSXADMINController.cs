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
    //[CustomAuthorize(Roles = "Admin")]
    public class HANGSXADMINController : Controller
    {
        //
        // GET: /ADMIN/HANGSXADMIN/
        public ActionResult Index()
        {
            var dm = new HANGSXFunctions().HANGSXs
                 .Where(p => p.TenHangSX != null);
            return View(dm);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HANGSX model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new HANGSXFunctions().Insert(model);
                if (result == 0)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/DANHMUCADMIN/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HANGSX model)
        {
            try
            {
                model.ID_HangSX = id;
                var result = new HANGSXFunctions().Update(model);
                //if (result == null)
                //{
                //    return View();
                //}
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/DANHMUCADMIN/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/DANHMUCADMIN/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HANGSX model)
        {
            try
            {
                model.ID_HangSX = id;
                var result = new HANGSXFunctions().Delete(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

	}
}