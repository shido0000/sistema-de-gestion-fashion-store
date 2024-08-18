using API.Data.Entidades.Gestion.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class EstadoProductoConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstadoProducto>().ToTable("EstadosProductos");
        EntidadBaseConfiguracionBD<EstadoProducto>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<EstadoProducto>().Property(e => e.Descripcion).IsRequired();
      }
}
