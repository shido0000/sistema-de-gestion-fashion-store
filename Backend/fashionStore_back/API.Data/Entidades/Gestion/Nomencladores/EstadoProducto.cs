namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class EstadoProducto : EntidadBase
    {
        public required string Descripcion { get; set; }
    
        public List<Producto> Productos { get; set; } = new();
        
    }
}
