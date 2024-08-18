using API.Application.Dtos.Gestion.Nomencladores.EstadoProducto;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class EstadoProductoController : BasicController<EstadoProducto, EstadoProductoValidator, DetallesEstadoProductoDto, CrearEstadoProductoInputDto, ActualizarEstadoProductoInputDto, ListadoPaginadoEstadoProductoDto, FiltrarConfigurarListadoPaginadoEstadoProductoIntputDto>
    {
        private readonly IEstadoProductoService _EstadoProductoService;

        public EstadoProductoController(IMapper mapper, IEstadoProductoService servicioEstadoProducto, IEstadoProductoService estadoProductoService) : base(mapper, servicioEstadoProducto)
        {
            _EstadoProductoService = estadoProductoService;
        }
    }
}
