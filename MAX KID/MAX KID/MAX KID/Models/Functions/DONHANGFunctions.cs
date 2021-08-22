using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class DONHANGFunctions
    {
        private MyDB context;
            public DONHANGFunctions()
            {
                context = new MyDB();
            }
            public IQueryable<DONHANG> DONHANGs
            {
                get { return context.DONHANGs; }
            }
            public int Insert(DONHANG order)
            {
                context.DONHANGs.Add(order);
                context.SaveChanges();
                return order.ID_DonHang;
            }
            public int Update(DONHANG model)
            {
                DONHANG dbEntry = context.DONHANGs.Find(model.ID_DonHang);
                if (dbEntry == null)
                {
                    return 0;
                }
                dbEntry.ID_TaiKhoan = model.ID_TaiKhoan;
                dbEntry.ngaylap = model.ngaylap;
                dbEntry.ngaynhanhang = model.ngaynhanhang;
                dbEntry.diachigiaohang = model.diachigiaohang;
                dbEntry.sodienthoai = model.sodienthoai;
                dbEntry.hotenkhachhang = model.hotenkhachhang;
                context.SaveChanges();
                return 1;
            }
            public int Delete(DONHANG model)
            {
                DONHANG dbEntry = context.DONHANGs.Find(model.ID_DonHang);
                if (dbEntry == null)
                {
                    return 0;
                }
                context.DONHANGs.Remove(dbEntry);
                context.SaveChanges();
                return 1;
            }
            
            public DONHANG FindEntity(int ID_DH)
            {
                DONHANG dbEntry = context.DONHANGs.Find(ID_DH);
                return dbEntry;
            }

            //public tblCTDonHangViewModel tblCTDonHang(int id)
            //{
            //    var entry = (from a in context.DONHANGs
            //                 join b in context.CTDONHANGs on a.ID_DH equals b.ID_DH
            //                 join c in context.SANPHAMs on b.ID_SP equals c.ID_SP
            //                 where (a.ID_DH != null)
            //                 select new tblCTDonHangViewModel
            //                 {
            //                     ID_DH = a.ID_DH,
            //                     ID_TIN = a.ID_TIN,
            //                     ngaylap = a.ngaylap,
            //                     ngaynhanhang = a.ngaynhanhang,
            //                     diachigiaohang = a.diachigiaohang,
            //                     trangthai = a.trangthai,
            //                     hotenkh = a.hotenkh,
            //                     ID_CTDH = b.ID_CTDH,
            //                     ID_SP = b.ID_SP,
            //                     soluong = b.soluong,
            //                     dongia = b.dongia,
            //                     ID_DM = c.ID_DM,
            //                     tensanpham = c.tensanpham,
            //                     giabd = c.giabd,
            //                     trongluong = c.trongluong,
            //                     mausac = c.mausac,
            //                     ImgLink = c.ImgLink,
            //                     memory = c.memory,
            //                     hedieuhanh = c.hedieuhanh,
            //                     vga = c.vga,
            //                     cpuz = c.cpuz,
            //                     battery = c.cpuz,
            //                     phukiendikem = c.phukiendikem,
            //                     chedobaohanh = c.chedobaohanh
            //                 }).FirstOrDefault();
            //                 return entry;
            //}
    }
}