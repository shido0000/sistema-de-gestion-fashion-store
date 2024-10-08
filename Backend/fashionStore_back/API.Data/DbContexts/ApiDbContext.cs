﻿using API.Data.ConfiguracionEntidades.Gestion.Nomencladores;
using API.Data.ConfiguracionEntidades.Pago.Nomencladores;
using API.Data.ConfiguracionEntidades.Seguridad;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DbContexts
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        // SEGURIDAD
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermiso { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Traza> Trazas { get; set; }


        // GESTION  

        public DbSet<ConversionPrecio> ConversionesPrecios { get; set; }
        public DbSet<EstadoProducto> EstadosProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Gestor> Gestores { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ValeDeVenta> ValesDeVentas { get; set; }



        // PAGO  
        public DbSet<PagoGestor> PagosGestores { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SEGURIDAD
            RolPermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            RolConfiguracionBD.SetEntityBuilder(modelBuilder);
            PermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioConfiguracionBD.SetEntityBuilder(modelBuilder);
            TrazaConfiguracionBD.SetEntityBuilder(modelBuilder);



            // GESTION
            ConversionPrecioConfiguracionDB.SetEntityBuilder(modelBuilder);
            EstadoProductoConfiguracionDB.SetEntityBuilder(modelBuilder);
            ProductoConfiguracionDB.SetEntityBuilder(modelBuilder);
            GestorConfiguracionDB.SetEntityBuilder(modelBuilder);
            ProductoVendidoConfiguracionDB.SetEntityBuilder(modelBuilder);
            VentaConfiguracionDB.SetEntityBuilder(modelBuilder);
            ValeDeVentaConfiguracionDB.SetEntityBuilder(modelBuilder);

            // PAGO

            PagoGestorConfiguracionDB.SetEntityBuilder(modelBuilder);

            // BASE
            base.OnModelCreating(modelBuilder);
        }
    }
}
