using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Models
{
    public class BigViewModel
    {
        public Account account { get; set; }
        public AccountDetail accountDetail { get; set; }
        public Achievement achievement{ get; set; }
        public Experience experience{ get; set; }
        public Professional professional{ get; set; }
        public Qualification qualification{ get; set; }
    }
}