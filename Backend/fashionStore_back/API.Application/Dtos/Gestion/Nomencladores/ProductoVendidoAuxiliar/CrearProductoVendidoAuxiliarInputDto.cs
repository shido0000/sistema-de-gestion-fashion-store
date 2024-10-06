using API.Data.Entidades.Gestion.Nomencladores;
using System.Text.Json.Serialization;

namespace API.Application.Dtos.Gestion.Nomencladores.Venta
{
    public class CrearProductoVendidoAuxiliarInputDto : ProductoVendidoAuxiliarDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
       
    }
}
