using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infrastructure.Mapping
{
    class InstituicaoEnsinoMapping : IEntityTypeConfiguration<InstituicaoEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoEnsino> builder)
        {
            builder.ToTable("IntituicoesEnsino");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPNJ)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(b => b.DataCadastramento)
                .HasDefaultValueSql("getdate()");
        }
    }
}