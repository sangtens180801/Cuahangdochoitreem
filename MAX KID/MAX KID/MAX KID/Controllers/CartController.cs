using MAX_KID.Models.Entities;
using MAX_KID.Models.Functions;
using MAX_KID.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAX_KID.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TotalItem = cart.TotalItem();
            }

            return View(list);
        }
        public ActionResult AddItem(int Id)
        {

            var product = new SANPHAMFunctions().FindEntity(Id); ;
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult AddToCart(int id)
        {
            var product = new SANPHAMFunctions().FindEntity(id); ;
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult RemoveOneItem(int Id)
        {

            var product = new SANPHAMFunctions().FindEntity(Id); ;
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.AddItem(product, -1);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult Clear()
        {
            var cart = (Cart)Session[CartSession];
            cart.Clear();
            Session[CartSession] = cart;
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult RemoveLine(int Id)
        {

            var product = new SANPHAMFunctions().FindEntity(Id); ;
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Payment(string name, string mobileadd, string diachiadd, string dateout)
        {
            // A
            var order = new DONHANG();
            order.ngaylap = DateTime.Now;
            order.hotenkhachhang = name;
            order.diachigiaohang = diachiadd;
            order.sodienthoai = mobileadd;
            DateTime? date = null;
            DateTime temp;

            if (DateTime.TryParse(dateout, out temp))
            {
                if (temp != null)
                    date = temp;
            }

            if (date != null)
                order.ngaynhanhang = date.Value;

            // B

            //nếu login
            if (SessionPersister.UserName != null)
            {
                order.ngaynhanhang = DateTime.Now;
                order.ID_TaiKhoan = SessionPersister.UserName.ID_TK;

                var account = new TAIKHOANFunctions().FindEntity(order.ID_TaiKhoan.Value);
                order.hotenkhachhang = account.HoVaTen;
                order.diachigiaohang = account.DiaChi;
                order.sodienthoai = account.DienThoaiLienHe;
            }
            try
            {
                var id = new DONHANGFunctions().Insert(order);

                var cart = (Cart)Session["CartSession"];
                var detailDao = new CTDONHANGFunctions();
                foreach (var item in cart.Lines)
                {
                    var orderDetail = new CTDONHANG();
                    orderDetail.ID_SanPham = item.Sanpham.ID_SanPham;
                    orderDetail.ID_DonHang = id;
                    orderDetail.soluong = item.Quantity;
                    orderDetail.dongia = (item.Sanpham.GiaSanPham * item.Quantity);
                    detailDao.Insert(orderDetail);
                }

                Session["CartSession"] = null;
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("Loi"); 
            }

            return RedirectToAction("MuaHangThanhCong", "Cart");
        }

        public ActionResult PaymentNotLogin()
        {
            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TotalItem = cart.TotalItem();
            }

            return View(list);
        }
        public ActionResult MuaHangThanhCong()
        {
            return View();
        }
        public PartialViewResult HienThiSession()
        {
            MyDB context = new MyDB();
            var user = (from a in context.TAIKHOANs
                        where (a.TenTaiKhoan == SessionPersister.UserName.UserName)
                        select a).FirstOrDefault();
            return PartialView("HienThiSession", user);
        }
        public ActionResult XacNhanDaDangNhap()
        {
            if (SessionPersister.UserName == null)
            {
                return RedirectToAction("Index", "LOGIN");
            }
            
            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TotalItem = cart.TotalItem();
            }
            return View(list);
        }
	}
}