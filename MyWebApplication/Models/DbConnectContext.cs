using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class DbConnectContext : DbContext
    {
        public DbConnectContext(): base("name=DbConnectContext") {}
        public virtual DbSet<Question> Question { get; set; }
    }
}