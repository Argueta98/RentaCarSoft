using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class AutoConfiguration : IEntityTypeConfiguration<Auto>
    {
        public void Configure(EntityTypeBuilder<Auto> builder)
        {
            builder.ToTable("Auto");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Placa)
                   .HasMaxLength(12)
                   .IsRequired();

            builder.Property(ci => ci.Marca)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Modelo)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.TipoAuto)
                .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Color)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Combustible)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Estado);

            builder.Property(ci => ci.Fotografia);


        }
    }
}
