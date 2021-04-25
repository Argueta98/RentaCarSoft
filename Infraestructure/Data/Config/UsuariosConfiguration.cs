using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Config
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.DUI)
                   .HasMaxLength(12)
                   .IsRequired();

            builder.Property(ci => ci.Nombres)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Apellidos)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Genero)
                    .IsRequired();

            builder.Property(ci => ci.Direccion)
                    .IsRequired();
        }
    }
}
