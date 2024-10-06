using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class ProductoVendidoAuxiliarDto : EntidadBaseDto
    {
        public float PrecioGestor { get; set; }
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid GestorId { get; set; }
        public Guid VentaId { get; set; }
    }
}
