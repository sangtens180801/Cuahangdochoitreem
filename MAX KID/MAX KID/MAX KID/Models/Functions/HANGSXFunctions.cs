using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAX_KID.Models.Functions
{
    public class HANGSXFunctions
    {
        private MyDB context;
        public HANGSXFunctions()
        {
            context = new MyDB();
        }
        public IQueryable<HANGSX> HANGSXs
        {
            get { return context.HANGSXes; }
        }
        public HANGSX FindEntity(int ID_HangSanXuat)
        {
            HANGSX dbEntry = context.HANGSXes.Find(ID_HangSanXuat);
            return dbEntry;
        }

        //them sua xoa

        public int Insert(HANGSX model)
        {
            HANGSX dbEntry = context.HANGSXes.Find(model.ID_HangSX);
            if (dbEntry != null)
            {
                return 0;

            }
            context.HANGSXes.Add(model);
            context.SaveChanges();
            return 1;
        }
        public int Update(HANGSX model)
        {
            HANGSX dbEntry = context.HANGSXes.Find(model.ID_HangSX);
            if (dbEntry == null)
            {
                return 0;
            }
            dbEntry.ID_HangSX = model.ID_HangSX;
            dbEntry.TenHangSX = model.TenHangSX;

            context.SaveChanges();
            return 1;
        }
        public int Delete(HANGSX model)
        {
            HANGSX dbEntry = context.HANGSXes.Find(model.ID_HangSX);
            if (dbEntry == null)
            {
                return 0;
            }
            context.HANGSXes.Remove(dbEntry);
            context.SaveChanges();
            return 1;
        }

    }
}