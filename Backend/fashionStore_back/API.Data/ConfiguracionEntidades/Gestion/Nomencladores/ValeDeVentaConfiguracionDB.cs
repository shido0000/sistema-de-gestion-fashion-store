using API.Data.Entidades.Gestion.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ValeDeVentaConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ValeDeVenta>().ToTable("ValesDeVentas");
        EntidadBaseConfiguracionBD<ValeDeVenta>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<ValeDeVenta>().Property(e => e.Domicilio).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<ValeDeVenta>().Property(e => e.VentaId).IsRequired();
        modelBuilder.Entity<ValeDeVenta>().HasIndex(e => new { e.VentaId }).IsUnique();


    }
}
