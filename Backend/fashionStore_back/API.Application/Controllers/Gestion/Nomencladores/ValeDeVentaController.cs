using API.Application.Dtos.Gestion.Nomencladores.ValeDeVenta;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class ValeDeVentaController : BasicController<ValeDeVenta, ValeDeVentaValidator, DetallesValeDeVentaDto, CrearValeDeVentaInputDto, ActualizarValeDeVentaInputDto, ListadoPaginadoValeDeVentaDto, FiltrarConfigurarListadoPaginadoValeDeVentaIntputDto>
    {
        private readonly IValeDeVentaService _ValeDeVentaService;

        public ValeDeVentaController(IMapper mapper, IValeDeVentaService servicioValeDeVenta, IValeDeVentaService valeDeVentaService) : base(mapper, servicioValeDeVenta)
        {
            _ValeDeVentaService = valeDeVentaService;
        }
    }
}
