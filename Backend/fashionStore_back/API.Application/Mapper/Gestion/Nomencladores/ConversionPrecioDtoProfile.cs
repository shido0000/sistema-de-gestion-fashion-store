using API.Application.Dtos.Gestion.Nomencladores.ConversionPrecio;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class ConversionPrecioDtoProfile : BaseProfile<Producto, ConversionPrecioDto, CrearConversionPrecioInputDto, ActualizarConversionPrecioInputDto, ListadoPaginadoConversionPrecioDto>

    {
        public ConversionPrecioDtoProfile()
        {
            MapConversionPrecioDto();
        }

        public void MapConversionPrecioDto()
        {
            CreateMap<Producto, DetallesConversionPrecioDto>()
                .ReverseMap();
        }
    }
}
