using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yikang.validcode.webservice
{
    public class AccountBusinessHelper
    {
        private static AccountBusinessHelper sine_ { get; set; }
        public static AccountBusinessHelper Initialize()
        {
            if (sine_ == null) {
                sine_ = new AccountBusinessHelper();
            }
            return sine_;
        }
        private AccountBusinessHelper()
        {

        }
    }
}
