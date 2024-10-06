using API.Application.Dtos.Comunes;
using API.Application.Dtos.Gestion.Nomencladores.Venta;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Services.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class VentaController : BasicController<Venta, VentaValidator, DetallesVentaDto, CrearVentaInputDto, ActualizarVentaInputDto, ListadoPaginadoVentaDto, FiltrarConfigurarListadoPaginadoVentaIntputDto>
    {
        // private readonly IVentaService _VentaService;
        private readonly IProductoVendidoService _productoVentaService;
        private readonly IVentaService _VentaService;

        public VentaController(IMapper mapper, IVentaService servicioVenta, IVentaService ventaService, IProductoVendidoService productoVentaService) : base(mapper, servicioVenta)
        {
            _productoVentaService = productoVentaService;
            _VentaService = ventaService;
        }
     /*   /// <summary>
        /// Retorna un listado para un Select
        /// </summary>
        /// <param name="inputDto">Datos de entrada</param>
        /// <response code="200">Completado con exito! </response>
        /// <response code="400">Ha ocurrido un error </response>
        [HttpGet("[action]")]
        public new async Task<IActionResult> ObtenerSelectList([FromQuery] ObtenerSelectListInputDto inputDto)
            => await base.ObtenerSelectList(inputDto);
     */

        /// <summary>
        /// Editar un elemento
        /// </summary>
        /// <param name="id">Id del elemento</param>
        /// <param name="actualizarDto">Elemento a editar</param>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        /// <response code="404">Elemento no encontrado</response>
        [HttpPut("[action]/{id}")]
        public override async Task<IActionResult> Actualizar(Guid id, ActualizarVentaInputDto actualizarDto)
        {
            await _productoVentaService.EliminarPorVenta(id);
            return await base.Actualizar(id, actualizarDto);
        }

        protected override Task<(IEnumerable<Venta>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoVentaIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Venta, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
                filtros.Add(venta =>  
                                     venta.Codigo.Contains(inputDto.TextoBuscar)  
                );

            /*   IIncludableQueryable<Venta, object> propiedadesIncluidas(IQueryable<Venta> query) => query
              .Include(e => e.Gestor)
              .Include(e => e.ProductosVentas)
              .ThenInclude(e => e.Producto);
               */

            //  return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.Gestor).Include(m => m.ProductosVentas).ThenInclude(x => x.Producto), filtros.ToArray());
           return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(m => m.ProductosVendidos).ThenInclude(x => x.Producto).Include(x => x.ProductosVendidos).ThenInclude(x => x.Gestor), filtros.ToArray());
        }

        protected override async Task<Venta?> ObtenerElementoPorId(Guid id)
           => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(m => m.ProductosVendidos).ThenInclude(x => x.Producto).Include(x => x.ProductosVendidos).ThenInclude(x => x.Gestor));


        /* protected override async Task<Venta?> ObtenerElementoPorId(Guid id)
             => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.ProductosVentas).ThenInclude(e => e.Producto).Include(e => e.Gestor));
        */
          protected override async Task<IEnumerable<DetallesVentaDto>> ObtenerTodosElementos(string? secuenciaOrdenamiento = null)
        => _mapper.Map<IEnumerable<DetallesVentaDto>>(await _servicioBase.ObtenerTodos(secuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(m => m.ProductosVendidos).ThenInclude(x => x.Producto).Include(x => x.ProductosVendidos).ThenInclude(x => x.Gestor)));
         

    }
}
