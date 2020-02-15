using Microsoft.EntityFrameworkCore;

namespace lab1a.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (
            DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<lab1a.Models.Movie> Movie { get; set; }
    }
}