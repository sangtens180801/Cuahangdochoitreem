using MAX_KID.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Security
{
    public static class SessionPersister
    {
        static string usernameSessionvar = "username";
        public static Account UserName
        {
            get{
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as Account;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }
    }
}