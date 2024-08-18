using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.ValeDeVenta
{
    public class CrearValeDeVentaInputDto : ValeDeVentaDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }

    }
}
