namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class Venta : EntidadBase
    {
        public required DateTime Fecha { get; set; }
        public required Guid GestorId { get; set; }
        public required Gestor Gestor { get; set; }
        public List<ProductoVenta> ProductosVentas { get; set; } = new();
    }
}
