using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Gestor
{
    public class CrearGestorInputDto : GestorDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
        public required List<Guid> ProductosIds { get; set; } = new();
        public required List<Guid> VentasIds { get; set; } = new();
    }
}
