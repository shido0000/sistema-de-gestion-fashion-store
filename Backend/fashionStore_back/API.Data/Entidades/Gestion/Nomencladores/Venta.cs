namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class Venta : EntidadBase
    {
        public required DateTime Fecha { get; set; }
        public List<VentaGestor> VentasGestores { get; set; } = new();

    }
}
