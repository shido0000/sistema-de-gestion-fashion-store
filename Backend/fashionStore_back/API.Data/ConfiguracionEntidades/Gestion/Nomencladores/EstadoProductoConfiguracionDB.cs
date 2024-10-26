using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Gestion.Nomencladores;

public class EstadoProductoConfiguracionDB
{
    public static void SetEntityBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstadoProducto>().ToTable("EstadosProductos");
        EntidadBaseConfiguracionBD<EstadoProducto>.SetEntityBuilder(modelBuilder);

        modelBuilder.Entity<EstadoProducto>().Property(e => e.Descripcion).IsRequired();


        #region Seed

        EstadoProducto estadoProductoDisponible = new()
        {
            Id = new Guid("1C8FCFE3-5718-4A36-BD3A-681241488A6B"),
            Descripcion = "Disponible",
        };
        EstadoProducto estadoProductoAgotado = new()
        {
            Id = new Guid("37760DA6-B5DE-4A1D-B5B7-CDE6A462E192"),
            Descripcion = "Agotado",
        };
        /*EstadoProducto estadoProductoReservado = new()
        {
            Id = new Guid("4BEEEB16-931B-4F2A-9355-FA19CF76ED54"),
            Descripcion = "Reservado",
        };*/
        // modelBuilder.Entity<EstadoProducto>().HasData(estadoProductoDisponible,estadoProductoAgotado,estadoProductoReservado);
        modelBuilder.Entity<EstadoProducto>().HasData(estadoProductoDisponible, estadoProductoAgotado);
        #endregion
    }
}
