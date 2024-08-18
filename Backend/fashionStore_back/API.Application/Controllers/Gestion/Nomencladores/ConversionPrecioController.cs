using API.Application.Dtos.Gestion.Nomencladores.ConversionPrecio;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class ConversionPrecioController : BasicController<ConversionPrecio, ConversionPrecioValidator, DetallesConversionPrecioDto, CrearConversionPrecioInputDto, ActualizarConversionPrecioInputDto, ListadoPaginadoConversionPrecioDto, FiltrarConfigurarListadoPaginadoConversionPrecioIntputDto>
    {
        private readonly IConversionPrecioService _ConversionPrecioService;

        public ConversionPrecioController(IMapper mapper, IConversionPrecioService servicioConversionPrecio, IConversionPrecioService conversionPrecioService) : base(mapper, servicioConversionPrecio)
        {
            _ConversionPrecioService = conversionPrecioService;
        }
    }
}
