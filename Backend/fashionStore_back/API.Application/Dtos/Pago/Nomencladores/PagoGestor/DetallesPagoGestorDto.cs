using API.Application.Dtos.Gestion.Nomencladores.Venta;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Dtos.Pago.Nomencladores.PagoGestor
{
    public class DetallesPagoGestorDto : PagoGestorDto
    {
        public required string VentaCodigo { get; set; }
        public required string NombreGestor { get; set; }
        public required DetallesVentaDto Venta { get; set; }

    }
}
