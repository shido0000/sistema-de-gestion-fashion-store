using API.Data.Entidades.Pago.Nomencladores;
using API.Domain.Validators.Pago.Nomencladores;

namespace API.Domain.Interfaces.Pago.Nomencladores
{
    public interface IPagoGestorService : IBaseService<PagoGestor, PagoGestorValidator>
    {
        Task<string> ObtenerNombreCompletoGestorPorVentaDada(Guid ventaId);
    }
}