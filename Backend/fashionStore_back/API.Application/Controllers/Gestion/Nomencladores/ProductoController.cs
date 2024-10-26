using API.Application.Dtos.Comunes;
using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using AutoMapper;
using FastReport.Data.JsonConnection;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport.Web;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class ProductoController : BasicController<Producto, ProductoValidator, DetallesProductoDto, CrearProductoInputDto, ActualizarProductoInputDto, ListadoPaginadoProductoDto, FiltrarConfigurarListadoPaginadoProductoIntputDto>
    {
        private readonly IProductoService _ProductoService;
        private readonly IWebHostingEnvironment _webHostingEnvironment;
        public static readonly ILog _log = LogManager.GetLogger(typeof(Producto));

        private readonly IEstadoProductoService _EstadoProductoService;

        public ProductoController(IWebHostingEnvironment webHostingEnvironment, IMapper mapper, IProductoService servicioProducto, IProductoService productoService, IEstadoProductoService estadoProductoService) : base(mapper, servicioProducto)
        {
            _ProductoService = productoService;
            _EstadoProductoService = estadoProductoService;
            _webHostingEnvironment = webHostingEnvironment;
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


        /// <summary>
        /// Obtener la cantidad de ventas de un producto
        /// </summary>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        [HttpGet("[action]")]
        public async Task<int> CantidadProductoVendido(Guid productoId)
        {
            return await _ProductoService.CantidadProductoVendido(productoId);
        }


        /// <summary>
        /// Imprimir  Producto con filtro
        /// </summary>
        [HttpGet("[action]")]
        public async Task<IActionResult> ImprimirPorFiltro(string? texto, bool esDisponible)
        {
            var name = typeof(ProductoDto).Name.Replace("Dto", "");
            try
            {
                //IEnumerable<CLProvinciaDto> result = _mapper.Map<CLProvinciaDto>>(await _servicioBase.ObtenerTodos());
                IEnumerable<ProductoDto> result = _mapper.Map<IEnumerable<ProductoDto>>(await _servicioBase.ObtenerTodos());
                var resultList = result.ToList(); // Convertir a lista una sola vez
                List<ProductoDto> resultFinal = new List<ProductoDto>();
                var resultList2 = new List<ProductoImprimirDto>();
                if (result.Count() == 0)
                {
                    _log.ErrorFormat($"No existen elementos de tipo {name} definidos");
                    return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = $"No existen elementos de tipo {name} definidos" });
                }

                if (texto != null)
                {
                    for (int i = 0; i < resultList.Count; i++)
                    {

                        if (resultList[i].Codigo.Contains(texto) || resultList[i].Descripcion.Contains(texto))
                        {
                            if (esDisponible)
                            {
                                EstadoProducto? estadoProducto = await _EstadoProductoService.ObtenerPorId(resultList[i].EstadoProductoId);
                                var objetActual = resultList[i];

                                ProductoImprimirDto objetActualImprimir = new()
                                {
                                    Id = objetActual.Id,
                                    Codigo = objetActual.Codigo,
                                    Descripcion = objetActual.Descripcion,
                                    Costo = objetActual.Costo,
                                    PrecioUSD = objetActual.PrecioUSD,
                                    Cantidad = objetActual.Cantidad,
                                    CantidadStock = objetActual.CantidadStock,
                                    EstadoProductoId = objetActual.EstadoProductoId,

                                    EstadoProductoDescripcion = "-",
                                };

                                if (estadoProducto != null)
                                {
                                    objetActualImprimir.EstadoProductoDescripcion = estadoProducto.Descripcion;
                                    if (estadoProducto.Descripcion == "Disponible")
                                    {
                                        resultList2.Add(objetActualImprimir);
                                    }
                                }

                            }
                            else
                            {
                                EstadoProducto? estadoProducto = await _EstadoProductoService.ObtenerPorId(resultList[i].EstadoProductoId);
                                var objetActual = resultList[i];

                                ProductoImprimirDto objetActualImprimir = new()
                                {
                                    Id = objetActual.Id,
                                    Codigo = objetActual.Codigo,
                                    Descripcion = objetActual.Descripcion,
                                    Costo = objetActual.Costo,
                                    PrecioUSD = objetActual.PrecioUSD,
                                    Cantidad = objetActual.Cantidad,
                                    CantidadStock = objetActual.CantidadStock,
                                    EstadoProductoId = objetActual.EstadoProductoId,

                                    EstadoProductoDescripcion = "-",
                                };

                                if (estadoProducto != null)
                                {
                                    objetActualImprimir.EstadoProductoDescripcion = estadoProducto.Descripcion;

                                    resultList2.Add(objetActualImprimir);

                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        if (esDisponible)
                        {
                            EstadoProducto? estadoProducto = await _EstadoProductoService.ObtenerPorId(resultList[i].EstadoProductoId);
                            var objetActual = resultList[i];

                            ProductoImprimirDto objetActualImprimir = new()
                            {
                                Id = objetActual.Id,
                                Codigo = objetActual.Codigo,
                                Descripcion = objetActual.Descripcion,
                                Costo = objetActual.Costo,
                                PrecioUSD = objetActual.PrecioUSD,
                                Cantidad = objetActual.Cantidad,
                                CantidadStock = objetActual.CantidadStock,
                                EstadoProductoId = objetActual.EstadoProductoId,

                                EstadoProductoDescripcion = "-",
                            };

                            if (estadoProducto != null)
                            {
                                objetActualImprimir.EstadoProductoDescripcion = estadoProducto.Descripcion;
                                if (estadoProducto.Descripcion == "Disponible")
                                {
                                    resultList2.Add(objetActualImprimir);
                                }
                            }

                        }
                        else
                        {
                            EstadoProducto? estadoProducto = await _EstadoProductoService.ObtenerPorId(resultList[i].EstadoProductoId);
                            var objetActual = resultList[i];

                            ProductoImprimirDto objetActualImprimir = new()
                            {
                                Id = objetActual.Id,
                                Codigo = objetActual.Codigo,
                                Descripcion = objetActual.Descripcion,
                                Costo = objetActual.Costo,
                                PrecioUSD = objetActual.PrecioUSD,
                                Cantidad = objetActual.Cantidad,
                                CantidadStock = objetActual.CantidadStock,
                                EstadoProductoId = objetActual.EstadoProductoId,

                                EstadoProductoDescripcion = "-",
                            };

                            if (estadoProducto != null)
                            {
                                objetActualImprimir.EstadoProductoDescripcion = estadoProducto.Descripcion;

                                resultList2.Add(objetActualImprimir);

                            }
                        }

                    }
                }
                // Ordenar la lista: Disponible primero, luego Descripcion ascendente
                /*resultFinal = resultFinal
                    .OrderByDescending(async p => {
                        var estadoProducto = await _EstadoProductoService.ObtenerPorId(p.EstadoProductoId);
                        return estadoProducto?.Descripcion == "Disponible" ? 1 : 0;
                    })
                    .ThenBy(p => p.Descripcion)
                    .ToList();*/

                resultList2 = resultList2
                    .OrderBy(p => p.Descripcion)

                    .ToList();

                RegisteredObjects.AddConnection(typeof(JsonDataSourceConnection));
                WebReport webReport = new();
                webReport.Report.Load(@$"{_webHostingEnvironment.ContentRootPath}\Reportes\Nomencladores\Reporte{name}.frx");
                string json = JsonConvert.SerializeObject(resultList2, Formatting.None,
                         new JsonSerializerSettings()
                         {
                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                         });
                webReport.Report.Dictionary.Connections[0].ConnectionString = $@"Json={json}";
                webReport.Report.Prepare();
                Stream stream = new MemoryStream();
                webReport.Report.Export(new PDFExport(), stream);
                stream.Position = 0;
                return File(stream, "application/pdf", $"Reporte{name}.pdf");
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error imprimiendo los elementos de tipo " + name + ": {0}", ex.InnerException?.Message ?? ex.Message);
                return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
