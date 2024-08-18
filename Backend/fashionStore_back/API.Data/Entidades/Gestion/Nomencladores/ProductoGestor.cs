namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class ProductoGestor : EntidadBase
    {
        public required float PrecioGestor { get; set; }
        public required Guid ProductoId { get; set; }
        public required Producto Producto { get; set; }

        public required Guid GestorId { get; set; }
        public required Gestor Gestor { get; set; }

    }
}
