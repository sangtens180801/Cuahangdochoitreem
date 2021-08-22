using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Functions
{
    public class AccountModel
    {
        private MyDB context;
        public AccountModel()
        {
            context = new MyDB();
        }

        public Account Login(string username, string pass)
        {
            var model = (from a in context.QUYENs
                         join b in context.PHANQUYENs
                         on a.TenQuyen equals b.TenQuyen
                         where (a.TenQuyen != null && b.TenQuyen.Equals(username))
                         select a.TenQuyen);
            var result = (from a in context.TAIKHOANs
                          where (a.TenTaiKhoan.Equals(username) && a.MatKhau.Equals(pass))
                          select new Account
                          {
                              ID_TK = a.ID_TaiKhoan,
                              UserName = a.TenTaiKhoan,
                              Password = a.MatKhau,
                              Quyen = model.ToList()
                          }).FirstOrDefault();
            Account t = result;
            return result;
        }


        public Account Find(string username)
        {
            var model = (from a in context.QUYENs
                         join b in context.PHANQUYENs
                         on a.TenQuyen equals b.TenQuyen
                         where (a.TenQuyen != null && b.TenQuyen.Equals(username))
                         select a.TenQuyen);
            var result = (from a in context.TAIKHOANs
                          where (a.TenTaiKhoan.Equals(username))
                          select new Account
                          {
                              ID_TK = a.ID_TaiKhoan,
                              UserName = a.TenTaiKhoan,
                              Password = a.MatKhau,
                              Quyen = model.ToList()
                          }).FirstOrDefault();
            return result;
        }
    }
}