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
    public class VentaService : BasicService<Venta, VentaValidator>, IVentaService
    {
        private readonly IProductoVendidoService _ProductoVendidoService;
        private readonly IProductoService _ProductoService;

        public VentaService(IUnitOfWork<Venta> repositorios, IHttpContextAccessor httpContext, IProductoVendidoService productoVendidoService, IProductoService productoService) : base(repositorios, httpContext)
        {
            _ProductoVendidoService = productoVendidoService;
            _ProductoService = productoService;
        }

        public override async Task<EntityEntry<Venta>> Eliminar(Guid id)
        {
            Venta? venta = await ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.ProductosVendidos)) ??
               throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };



            for (int i = 0; i < venta.ProductosVendidos.Count;i++) {
                ProductoVendido? productoVendido = await _ProductoVendidoService.ObtenerPorId(venta.ProductosVendidos[i].Id) ??
                   throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

              Producto? producto = await _ProductoService.ObtenerPorId(productoVendido.ProductoId) ??
                      throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

                producto.CantidadStock += productoVendido.Cantidad;

                await _ProductoService.Actualizar(producto);
            }

            return await base.Eliminar(id);
        }
    }
}