using API.Application.Dtos.Gestion.Nomencladores.Venta;
using API.Application.Dtos.Seguridad.Rol;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class VentaDtoProfile : BaseProfile<Venta, VentaDto, CrearVentaInputDto, ActualizarVentaInputDto, ListadoPaginadoVentaDto>

    {
        public VentaDtoProfile()
        {
            //   MapVentaDto();
            MapDetallesVentaDto();
        }


        public void MapDetallesVentaDto()
        {
            CreateMap<Venta, DetallesVentaDto>()
             .ForMember(dto => dto.ProductosVendidos, opt => opt.MapFrom(e => e.ProductosVendidos))
              .ReverseMap()
            
            ;
        }

        public override void MapActualizarEntityDto()
        {
            CreateMap<Venta, ActualizarVentaInputDto>()
                .ForMember(dto => dto.ProductosVendidos, opt => opt.MapFrom(e => e.ProductosVendidos.Select(e => e.Id)));
            CreateMap<ActualizarVentaInputDto, Venta>()
            .ForMember(opt => opt.ProductosVendidos, dto => dto.MapFrom(e => e.ProductosVendidos.Select(productoVendido => new ProductoVendido { GestorId = productoVendido.GestorId, ProductoId = productoVendido.ProductoId, VentaId = e.Id, PrecioGestor = productoVendido.PrecioGestor, Cantidad = productoVendido.Cantidad })));
        }
        public override void MapCrearEntityDto()
        {
            CreateMap<Venta, CrearVentaInputDto>()
            .ForMember(dto => dto.ProductosVendidos, opt => opt.MapFrom(e => e.ProductosVendidos.Select(e => e.Id)));
            CreateMap<CrearVentaInputDto, Venta>()
                .ForMember(opt => opt.ProductosVendidos, dto => dto.MapFrom(e => e.ProductosVendidos.Select(productoVendido => new ProductoVendido { GestorId = productoVendido.GestorId,  ProductoId = productoVendido.ProductoId, VentaId = e.Id, PrecioGestor = productoVendido.PrecioGestor , Cantidad = productoVendido.Cantidad })));
        }
    }
}
