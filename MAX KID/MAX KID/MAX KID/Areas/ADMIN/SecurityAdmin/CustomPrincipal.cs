﻿using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MAX_KID.Areas.ADMIN.SecurityAdmin
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.UserName);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.Account.Quyen.Contains(r));
            return kq;
        }
    }
}