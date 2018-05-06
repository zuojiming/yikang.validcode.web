using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yikang.validcode.data.co;
using yikang.validcode.data.Model.co;

namespace yikang.validcode.data
{
    public class ValidCodeContext : DbContext
    {   
        public ValidCodeContext():base("validcode")
        {
                        
        }
        public DbSet<User> Users { get; set; }          
    }
}
