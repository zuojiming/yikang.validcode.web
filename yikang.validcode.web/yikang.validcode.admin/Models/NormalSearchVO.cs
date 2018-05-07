using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yikang.validcode.admin.Models
{
    public class NormalSearchVO
    {
        public int pageidx { get; set; }
        public int pagesize { get; set; }
        public string searchkey { get; set; }
        public string searchval { get; set; }
    }
}