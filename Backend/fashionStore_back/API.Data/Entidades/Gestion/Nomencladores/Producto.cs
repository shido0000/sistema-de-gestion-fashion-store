namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class Producto : EntidadBase
    {
        public required string Codigo { get; set; }
        public required string Descripcion { get; set; }
        public required float Costo { get; set; }
        public required float PrecioUSD { get; set; }
       // public required int Imagen { get; set; }
        public required int Cantidad { get; set; }
      
        public required Guid EstadoProductoId { get; set; }
        public required EstadoProducto EstadoProducto { get; set; }

        public List<ProductoVenta> ProductosVentas { get; set; } = new();
    }
}
