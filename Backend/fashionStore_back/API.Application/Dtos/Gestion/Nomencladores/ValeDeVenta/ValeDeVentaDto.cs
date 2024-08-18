using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.ValeDeVenta
{
    public class ValeDeVentaDto : EntidadBaseDto
    {
        public required string Domicilio { get; set; }
        public required Guid VentaId { get; set; }
    }
}
