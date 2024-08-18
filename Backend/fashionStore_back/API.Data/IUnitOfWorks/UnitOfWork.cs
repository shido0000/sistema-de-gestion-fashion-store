using API.Data.DbContexts;
using API.Data.Entidades;
using API.Data.IUnitOfWorks.Interfaces;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces.Seguridad;
using API.Data.IUnitOfWorks.Repositorios;
using API.Data.IUnitOfWorks.Repositorios.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Repositorios.Seguridad;

namespace API.Data.IUnitOfWorks
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : EntidadBase
    {
        private readonly ApiDbContext _context;

        // SEGURIDAD
        public IPermisoRepository Permisos { get; }
        public IRolPermisoRepository RolesPermisos { get; }
        public IRolRepository Roles { get; }
        public IUsuarioRepository Usuarios { get; }
        public ITrazaRepository Trazas { get; }




        // GESTION

        public IConversionPrecio ConversionesPrecios { get; }
        public IEstadoProducto EstadosProductos { get; }
        public IProducto Productos { get; }
        public IGestor Gestores { get; }
        public IProductoVenta ProductosVentas { get; }
       
        public IVenta Ventas { get; }
        public IValeDeVenta ValesDeVentas { get; }
      

        // BASE
        public IBaseRepository<TEntity> BasicRepository { get; }

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;

            // SEGURIDAD
            Permisos = new PermisoRepository(context);
            RolesPermisos = new RolPermisoRepository(context);
            Roles = new RolRepository(context);
            Usuarios = new UsuarioRepository(context);
            Trazas = new TrazaRepository(context);



            // GESTION
            ConversionesPrecios = new ConversionPrecioRepository(context);
            EstadosProductos = new EstadoProductoRepository(context);
            Productos = new ProductoRepository(context);
            Gestores = new GestorRepository(context);         
            ProductosVentas = new ProductoVentaRepository(context);
            Ventas = new VentaRepository(context);
            ValesDeVentas = new ValeDeVentaRepository(context);
             
            
           

            // BASE
            BasicRepository = new BaseRepository<TEntity>(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
           => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();


    }
}
