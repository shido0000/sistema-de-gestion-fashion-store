using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Gestor
{
    public class CrearGestorInputDto : GestorDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
      //  public List<Guid> ProductosIds { get; set; } = new();
    }
}
