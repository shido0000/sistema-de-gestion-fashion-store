using API.Application.Dtos.Pago.Nomencladores.PagoGestor;
using API.Data.Entidades.Pago.Nomencladores;

namespace API.Application.Mapper.Pago.Nomencladores
{
    public class PagoGestorDtoProfile : BaseProfile<PagoGestor, PagoGestorDto, CrearPagoGestorInputDto, ActualizarPagoGestorInputDto, ListadoPaginadoPagoGestorDto>

    {
        public PagoGestorDtoProfile()
        {
            MapPagoGestorDto();
        }

        public void MapPagoGestorDto()
        {
            CreateMap<PagoGestor, DetallesPagoGestorDto>()    
                .ForMember(dto => dto.VentaCodigo, opt => opt.MapFrom(e => e.Venta.Codigo))
 
                .ForMember(dto => dto.Venta, opt => opt.MapFrom(e => e.Venta))
                .ReverseMap();
        }
    }
}
