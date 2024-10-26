using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Producto
{
    public class ProductoImprimirDto : ProductoDto
    {
        public required string EstadoProductoDescripcion{ get; set; }
    }
}
