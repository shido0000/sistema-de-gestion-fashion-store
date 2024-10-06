namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class ProductoVendido : EntidadBase
    {
   
        public  float PrecioGestor { get; set; }        
        public  int Cantidad { get; set; }
        public  Guid ProductoId { get; set; }
        public  Producto Producto { get; set; }

        public  Guid GestorId { get; set; }
        public  Gestor Gestor { get; set; }

        public  Guid VentaId { get; set; }
        public  Venta Venta { get; set; }
        
    }
}
