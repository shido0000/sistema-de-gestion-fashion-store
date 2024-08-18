using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Gestion.Nomencladores.ConversionPrecio
{
    public class ConversionPrecioDto : EntidadBaseDto
    {      
        public string Descripcion { get; set; }
        public float valorCambio { get; set; }
    }
}
