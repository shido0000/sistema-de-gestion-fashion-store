using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Producto
{
    public class CrearProductoInputDto : ProductoDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }

    }
}
