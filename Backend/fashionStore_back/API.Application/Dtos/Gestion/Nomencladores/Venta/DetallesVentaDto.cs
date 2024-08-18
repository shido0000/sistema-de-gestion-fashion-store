using API.Application.Dtos.Gestion.Nomencladores.Producto;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class DetallesVentaDto : VentaDto
    {
        public required string GestorDescripcion { get; set; }
        public List<ProductoDto> Productos { get; set; } = new();
        
    }
}
