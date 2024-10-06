using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Data.Entidades.Pago.Nomencladores
{
    public class PagoGestor : EntidadBase
    {
        public required Guid VentaId { get; set; }
        public required Venta Venta { get; set; }
        public required float PagoTotal { get; set; }
        public required bool Pagado { get; set; }

    }
}
