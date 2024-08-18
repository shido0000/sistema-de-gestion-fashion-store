using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class ActualizarVentaInputDto : VentaDto
    {
        public required List<Guid> ProductosIds { get; set; } = new();
        public required List<float> PreciosGestor { get; set; } = new();
        public required List<int> Cantidades { get; set; } = new();
    }
}
