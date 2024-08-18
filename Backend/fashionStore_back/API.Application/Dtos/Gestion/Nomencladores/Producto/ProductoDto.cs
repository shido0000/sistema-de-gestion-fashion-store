using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Producto
{
    public class ProductoDto : EntidadBaseDto
    {
        public required string Codigo { get; set; }
        public required string Descripcion { get; set; }
        public required float Costo { get; set; }
        public required float PrecioUSD { get; set; }
        // public required int Imagen { get; set; }
        public required int Cantidad { get; set; }

        public required Guid EstadoProductoId { get; set; }
    }
}
