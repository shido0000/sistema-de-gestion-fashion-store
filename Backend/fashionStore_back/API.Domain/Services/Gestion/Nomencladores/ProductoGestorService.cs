using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;


namespace API.Domain.Services.Gestion.Nomencladores
{
    public class ProductoGestorService : BasicService<ProductoGestor, ProductoGestorValidator>, IProductoGestorService
    {

        public ProductoGestorService(IUnitOfWork<ProductoGestor> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public async Task EliminarPorGestor(Guid gestorId)
        {
            var productosGestores = await _repositorios.ProductosGestores.GetAllAsync(e => e.GestorId == gestorId);
            _repositorios.ProductosGestores.RemoveRange(productosGestores);
        }
    }
}