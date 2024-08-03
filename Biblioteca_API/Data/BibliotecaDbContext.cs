using Biblioteca_Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext>options) : base(options)
        {
            
        }
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Editoras> Editoras { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<CategoriasLiterarias> CategoriasLiterarias { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Livros>().HasKey(x => new { x.IdEditoras, x.IdAutores });
        //}
    }
}
