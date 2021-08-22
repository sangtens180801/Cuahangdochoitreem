using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class TAIKHOANFunctions
    {
        private MyDB context;
            public TAIKHOANFunctions()
            {
                context = new MyDB();
            }
            public IQueryable<TAIKHOAN> TAIKHOANs
            {
                get { return context.TAIKHOANs; }
            }
            public int Insert(TAIKHOAN model)
            {
                TAIKHOAN dbEntry = context.TAIKHOANs.Find(model.ID_TaiKhoan);
                if (dbEntry != null)
                {
                    return 0;

                }
                context.TAIKHOANs.Add(model);
                context.SaveChanges();
                return 1;
            }
            public int Update(TAIKHOAN model)
            {
                TAIKHOAN dbEntry = context.TAIKHOANs.Find(model.ID_TaiKhoan);
                if (dbEntry == null)
                {
                    return 0;
                }
                dbEntry.TenTaiKhoan = model.TenTaiKhoan;
                dbEntry.MatKhau = model.MatKhau;;
                context.SaveChanges();
                return 1;
            }
            public int Delete(TAIKHOAN model)
            {
                TAIKHOAN dbEntry = context.TAIKHOANs.Find(model.ID_TaiKhoan);
                if (dbEntry == null)
                {
                    return 0;
                }
                context.TAIKHOANs.Remove(dbEntry);
                context.SaveChanges();
                return 1;
            }
            public TAIKHOAN FindEntity(int ID_TaiKhoan)
            {
                TAIKHOAN dbEntry = context.TAIKHOANs.Find(ID_TaiKhoan);
                return dbEntry;
            }
    }
}