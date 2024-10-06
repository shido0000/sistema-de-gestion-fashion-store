using API.Data.DbContexts;
using API.Data.Entidades.Pago.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces.Pago.Nomencladores;

namespace API.Data.IUnitOfWorks.Repositorios.Pago.Nomencladores
{
    public class PagoGestorRepository : BaseRepository<PagoGestor>, IPagoGestor
    {
        public PagoGestorRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
