using API.Application.Dtos.Comunes;
using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class ProductoController : BasicController<Producto, ProductoValidator, DetallesProductoDto, CrearProductoInputDto, ActualizarProductoInputDto, ListadoPaginadoProductoDto, FiltrarConfigurarListadoPaginadoProductoIntputDto>
    {
        private readonly IProductoService _ProductoService;


        public ProductoController(IMapper mapper, IProductoService servicioProducto, IProductoService productoService) : base(mapper, servicioProducto)
        {
            _ProductoService = productoService;
        }

        protected override Task<(IEnumerable<Producto>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoProductoIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Producto, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(producto => producto.Descripcion.Contains(inputDto.TextoBuscar) ||
                                        producto.EstadoProducto.Descripcion.Contains(inputDto.TextoBuscar) 
                    
                    );
            }

           // IIncludableQueryable<Producto, object> propiedadesIncluidas(IQueryable<Producto> query) => query.Include(e => e.EstadoProducto);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.EstadoProducto), filtros.ToArray());
        }

        protected override async Task<Producto?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.EstadoProducto));


        /// <summary>
        /// Retorna un listado para un Select
        /// </summary>
        /// <param name="inputDto">Datos de entrada</param>
        /// <response code="200">Completado con exito! </response>
        /// <response code="400">Ha ocurrido un error </response>
        [HttpGet("[action]")]
        public virtual async Task<IActionResult> ObtenerSelectList([FromQuery] ObtenerSelectListInputDto inputDto)
        {
            inputDto.NombreCampoTexto = typeof(Permiso).GetProperties().FirstOrDefault(e => e.Name.ToLower() == inputDto.NombreCampoTexto.ToLower())?.Name ?? string.Empty;
            inputDto.NombreCampoValor = typeof(Permiso).GetProperties().FirstOrDefault(e => e.Name.ToLower() == inputDto.NombreCampoValor.ToLower())?.Name ?? string.Empty;

            if (string.IsNullOrWhiteSpace(inputDto.NombreCampoValor) || string.IsNullOrWhiteSpace(inputDto.NombreCampoTexto))
                throw new CustomException { Status = StatusCodes.Status400BadRequest, Message = "Error en los nombres de los campos." };

            IEnumerable<Producto> entities = await _ProductoService.ObtenerTodos(inputDto.SecuenciaOrdenamiento);

            SelectList selectList = new(entities, inputDto.NombreCampoValor, inputDto.NombreCampoTexto, inputDto.ValorSeleccionado);
            return Ok(new ResponseDto { Status = StatusCodes.Status200OK, Result = selectList });

        }
    }
}
