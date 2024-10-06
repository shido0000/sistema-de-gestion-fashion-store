using System.Text.Json.Serialization;

namespace API.Application.Dtos.Pago.Nomencladores.PagoGestor
{
    public class CrearPagoGestorInputDto : PagoGestorDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }

    }
}
