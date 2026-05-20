using Microsoft.EntityFrameworkCore;
using MovieApiComparison.Models;

namespace MovieApiComparison.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}