using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Pago.Nomencladores.PagoGestor
{
    public class PagoGestorDto : EntidadBaseDto
    {
        public  Guid VentaId { get; set; }
        public  float PagoTotal { get; set; }
        public required bool Pagado { get; set; }
    }
}
