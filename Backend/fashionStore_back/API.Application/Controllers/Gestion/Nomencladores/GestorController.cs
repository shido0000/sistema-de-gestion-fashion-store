using API.Application.Dtos.Comunes;
using API.Application.Dtos.Gestion.Nomencladores.Gestor;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class GestorController : BasicController<Gestor, GestorValidator, DetallesGestorDto, CrearGestorInputDto, ActualizarGestorInputDto, ListadoPaginadoGestorDto, FiltrarConfigurarListadoPaginadoGestorIntputDto>
    {
        private readonly IGestorService _GestorService;
        private readonly IProductoGestorService _productoGestorService;
        private readonly IVentaGestorService _ventaGestorService;

        public GestorController(IMapper mapper, IGestorService servicioGestor, IGestorService gestorService, IProductoGestorService productoGestorService, IVentaGestorService ventaGestorService) : base(mapper, servicioGestor)
        {
            _GestorService = gestorService;
            _productoGestorService = productoGestorService;
            _ventaGestorService = ventaGestorService;
        }

        /// <summary>
        /// Retorna un listado para un Select
        /// </summary>
        /// <param name="inputDto">Datos de entrada</param>
        /// <response code="200">Completado con exito! </response>
        /// <response code="400">Ha ocurrido un error </response>
        [HttpGet("[action]")]
        public new async Task<IActionResult> ObtenerSelectList([FromQuery] ObtenerSelectListInputDto inputDto)
            => await base.ObtenerSelectList(inputDto);


        /// <summary>
        /// Editar un elemento
        /// </summary>
        /// <param name="id">Id del elemento</param>
        /// <param name="actualizarDto">Elemento a editar</param>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        /// <response code="404">Elemento no encontrado</response>
        [HttpPut("[action]/{id}")]
        public override async Task<IActionResult> Actualizar(Guid id, ActualizarGestorInputDto actualizarDto)
        {
            await _productoGestorService.EliminarPorGestor(id);
            return await base.Actualizar(id, actualizarDto);
        }

        protected override Task<(IEnumerable<Gestor>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoGestorIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Gestor, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
                filtros.Add(gestor => gestor.Nombre.Contains(inputDto.TextoBuscar));

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, null, filtros.ToArray());
        }

        protected override async Task<Gestor?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.ProductosGestores).ThenInclude(e => e.Producto).Include(e => e.VentasGestores).ThenInclude(e => e.Venta));

        protected override async Task<IEnumerable<DetallesGestorDto>> ObtenerTodosElementos(string? secuenciaOrdenamiento = null)
            => _mapper.Map<IEnumerable<DetallesGestorDto>>(await _servicioBase.ObtenerTodos(secuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.ProductosGestores).ThenInclude(e => e.Producto).Include(e=>e.VentasGestores).ThenInclude(e=>e.Venta)));

    }
}
