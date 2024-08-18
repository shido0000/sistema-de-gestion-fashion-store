namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class ProductoVenta : EntidadBase
    {
        public  float PrecioGestor { get; set; }
        public  int Cantidad { get; set; }
        public  Guid ProductoId { get; set; }
        public  Producto Producto { get; set; } = null!;

        public  Guid VentaId { get; set; }
        public  Venta Venta { get; set; } = null!;

    }
}
