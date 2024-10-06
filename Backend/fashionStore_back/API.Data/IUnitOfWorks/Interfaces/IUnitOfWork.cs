using API.Data.Entidades;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces.Pago.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces.Seguridad;

namespace API.Data.IUnitOfWorks.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : EntidadBase
    {
        // SEGURIDAD
        IPermisoRepository Permisos { get; }
        IRolPermisoRepository RolesPermisos { get; }
        IRolRepository Roles { get; }
        IUsuarioRepository Usuarios { get; }

        // BASE
        IBaseRepository<TEntity> BasicRepository { get; }
        ITrazaRepository Trazas { get; }

        // GESTION

        IConversionPrecio ConversionesPrecios { get; }
        IEstadoProducto EstadosProductos { get; }
        IProducto Productos { get; }
        IGestor Gestores { get; }
        IProductoVendido ProductosVendidos { get; }
        IVenta Ventas { get; }
        IValeDeVenta ValesDeVentas { get; }

        //PAGO
        IPagoGestor PagosGestores { get; }
       


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
