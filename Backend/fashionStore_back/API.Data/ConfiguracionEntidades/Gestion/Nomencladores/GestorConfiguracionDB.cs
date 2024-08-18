using API.Data.Entidades.Gestion.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class GestorConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gestor>().ToTable("Gestores");
        EntidadBaseConfiguracionBD<Gestor>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<Gestor>().Property(e => e.Nombre).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Gestor>().Property(e => e.Apellidos).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Gestor>().Property(e => e.Direccion).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Gestor>().Property(e => e.Telefono).HasMaxLength(8).IsRequired();
   
        modelBuilder.Entity<Gestor>().HasIndex(e => new { e.Nombre, e.Apellidos }).IsUnique();
  }
}
