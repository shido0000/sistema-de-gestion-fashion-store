using System.Text.Json.Serialization;

namespace API.Application.Dtos.Pago.Nomencladores.PagoGestor
{
    public class ActualizarPagoGestorInputDto : PagoGestorDto
    {
        [JsonIgnore]
        public new float PagoTotal { get; set; }
        [JsonIgnore]
        public new Guid VentaId { get; set; }
    }
}
