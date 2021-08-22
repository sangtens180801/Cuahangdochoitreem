using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class SANPHAMFunctions
    {
        private MyDB context;
        public SANPHAMFunctions()
        {
            context = new MyDB();
        }

        public IQueryable<SANPHAM> SANPHAMs
        {
            get { return context.SANPHAMs; }
        }
        public SANPHAM FindEntity(int ID_SanPham)
        {
            SANPHAM dbEntry = context.SANPHAMs.Find(ID_SanPham);
            return dbEntry;
        }

        public int Insert(SANPHAM model)
        {
            SANPHAM dbEntry = context.SANPHAMs.Find(model.ID_SanPham);
            if (dbEntry != null)
            {
                return -1;

            }
            context.SANPHAMs.Add(model);
            context.SaveChanges();
            return model.ID_SanPham;
        }
        public int Update(SANPHAM model)
        {
            SANPHAM dbEntry = context.SANPHAMs.Find(model.ID_SanPham);
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.ID_SanPham = model.ID_SanPham;
            dbEntry.ID_LoaiSP = model.ID_LoaiSP;
            dbEntry.ID_HangSX = model.ID_HangSX;
            dbEntry.ImgLink= model.ImgLink;
            dbEntry.TenSanPham = model.TenSanPham;
            dbEntry.ThongSoKiThuat = model.ThongSoKiThuat;
            dbEntry.DoTuoiSuDung = model.DoTuoiSuDung;
            dbEntry.GiaSanPham = model.GiaSanPham;
            

            context.SaveChanges();
            return model.ID_SanPham;
        }
        public int Delete(SANPHAM model)
        {
            SANPHAM dbEntry = context.SANPHAMs.Find(model.ID_SanPham);
            if (dbEntry != null)
            {
                context.SANPHAMs.Remove(dbEntry);
                context.SaveChanges();
            }
            return model.ID_SanPham;
        }
    }
}