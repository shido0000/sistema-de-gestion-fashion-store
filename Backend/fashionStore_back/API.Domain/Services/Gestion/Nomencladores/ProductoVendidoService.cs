using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;


namespace API.Domain.Services.Gestion.Nomencladores
{
    public class ProductoVendidoService : BasicService<ProductoVendido, ProductoVendidoValidator>, IProductoVendidoService
    {

        public ProductoVendidoService(IUnitOfWork<ProductoVendido> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public async Task EliminarPorVenta(Guid ventaId)
        {
            var productosVentas = await _repositorios.ProductosVendidos.GetAllAsync(e => e.VentaId == ventaId);
            _repositorios.ProductosVendidos.RemoveRange(productosVentas);
        }
    }
}