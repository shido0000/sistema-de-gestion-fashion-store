namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class ValeDeVenta : EntidadBase
    {
        public required string Domicilio { get; set; }
        public required Guid VentaId { get; set; }
        public required Venta Venta { get; set; }

    }
}
