using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.EstadoProducto
{
    public class CrearEstadoProductoInputDto : EstadoProductoDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }

    }
}
