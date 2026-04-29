using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture_7Domain.Entity;

namespace Lecture_7Infrastructure
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options){}
        public DbSet<Student> Students => Set<Student>();
    }
}
