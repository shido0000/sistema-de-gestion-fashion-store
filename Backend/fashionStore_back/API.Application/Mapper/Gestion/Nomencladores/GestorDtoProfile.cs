using API.Application.Dtos.Gestion.Nomencladores.Gestor;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class GestorDtoProfile : BaseProfile<Gestor, GestorDto, CrearGestorInputDto, ActualizarGestorInputDto, ListadoPaginadoGestorDto>

    {
        public GestorDtoProfile()
        {
             
           MapGestorDto();
        }

        public void MapGestorDto()
        {
            CreateMap<Gestor, DetallesGestorDto>()
                 .ReverseMap();
        }

      /*  public void MapDetallesGestorDto()
        {
            CreateMap<Venta, DetallesGestorDto>()
            .ForMember(dto => dto.Productos, opt => opt.MapFrom(e => e.ProductosGestores.Select(productosGestores => productosGestores.Producto)));
         }*/

       /* public override void MapActualizarEntityDto()
        {
            CreateMap<Gestor, ActualizarGestorInputDto>()
                .ForMember(dto => dto.ProductosIds, opt => opt.MapFrom(e => e.ProductosGestores.Select(e => e.Id)))
                .ForMember(dto => dto.VentasIds, opt => opt.MapFrom(e => e.VentasGestores.Select(e => e.Id)));
            CreateMap<ActualizarGestorInputDto, Gestor>()
                 .ForMember(opt => opt.VentasGestores, dto => dto.MapFrom(e => e.VentasIds.Select(ventaId => new VentaGestor { VentaId = ventaId, GestorId = e.Id })))
                 .ForMember(opt => opt.ProductosGestores, dto => dto.MapFrom(e => e.ProductosIds.Select(productoId => new ProductoGestor { ProductoId = productoId, GestorId = e.Id })));
        }

        public override void MapCrearEntityDto()
        {
            CreateMap<Gestor, CrearGestorInputDto>()
                .ForMember(dto => dto.ProductosIds, opt => opt.MapFrom(e => e.ProductosGestores.Select(e => e.Id)))
                .ForMember(dto => dto.VentasIds, opt => opt.MapFrom(e => e.VentasGestores.Select(e => e.Id)));
            CreateMap<CrearGestorInputDto, Gestor>()
                .ForMember(opt => opt.VentasGestores, dto => dto.MapFrom(e => e.VentasIds.Select(ventaId => new VentaGestor { VentaId = ventaId, GestorId = e.Id })));
        }*/
    }
}
