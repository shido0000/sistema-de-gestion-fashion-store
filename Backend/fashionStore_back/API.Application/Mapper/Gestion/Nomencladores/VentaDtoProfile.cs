using API.Application.Dtos.Gestion.Nomencladores.Venta;
using API.Application.Dtos.Seguridad.Rol;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;

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
            .ForMember(dto => dto.GestorDescripcion, opt => opt.MapFrom(e => e.Gestor.Nombre))
            .ForMember(dto => dto.Productos, opt => opt.MapFrom(e => e.ProductosVentas.Select(productoVenta => productoVenta.Producto)));
        }

        public override void MapActualizarEntityDto()
        {
            CreateMap<Venta, ActualizarVentaInputDto>()
                .ForMember(dto => dto.ProductosIds, opt => opt.MapFrom(e => e.ProductosVentas.Select(e => e.Id)));
            CreateMap<ActualizarVentaInputDto, Venta>()
                .ForMember(opt => opt.ProductosVentas, dto => dto.MapFrom(e => e.ProductosIds.Select((productoId, index) => new ProductoVenta { ProductoId = productoId, VentaId = e.Id,  PrecioGestor = e.PreciosGestor[index], Cantidad = e.Cantidades[index]})));
        }

        public override void MapCrearEntityDto()
        {
            CreateMap<Venta, CrearVentaInputDto>()
                .ForMember(dto => dto.ProductosIds, opt => opt.MapFrom(e => e.ProductosVentas.Select(e => e.Id)));
            CreateMap<CrearVentaInputDto, Venta>()
                .ForMember(opt => opt.ProductosVentas, dto => dto.MapFrom(e => e.ProductosIds.Select((productoId, index) => new ProductoVenta { ProductoId = productoId, VentaId = e.Id, PrecioGestor = e.PreciosGestor[index], Cantidad = e.Cantidades[index] })));
        }
    }
}
