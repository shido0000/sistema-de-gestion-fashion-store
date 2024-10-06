using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ProductoVendidoConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductoVendido>().ToTable("ProductosVendidos");
        EntidadBaseConfiguracionBD<ProductoVendido>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<ProductoVendido>().Property(e => e.ProductoId);
        modelBuilder.Entity<ProductoVendido>().Property(e => e.GestorId);
        modelBuilder.Entity<ProductoVendido>().Property(e => e.VentaId);
        modelBuilder.Entity<ProductoVendido>().Property(e => e.Cantidad);
        modelBuilder.Entity<ProductoVendido>().Property(e => e.PrecioGestor);
        modelBuilder.Entity<ProductoVendido>().HasOne(e => e.Venta).WithMany(e => e.ProductosVendidos).HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductoVendido>().HasOne(e => e.Producto).WithMany(e => e.ProductosVendidos).HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductoVendido>().HasOne(e => e.Gestor).WithMany(e => e.ProductosVendidos).HasForeignKey(e => e.GestorId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductoVendido>().HasIndex(e => new { e.VentaId, e.ProductoId, e.GestorId }).IsUnique();

    }
}
