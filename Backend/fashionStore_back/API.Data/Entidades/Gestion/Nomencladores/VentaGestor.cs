namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class VentaGestor : EntidadBase
    {
        
        public required Guid VentaId { get; set; }
        public required Venta Venta { get; set; }

        public required Guid GestorId { get; set; }
        public required Gestor Gestor { get; set; }

    }
}
