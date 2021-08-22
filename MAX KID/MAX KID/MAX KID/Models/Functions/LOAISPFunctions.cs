using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class LOAISPFunctions
    {
        private MyDB context;
        public LOAISPFunctions()
        {
            context = new MyDB();
        }
        public IQueryable<LOAISP> LOAISPs
        {
            get { return context.LOAISPs; }
        }
        public LOAISP FindEntity(int ID_LoaiSP)
        {
            LOAISP dbEntry = context.LOAISPs.Find(ID_LoaiSP);
            return dbEntry;
        }

        //them sua xoa

        public int Insert(LOAISP model)
        {
            LOAISP dbEntry = context.LOAISPs.Find(model.ID_LoaiSP);
            if (dbEntry != null)
            {
                return 0;

            }
            context.LOAISPs.Add(model);
            context.SaveChanges();
            return 1;
        }
        public int Update(LOAISP model)
        {
            LOAISP dbEntry = context.LOAISPs.Find(model.ID_LoaiSP);
            if (dbEntry == null)
            {
                return 0;
            }
            dbEntry.ID_LoaiSP = model.ID_LoaiSP;
            dbEntry.TenLoaiSP = model.TenLoaiSP;

            context.SaveChanges();
            return 1;
        }
        public int Delete(LOAISP model)
        {
            LOAISP dbEntry = context.LOAISPs.Find(model.ID_LoaiSP);
            if (dbEntry == null)
            {
                return 0;
            }
            context.LOAISPs.Remove(dbEntry);
            context.SaveChanges();
            return 1;
        }
    }
}