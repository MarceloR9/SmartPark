using Microsoft.EntityFrameworkCore;
using SmartPark.Models;

namespace SmartPark.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Estacionamento> Estacionamentos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estacionamento>()
                .HasKey(e => new { e.Placa, e.HoraChegada });


        }
    }
}
