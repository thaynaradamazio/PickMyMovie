using Microsoft.EntityFrameworkCore;
using PickMyMovie.Domain.Entities;
using System.Collections.Generic;

namespace PickMyMovie.Infrastructure.DataAccess
{
    public class PickMyMovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Rule> Rules { get; set; }

        public PickMyMovieDbContext(DbContextOptions<PickMyMovieDbContext> options) : base(options) { }
    }
}
