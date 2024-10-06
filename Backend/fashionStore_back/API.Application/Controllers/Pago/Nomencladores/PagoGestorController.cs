using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Application.Dtos.Pago.Nomencladores.PagoGestor;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using API.Domain.Interfaces.Pago.Nomencladores;
using API.Domain.Validators.Pago.Nomencladores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API.Application.Controllers.Pago.Nomencladores
{

    public class PagoGestorController : BasicController<PagoGestor, PagoGestorValidator, DetallesPagoGestorDto, CrearPagoGestorInputDto, ActualizarPagoGestorInputDto, ListadoPaginadoPagoGestorDto, FiltrarConfigurarListadoPaginadoPagoGestorIntputDto>
    {
        private readonly IPagoGestorService _PagoGestorService;

        public PagoGestorController(IMapper mapper, IPagoGestorService servicioPagoGestor, IPagoGestorService pagoGestorService) : base(mapper, servicioPagoGestor)
        {
            _PagoGestorService = pagoGestorService;
        }

        protected override Task<(IEnumerable<PagoGestor>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoPagoGestorIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<PagoGestor, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(pagoGestor => pagoGestor.Venta.Codigo.Contains(inputDto.TextoBuscar)  

                    );
            }

             IIncludableQueryable<PagoGestor, object> propiedadesIncluidas(IQueryable<PagoGestor> query) => query.Include(e => e.Venta);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas, filtros.ToArray());
        }

        protected override async Task<PagoGestor?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Venta));

    }
}
