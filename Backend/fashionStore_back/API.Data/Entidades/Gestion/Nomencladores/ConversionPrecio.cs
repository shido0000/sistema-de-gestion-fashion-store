namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class ConversionPrecio : EntidadBase
    {
        public required string Descripcion { get; set; }
        public required float valorCambio { get; set; }
       
    }
}
