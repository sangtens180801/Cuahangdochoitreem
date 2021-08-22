using MAX_KID.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Web;
using System.Web.Mvc;
using MAX_KID.Models.Entities;

namespace MAX_KID.Controllers
{
    public class SANPHAMController : Controller
    {
        // GET: SANPHAM
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All(int? page)
        {

            int pageNumber = (page ?? 1);
            int pageSize = 8;
            var sp = new SANPHAMFunctions().SANPHAMs
             .Where(p => p.ID_SanPham != null);
            return View(sp.ToList().OrderBy(n => n.ID_SanPham).ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult TimKiem(string txttimkiem, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            var sp = new SANPHAMFunctions().SANPHAMs
             .Where(p => p.TenSanPham.Contains(txttimkiem));
            return View(sp.ToList().OrderBy(n => n.ID_SanPham).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            var model = new SANPHAMFunctions().FindEntity(id);
            return View(model);
        }

        public ActionResult LocTheoLoaiSP(int? id)
        {
            var db = new SANPHAMFunctions();
            MyDB context = new MyDB();
            LOAISP LSP = context.LOAISPs.Find(id);
            if (LSP != null)
            {
                ViewBag.TenLoaiSP = LSP.TenLoaiSP;
            }
            var sp = db.SANPHAMs.Where(p => p.ID_LoaiSP == id);
            return View(sp);
        }

        public ActionResult LocTheoHANGSX(int? id)
        {
            var db = new SANPHAMFunctions();
            MyDB context = new MyDB();
            HANGSX hsx = context.HANGSXes.Find(id);
            if (hsx != null)
            {
                ViewBag.TenHSX = hsx.TenHangSX;
            }
            var sp = db.SANPHAMs.Where(p => p.ID_LoaiSP == id);
            return View(sp);
        }
    }
}