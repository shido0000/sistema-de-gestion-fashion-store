using API.Data.Entidades.Pago.Nomencladores;

namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class Venta : EntidadBase
    {
        public required string Codigo { get; set; }
        public required DateTime Fecha { get; set; }
 
        public List<ProductoVendido> ProductosVendidos { get; set; } = new();
    }
}
