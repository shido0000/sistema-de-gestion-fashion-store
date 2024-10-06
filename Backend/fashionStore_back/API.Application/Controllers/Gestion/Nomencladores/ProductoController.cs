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
                filtros.Add(producto => producto.Codigo.Contains(inputDto.TextoBuscar) ||
                                        producto.Descripcion.Contains(inputDto.TextoBuscar) ||
                                        producto.EstadoProducto.Descripcion.Contains(inputDto.TextoBuscar) 
                    
                    );
            }

           // IIncludableQueryable<Producto, object> propiedadesIncluidas(IQueryable<Producto> query) => query.Include(e => e.EstadoProducto);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.EstadoProducto), filtros.ToArray());
        }

        protected override async Task<Producto?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.EstadoProducto));

        /*
        /// <summary>
        /// Obtener todos los elementos que tengan en stock
        /// </summary>
        /// <param name="secuenciaOrdenamiento">Secuencia de ordenamiento para ordenar el listado.
        /// FORMATO: Campo1:(asc/desc),Campo2:(asc/desc),...</param>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        [HttpGet("[action]")]
        public virtual async Task<IActionResult> ObtenerTodosEnStock()
        {
            try
            {
                IEnumerable<ProductoDto> result = _mapper.Map<IEnumerable<ProductoDto>>(await _ProductoService.ObtenerTodos(propiedadesIncluidas: query => query.AllAsync(e=>(e.CantidadStock !== 0)));

                return Ok(new ResponseDto { Status = StatusCodes.Status200OK, Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = ex.InnerException?.Message ?? ex.Message });
            }
        }*/
    }
}
