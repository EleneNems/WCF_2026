using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Classwork_1.Data
{
    public class AppDBContent:DbContext
    {
        public AppDBContent():base("name=AppDBContent") { 

        }

        public DbSet <Student> Students { get; set; }
    }
}