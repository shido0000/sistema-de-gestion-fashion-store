using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class ProductoDtoProfile : BaseProfile<Producto, ProductoDto, CrearProductoInputDto, ActualizarProductoInputDto, ListadoPaginadoProductoDto>

    {
        public ProductoDtoProfile()
        {
            MapProductoDto();
        }

        public void MapProductoDto()
        {
            CreateMap<Producto, DetallesProductoDto>()
                .ForMember(dto => dto.EstadoProductoDescripcion, opt => opt.MapFrom(e => e.EstadoProducto.Descripcion))
                .ReverseMap();
        }
    }
}
