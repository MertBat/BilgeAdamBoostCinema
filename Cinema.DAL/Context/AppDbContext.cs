using Cinema.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorFilm> ActorFilms { get; set; }
        public DbSet<CategoryFilm> CategoryFilms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AUVUDLH; Database=ONL5CinemaDB; Uid=sa; Pwd=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorFilm>().HasKey(x => new
            {
                x.ActorId,
                x.FilmId
            });

            modelBuilder.Entity<CategoryFilm>().HasKey(x=> new
            {
                x.CategoryId, 
                x.FilmId
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

