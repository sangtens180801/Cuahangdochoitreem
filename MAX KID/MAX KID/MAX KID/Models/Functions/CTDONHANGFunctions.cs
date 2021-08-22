using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class CTDONHANGFunctions
    {
        private MyDB context;
            public CTDONHANGFunctions()
            {
                context = new MyDB();
            }
            public IQueryable<CTDONHANG> CTDONHANGs
            {
                get { return context.CTDONHANGs; }
            }
            public int Insert(CTDONHANG model)
            {
                CTDONHANG dbEntry = context.CTDONHANGs.Find(model.ID_ChiTietDonHang);
                if (dbEntry != null)
                {
                    return 0;

                }
                context.CTDONHANGs.Add(model);
                context.SaveChanges();
                return 1;
            }
            public int Update(CTDONHANG model)
            {
                CTDONHANG dbEntry = context.CTDONHANGs.Find(model.ID_ChiTietDonHang);
                if (dbEntry == null)
                {
                    return 0;
                }
                dbEntry.ID_DonHang = model.ID_DonHang;
                dbEntry.ID_SanPham = model.ID_SanPham;
                dbEntry.soluong = model.soluong;
                dbEntry.dongia = model.dongia;
                context.SaveChanges();
                return 1;
            }
            public int Delete(CTDONHANG model)
            {
                CTDONHANG dbEntry = context.CTDONHANGs.Find(model.ID_ChiTietDonHang);
                if (dbEntry == null)
                {
                    return 0;
                }
                context.CTDONHANGs.Remove(dbEntry);
                context.SaveChanges();
                return 1;
            }
            public CTDONHANG FindEntity(int ID_ChiTietDonHang)
            {
                CTDONHANG dbEntry = context.CTDONHANGs.Find(ID_ChiTietDonHang);
                return dbEntry;
            }
    }
}