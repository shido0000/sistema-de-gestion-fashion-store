using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Pago.Nomencladores;

public class PagoGestorConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PagoGestor>().ToTable("PagosGestores");
        EntidadBaseConfiguracionBD<PagoGestor>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<PagoGestor>().Property(e => e.VentaId).IsRequired();
        modelBuilder.Entity<PagoGestor>().Property(e => e.PagoTotal).IsRequired();
        modelBuilder.Entity<PagoGestor>().Property(e => e.Pagado).IsRequired();

        modelBuilder.Entity<PagoGestor>().HasIndex(e => new { e.VentaId }).IsUnique();
        // modelBuilder.Entity<PagoGestor>().HasOne(e => e.VentaId).WithOne().HasForeignKey(e => e.EstadoProductoId).OnDelete(DeleteBehavior.Restrict);
  //      modelBuilder.Entity<PagoGestor>().HasOne(e => e.Venta).WithOne(v => v.PagoGestor).HasForeignKey<PagoGestor>(e => e.VentaId).OnDelete(DeleteBehavior.Restrict);
    }
}
