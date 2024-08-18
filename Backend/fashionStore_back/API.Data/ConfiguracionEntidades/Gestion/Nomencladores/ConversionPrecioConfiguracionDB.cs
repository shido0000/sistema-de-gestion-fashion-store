using API.Data.Entidades.Gestion.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ConversionPrecioConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversionPrecio>().ToTable("ConversionesPrecios");
        EntidadBaseConfiguracionBD<ConversionPrecio>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<ConversionPrecio>().Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<ConversionPrecio>().Property(e => e.valorCambio);

        modelBuilder.Entity<ConversionPrecio>().HasIndex(e => new { e.Descripcion }).IsUnique();
    }
}
