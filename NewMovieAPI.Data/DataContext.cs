using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewMovieAPI.Entities;

namespace NewMovieAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }

        public IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
