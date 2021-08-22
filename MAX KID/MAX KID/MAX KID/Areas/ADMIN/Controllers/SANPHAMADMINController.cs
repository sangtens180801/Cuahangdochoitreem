using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MAX_KID.Models.Functions;
using MAX_KID.Models.Entities;
using System.IO;
using MAX_KID.Areas.ADMIN.SecurityAdmin;
namespace MAX_KID.Areas.ADMIN.Controllers
{
    //[CustomAuthorize(Roles = "Admin")]
    public class SANPHAMADMINController : Controller
    {
        //
        // GET: /ADMIN/SANPHAMADMIN/
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            var sp = new SANPHAMFunctions().SANPHAMs
             .Where(p => p.ID_SanPham!= null);
            return View(sp.ToList().OrderBy(n => n.ID_SanPham).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult TimKiemSanPhamAdmin(string txttimkiem, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            var sp = new SANPHAMFunctions().SANPHAMs.Where(p => p.TenSanPham.Contains(txttimkiem));
            return View(sp.ToList().OrderBy(n => n.ID_SanPham).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            var dao = new HANGSXFunctions().HANGSXs.Where(p => p.TenHangSX != null);
            ViewBag.ID_HangSX = new SelectList(dao, "ID_HangSX", "TenHangSX", null);
            var dao2 = new LOAISPFunctions().LOAISPs.Where(p => p.TenLoaiSP != null);
            ViewBag.ID_LoaiSP = new SelectList(dao2, "ID_LoaiSP", "TenLoaiSP", null);
            return View();
        }

        //
        // POST: /Admin/SANPHAMADMIN/Create
        [HttpPost]
        public ActionResult Create(SANPHAM model, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                //
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Theme/images"), fileName);
                    file.SaveAs(path);
                    //     ModelState.Clear();
                    // TODO: Add insert logic here
                    model.ImgLink = fileName;
                    SANPHAMFunctions _sanphamF = new SANPHAMFunctions();
                    _sanphamF.Insert(model);
                    // Upload File đẩy về Server


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
            var model = new SANPHAMFunctions().FindEntity(id);
            var dao = new HANGSXFunctions().HANGSXs;
            ViewBag.ID_HangSX = new SelectList(dao, "ID_HangSX", "TenHangSX", model.ID_HangSX);
            var dao2 = new LOAISPFunctions().LOAISPs;
            ViewBag.ID_LoaiSP = new SelectList(dao2, "ID_LoaiSP", "TenLoaiSP", model.ID_LoaiSP);
            return View(model);
        }

        //
        // POST: /Admin/SANPHAMADMIN/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,SANPHAM model, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                //
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Theme/images"), fileName);
                    file.SaveAs(path);
                    //     ModelState.Clear();
                    // TODO: Add insert logic here
                    model.ImgLink = fileName;
                    SANPHAMFunctions _sanphamF = new SANPHAMFunctions();
                    _sanphamF.Update(model);
                    // Upload File đẩy về Server


                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/SANPHAMADMIN/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SANPHAM model)
        {
            try
            {
                model.ID_SanPham = id;
                var result = new SANPHAMFunctions().Delete(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }

}