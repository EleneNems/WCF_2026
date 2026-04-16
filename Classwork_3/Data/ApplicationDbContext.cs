using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Classwork_3.Models;

namespace Classwork_3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}