using FilmeCerto.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmeCerto.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<FilmeGenero> FilmeGeneros { get; set; }
        public DbSet<TipoFilme> TipoFilmes { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<FilmeGenero>()
                .HasKey(fg => new { fg.FilmeId, fg.GeneroId });

            modelBuilder.Entity<FilmeGenero>()
                .HasOne(fg => fg.Filme)
                .WithMany(f => f.Generos)
                .HasForeignKey(fg => fg.FilmeId);

            modelBuilder.Entity<FilmeGenero>()
                .HasOne(fg => fg.Genero)
                .WithMany(g => g.Filmes)
                .HasForeignKey(fg => fg.GeneroId);
        }
    }
}