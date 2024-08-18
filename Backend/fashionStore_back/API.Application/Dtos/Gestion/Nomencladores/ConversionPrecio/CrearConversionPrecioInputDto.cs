using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.ConversionPrecio
{
    public class CrearConversionPrecioInputDto : ConversionPrecioDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }

    }
}
