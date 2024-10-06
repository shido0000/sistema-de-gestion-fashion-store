using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class ActualizarVentaInputDto : VentaDto
    {
        public required List<CrearProductoVendidoAuxiliarInputDto> ProductosVendidos { get; set; } = new();

    }
}
