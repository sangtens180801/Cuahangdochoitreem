using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAX_KID.Models.Entities;
using MAX_KID.Models.Functions;
using MAX_KID.Areas.ADMIN.SecurityAdmin;


namespace MAX_KID.Areas.ADMIN.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class LOAISPADMINController : Controller
    {
        //
        // GET: /ADMIN/LOAISPADMIN/
        public ActionResult Index()
        {
            var dm = new LOAISPFunctions().LOAISPs
                 .Where(p => p.TenLoaiSP != null);
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
        public ActionResult Create(LOAISP model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new LOAISPFunctions().Insert(model);
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
        public ActionResult Edit(int id, LOAISP model)
        {
            try
            {
                model.ID_LoaiSP = id;
                var result = new LOAISPFunctions().Update(model);
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
        public ActionResult Delete(int id, LOAISP model)
        {
            try
            {
                model.ID_LoaiSP = id;
                var result = new LOAISPFunctions().Delete(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}