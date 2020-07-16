using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Mapping
{
    class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Autor)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Capa)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(c => c.Genero)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Sinopse)
                .HasMaxLength(200);

            builder.Property(c => c.Titulo)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
