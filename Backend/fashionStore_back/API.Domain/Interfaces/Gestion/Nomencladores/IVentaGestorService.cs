using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;

namespace API.Domain.Interfaces.Gestion.Nomencladores
{
    public interface IVentaGestorService : IBaseService<VentaGestor, VentaGestorValidator>
    {
        Task EliminarPorGestor(Guid id);
    }
}