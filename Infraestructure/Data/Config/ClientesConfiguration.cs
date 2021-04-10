using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");

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
