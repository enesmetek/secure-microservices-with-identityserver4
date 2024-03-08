using Microsoft.EntityFrameworkCore;

namespace Movies.API.Persistance.Context
{
    public class MoviesAPIContext : DbContext
    {
        public MoviesAPIContext(DbContextOptions<MoviesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Domain.Concrete.Movie> Movie { get; set; } = default!;
    }
}
