namespace API.Data.Entidades.Gestion.Nomencladores
{
    public class Gestor : EntidadBase
    {
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        //  public List<ProductoGestor> ProductosGestores { get; set; } = new();
        public List<ProductoVendido> ProductosVendidos { get; set; } = new();
    }
}
