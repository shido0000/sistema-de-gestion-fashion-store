using API.Application.Dtos.Gestion.Nomencladores.ValeDeVenta;
using API.Data.Entidades.Gestion.Nomencladores;

namespace API.Application.Mapper.Gestion.Nomencladores
{
    public class ValeDeVentaDtoProfile : BaseProfile<ValeDeVenta, ValeDeVentaDto, CrearValeDeVentaInputDto, ActualizarValeDeVentaInputDto, ListadoPaginadoValeDeVentaDto>

    {
        public ValeDeVentaDtoProfile()
        {
            MapValeDeVentaDto();
        }

        public void MapValeDeVentaDto()
        {
            CreateMap<ValeDeVenta, DetallesValeDeVentaDto>()
                .ReverseMap();
        }
    }
}
