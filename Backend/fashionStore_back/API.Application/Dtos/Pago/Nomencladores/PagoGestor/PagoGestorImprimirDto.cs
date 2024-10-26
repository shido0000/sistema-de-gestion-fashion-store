using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Pago.Nomencladores.PagoGestor
{
    public class PagoGestorImprimirDto : PagoGestorDto
    {
        public required string VentaDescripcion { get; set; }
        public required DateTime VentaFecha { get; set; }
        public required string GestorNombreCompleto { get; set; }
    
    }
}
