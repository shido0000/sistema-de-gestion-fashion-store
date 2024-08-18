using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class VentaDto : EntidadBaseDto
    {
        public required DateTime Fecha { get; set; }
    }
}
