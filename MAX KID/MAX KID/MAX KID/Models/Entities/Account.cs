using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Entities
{
    public class Account
    {
        public int ID_TK { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Quyen { get; set; }
    }
}