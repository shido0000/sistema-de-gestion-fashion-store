using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ProductoGestorConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductoGestor>().ToTable("ProductosGestores");
        EntidadBaseConfiguracionBD<ProductoGestor>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<ProductoGestor>().HasOne(e => e.Gestor).WithMany(e => e.ProductosGestores).HasForeignKey(e => e.GestorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductoGestor>().HasOne(e => e.Producto).WithMany(e => e.ProductosGestores).HasForeignKey(e => e.ProductoId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductoGestor>().HasIndex(e => new { e.GestorId, e.ProductoId }).IsUnique();

    }
}
