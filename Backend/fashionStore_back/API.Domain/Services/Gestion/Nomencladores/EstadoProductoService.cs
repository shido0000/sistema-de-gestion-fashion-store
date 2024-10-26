using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;


namespace API.Domain.Services.Gestion.Nomencladores
{
    public class EstadoProductoService : BasicService<EstadoProducto, EstadoProductoValidator>, IEstadoProductoService
    {

        public EstadoProductoService(IUnitOfWork<EstadoProducto> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public async Task<Guid> ObtenerIdPorDescripcion(string descripcion) {
            EstadoProducto? estadoProducto = await _repositorios.EstadosProductos.FirstAsync(e => e.Descripcion == descripcion);

            if (estadoProducto != null) {
                return estadoProducto.Id;
            }
            else {
                return Guid.Empty;
            }
        }
    }
}