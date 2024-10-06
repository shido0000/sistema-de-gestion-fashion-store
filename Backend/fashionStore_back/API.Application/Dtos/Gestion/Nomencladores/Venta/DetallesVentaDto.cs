using API.Application.Dtos.Gestion.Nomencladores.Gestor;
using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class DetallesVentaDto : VentaDto
    {
        public required string GestorDescripcion { get; set; }
        //public required List<ProductoVendido> ProductosVendidos { get; set; } = new();
        public required List<ProductoVendido> ProductosVendidos { get; set; } = new();
        //  public List<ProductoDto> Productos { get; set; } = new();
        ///   public GestorDto Gestor { get; set; }  


        //   public required List<float> PreciosGestor { get; set; } = new();
        //   public required List<int> Cantidades { get; set; } = new();
    }
}
