using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class VentaGestorConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VentaGestor>().ToTable("VentasGestores");
        EntidadBaseConfiguracionBD<VentaGestor>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<VentaGestor>().HasOne(e => e.Gestor).WithMany(e => e.VentasGestores).HasForeignKey(e => e.GestorId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VentaGestor>().HasOne(e => e.Venta).WithMany(e => e.VentasGestores).HasForeignKey(e => e.VentaId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<VentaGestor>().HasIndex(e => new { e.GestorId, e.VentaId }).IsUnique();

    }
}
