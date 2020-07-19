using Livraria.Domain.Entities;
using Livraria.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Context
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=livraria.db;Trusted_Connection=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public DbSet<EmprestimoLivro> EmprestimosLivros { get; set; }
        public DbSet<LivroReserva> ReservasLivros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
            modelBuilder.Entity<Livro>(new LivroMapping().Configure);
            modelBuilder.Entity<InstituicaoEnsino>(new InstituicaoEnsinoMapping().Configure);
            
        }
    }
}
