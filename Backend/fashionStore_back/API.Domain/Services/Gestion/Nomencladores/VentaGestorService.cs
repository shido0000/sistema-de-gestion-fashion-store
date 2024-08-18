using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;


namespace API.Domain.Services.Gestion.Nomencladores
{
    public class VentaGestorService : BasicService<VentaGestor, VentaGestorValidator>, IVentaGestorService
    {

        public VentaGestorService(IUnitOfWork<VentaGestor> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public async Task EliminarPorGestor(Guid gestorId)
        {
            var ventasGestores = await _repositorios.VentasGestores.GetAllAsync(e => e.GestorId == gestorId);
            _repositorios.VentasGestores.RemoveRange(ventasGestores);
        }
    }
}