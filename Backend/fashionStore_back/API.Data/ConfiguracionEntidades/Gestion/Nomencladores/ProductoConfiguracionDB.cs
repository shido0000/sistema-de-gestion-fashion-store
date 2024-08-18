using API.Data.Entidades.Gestion.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class ProductoConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>().ToTable("Productos");
        EntidadBaseConfiguracionBD<Producto>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<Producto>().Property(e => e.Codigo).IsRequired();     
        modelBuilder.Entity<Producto>().Property(e => e.Descripcion).IsRequired();     
        modelBuilder.Entity<Producto>().Property(e => e.Costo).IsRequired();     
        modelBuilder.Entity<Producto>().Property(e => e.PrecioUSD).IsRequired();     
        modelBuilder.Entity<Producto>().Property(e => e.Cantidad).IsRequired();     
        modelBuilder.Entity<Producto>().Property(e => e.EstadoProductoId).IsRequired();
        // modelBuilder.Entity<Producto>().Property(e => e.Imagen);

        modelBuilder.Entity<Producto>().HasIndex(e => new { e.Codigo}).IsUnique();
        modelBuilder.Entity<Producto>().HasOne(e => e.EstadoProducto).WithMany(e => e.Productos).HasForeignKey(e => e.EstadoProductoId).OnDelete(DeleteBehavior.Restrict);
    }
}
