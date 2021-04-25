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
    public class PrecioAlquilerConfiguration : IEntityTypeConfiguration<PrecioAlquiler>
    {
        public void Configure(EntityTypeBuilder<PrecioAlquiler> builder)
        {

            builder.ToTable("PrecioAlquiler");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Precio)
                .HasColumnType("decimal(18,4)")
                   .IsRequired();

            builder.Property(ci => ci.AutoId);
        }
    }
}
