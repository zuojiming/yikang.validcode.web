using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yikang.validcode.data.Model.co;

namespace yikang.validcode.data
{
    public class ValidCodeContext : DbContext,IDisposable
    {   
        public ValidCodeContext():base("validcode")
        {
                        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<PayMoney> PayMoney { get; set; }
        public DbSet<PayRecords> PayRecords { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
    }
}
