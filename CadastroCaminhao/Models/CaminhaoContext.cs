using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CadastroCaminhao.Models
{
    public class CaminhaoContext : DbContext
    {
        public CaminhaoContext(DbContextOptions<CaminhaoContext> options)
            : base(options)
        {
        }

        public DbSet<Caminhao> Caminhoes { get; set; } = null!;
        public DbSet<ModeloCaminhao> ModelosCaminhao { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caminhao>().ToTable("Caminhao");
            modelBuilder.Entity<ModeloCaminhao>().ToTable("ModeloCaminhao");
        }

    }
}
