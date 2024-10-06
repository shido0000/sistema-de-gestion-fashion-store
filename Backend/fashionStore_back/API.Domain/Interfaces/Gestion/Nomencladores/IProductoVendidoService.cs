using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;

namespace API.Domain.Interfaces.Gestion.Nomencladores
{
    public interface IProductoVendidoService : IBaseService<ProductoVendido, ProductoVendidoValidator>
    {
        Task EliminarPorVenta(Guid id);
    }
}