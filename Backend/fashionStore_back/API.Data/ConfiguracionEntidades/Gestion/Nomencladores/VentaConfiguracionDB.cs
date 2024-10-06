using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class VentaConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venta>().ToTable("Ventas");
        EntidadBaseConfiguracionBD<Venta>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<Venta>().Property(e => e.Fecha).IsRequired();
        modelBuilder.Entity<Venta>().Property(e => e.Codigo).IsRequired();
      

        modelBuilder.Entity<Venta>().HasIndex(e => new { e.Codigo }).IsUnique();
       
}
}
