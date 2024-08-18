using API.Application.Dtos.Gestion.Nomencladores.EstadoProducto;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class EstadoProductoDtoProfile : BaseProfile<EstadoProducto, EstadoProductoDto, CrearEstadoProductoInputDto, ActualizarEstadoProductoInputDto, ListadoPaginadoEstadoProductoDto>

    {
        public EstadoProductoDtoProfile()
        {
            MapEstadoProductoDto();
        }

        public void MapEstadoProductoDto()
        {
            CreateMap<EstadoProducto, DetallesEstadoProductoDto>()
                .ReverseMap();
        }
    }
}
