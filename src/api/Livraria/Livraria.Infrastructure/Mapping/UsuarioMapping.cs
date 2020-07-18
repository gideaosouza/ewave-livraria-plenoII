using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Mapping
{
    class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasMaxLength(11);

            builder.Property(c => c.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(200);

            builder.Property(c => c.Endereco)
                .HasMaxLength(500);

            builder.Property(b => b.DataCadastramento)
                .HasDefaultValueSql("getdate()");
        }
    }
}