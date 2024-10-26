using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Domain.Services.Gestion.Nomencladores
{
    public class ProductoService : BasicService<Producto, ProductoValidator>, IProductoService
    {
        private readonly IEstadoProductoService _EstadoProductoService;

        public ProductoService(IUnitOfWork<Producto> repositorios, IHttpContextAccessor httpContext, IEstadoProductoService serviceEstadoProducto) : base(repositorios, httpContext)
        {
            _EstadoProductoService = serviceEstadoProducto;
        }

        public async Task<int> CantidadProductoVendido(Guid productoId)
        {
            Producto? producto = await ObtenerPorId(productoId, propiedadesIncluidas: query => query.Include(e => e.ProductosVendidos)) ??
                throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

            int cantidad = 0;
            for (int i = 0; i < producto.ProductosVendidos.Count; i++)
            {
                cantidad += producto.ProductosVendidos[i].Cantidad;
            }
            return cantidad;
        }

        public override async Task<EntityEntry<Producto>> Actualizar(Producto entity)
        {
            Producto? producto = await ObtenerPorId(entity.Id) ??
                throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

             
       

            if (entity.CantidadStock == 0)
            {
                entity.EstadoProductoId = await _EstadoProductoService.ObtenerIdPorDescripcion("Agotado");
            }
            else {
                entity.EstadoProductoId = await _EstadoProductoService.ObtenerIdPorDescripcion("Disponible");
            }
          

            return await base.Actualizar(entity);
        }
    }
}