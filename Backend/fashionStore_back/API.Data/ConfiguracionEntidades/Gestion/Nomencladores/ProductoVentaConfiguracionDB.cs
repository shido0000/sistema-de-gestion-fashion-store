using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ProductoVentaConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductoVenta>().ToTable("ProductosVentas");
        EntidadBaseConfiguracionBD<ProductoVenta>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<ProductoVenta>().Property(e => e.Cantidad);
        modelBuilder.Entity<ProductoVenta>().Property(e => e.PrecioGestor);
       // modelBuilder.Entity<ProductoVenta>().HasOne(e => e.Venta).WithMany(e => e.ProductosVendidos).HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.Cascade);
      //  modelBuilder.Entity<ProductoVenta>().HasOne(e => e.Producto).WithMany(e => e.ProductosVendidos).HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductoVenta>().HasIndex(e => new { e.VentaId, e.ProductoId }).IsUnique();

    }
}
