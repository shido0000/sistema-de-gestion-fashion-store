using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class DetallesProductoVendidoAuxiliarDto : EntidadBaseDto
    {
        public float PrecioGestor { get; set; }
        public int Cantidad { get; set; }
        public string ProductoDescripcion { get; set; }
        public string GestorNombre { get; set; }
    }
}
