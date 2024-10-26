using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Pago.Nomencladores;
using API.Domain.Validators.Pago.Nomencladores;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace API.Domain.Services.Pago.Nomencladores
{
    public class PagoGestorService : BasicService<PagoGestor, PagoGestorValidator>, IPagoGestorService
    {

        public PagoGestorService(IUnitOfWork<PagoGestor> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public override async Task<EntityEntry<PagoGestor>> Actualizar(PagoGestor entity)
        {
            PagoGestor? pagoGestor = await ObtenerPorId(entity.Id) ??
                throw new CustomException() { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

            pagoGestor.Pagado = entity.Pagado;
            return await base.Actualizar(pagoGestor);
        }

        public async Task<string> ObtenerNombreCompletoGestorPorVentaDada(Guid ventaId)
        {
            ProductoVendido? productoVendido = await _repositorios.ProductosVendidos.FirstAsync(e => e.VentaId == ventaId);

            if (productoVendido != null)
            {
                Gestor? gestor = await _repositorios.Gestores.FirstAsync(e => e.Id == productoVendido.GestorId);
                if (gestor != null)
                {
                    return gestor.Nombre +" "+ gestor.Apellidos;
                }
                
            }
            return string.Empty;
        }
    }
}