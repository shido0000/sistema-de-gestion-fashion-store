using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class VentaDto : EntidadBaseDto
    {
        public required string Codigo { get; set; }
        public required DateTime Fecha { get; set; }
        //public required Guid GestorId { get; set; }
        //public Guid PagoGestorId { get; set; }
    }
}
