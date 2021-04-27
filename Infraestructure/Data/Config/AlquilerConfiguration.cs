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
    public class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
    {
        public void Configure(EntityTypeBuilder<Alquiler> builder)
        {
            builder.ToTable("Alquiler");

            builder.HasKey(ci => ci.Id);

              builder.Property(ci => ci.IdCliente)
             .IsRequired();

             builder.Property(ci => ci.IdAuto)
             
                .IsRequired();

          //  builder.HasOne(ci=> ci.Auto).WithOne()
           //     .HasForeignKey(ci=>ci.)

            builder.Property(ci => ci.FechaInicio)
                    .IsRequired();

            builder.Property(ci => ci.FechaFinal)
                    .IsRequired();

            builder.Property(ci => ci.PrecioAlquiler)
                    .IsRequired();

            builder.Property(ci => ci.CantidadTotal)
                    .IsRequired();

        }
    }
}
