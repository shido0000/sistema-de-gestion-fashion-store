using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Gestor
{
    public class ActualizarGestorInputDto : GestorDto
    {
        public required List<Guid> ProductosIds { get; set; } = new();
        public required List<Guid> VentasIds { get; set; } = new();
    }
}
