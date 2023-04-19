using Microsoft.EntityFrameworkCore;
using MovieLibrary.Database.Entities;

namespace MovieLibrary.Database.Context
{
    public class MovieLibraryContext : DbContext
    {
        public MovieLibraryContext(DbContextOptions<MovieLibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
