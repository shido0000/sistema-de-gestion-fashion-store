using API.Application.Dtos.Comunes;
using API.Application.Dtos.Pago.Nomencladores.PagoGestor;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Pago.Nomencladores;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Interfaces.Pago.Nomencladores;
using API.Domain.Validators.Pago.Nomencladores;
using AutoMapper;
using FastReport.Data.JsonConnection;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport.Web;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System.Linq.Expressions;
using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace API.Application.Controllers.Pago.Nomencladores
{

    public class PagoGestorController : BasicController<PagoGestor, PagoGestorValidator, DetallesPagoGestorDto, CrearPagoGestorInputDto, ActualizarPagoGestorInputDto, ListadoPaginadoPagoGestorDto, FiltrarConfigurarListadoPaginadoPagoGestorIntputDto>
    {
        private readonly IPagoGestorService _PagoGestorService;
        private readonly IVentaService _VentaService;

        private readonly IWebHostingEnvironment _webHostingEnvironment;
        public static readonly ILog _log = LogManager.GetLogger(typeof(PagoGestor));


        public PagoGestorController(IWebHostingEnvironment webHostingEnvironment, IMapper mapper, IPagoGestorService servicioPagoGestor, IPagoGestorService pagoGestorService, IVentaService ventaService) : base(mapper, servicioPagoGestor)
        {
            _PagoGestorService = pagoGestorService;
            _VentaService = ventaService;
            _webHostingEnvironment = webHostingEnvironment;
        }

        protected override Task<(IEnumerable<PagoGestor>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoPagoGestorIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<PagoGestor, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(pagoGestor => pagoGestor.Venta.Codigo.Contains(inputDto.TextoBuscar) ||
                                          pagoGestor.Pagado.ToString().Contains(inputDto.TextoBuscar)

                    );
            }

            IIncludableQueryable<PagoGestor, object> propiedadesIncluidas(IQueryable<PagoGestor> query) => query.Include(e => e.Venta);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas, filtros.ToArray());
        }

        protected override async Task<PagoGestor?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Venta));


        /// <summary>
        /// Imprimir  ganancia de los gestores con filtro
        /// </summary>
        [HttpGet("[action]")]
        public async Task<IActionResult> ImprimirPorFiltro(bool esPagado)
        {
            var name = typeof(PagoGestorDto).Name.Replace("Dto", "");
            try
            {
                //IEnumerable<CLProvinciaDto> result = _mapper.Map<CLProvinciaDto>>(await _servicioBase.ObtenerTodos());
                IEnumerable<PagoGestorDto> result = _mapper.Map<IEnumerable<PagoGestorDto>>(await _servicioBase.ObtenerTodos());
                var resultList = result.ToList(); // Convertir a lista una sola vez
                List<PagoGestorDto> resultFinal = new List<PagoGestorDto>();
                var resultList2 = new List<PagoGestorImprimirDto>();
                if (result.Count() == 0)
                {
                    _log.ErrorFormat($"No existen elementos de tipo {name} definidos");
                    return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = $"No existen elementos de tipo {name} definidos" });
                }

                for (int i = 0; i < resultList.Count; i++)
                {

                    if (esPagado)
                    {
                        Venta? venta = await _VentaService.ObtenerPorId(resultList[i].VentaId, propiedadesIncluidas: query => query.Include(e => e.ProductosVendidos));
                        var objetActual = resultList[i];
                        if (objetActual.Pagado)
                        {
                            PagoGestorImprimirDto objetActualImprimir = new()
                            {
                                Id = objetActual.Id,
                                Pagado = objetActual.Pagado,
                                PagoTotal = objetActual.PagoTotal,
                                VentaId = objetActual.VentaId,

                                VentaDescripcion = "-",
                                VentaFecha = new DateTime(),
                                GestorNombreCompleto = "-",
                            };

                            if (venta != null)
                            {
                                objetActualImprimir.VentaDescripcion = venta.Codigo;
                                objetActualImprimir.VentaFecha = venta.Fecha;
                                objetActualImprimir.GestorNombreCompleto = await _PagoGestorService.ObtenerNombreCompletoGestorPorVentaDada(venta.Id);


                                resultList2.Add(objetActualImprimir);

                            }
                        }

                    }
                    else
                    {
                        Venta? venta = await _VentaService.ObtenerPorId(resultList[i].VentaId, propiedadesIncluidas: query => query.Include(e => e.ProductosVendidos));
                        var objetActual = resultList[i];

                        PagoGestorImprimirDto objetActualImprimir = new()
                        {
                            Id = objetActual.Id,
                            Pagado = objetActual.Pagado,
                            PagoTotal = objetActual.PagoTotal,
                            VentaId = objetActual.VentaId,

                            VentaDescripcion = "-",
                            VentaFecha = new DateTime(),
                            GestorNombreCompleto = "-",
                        };

                        if (venta != null)
                        {
                            objetActualImprimir.VentaDescripcion = venta.Codigo;
                            objetActualImprimir.VentaFecha = venta.Fecha;
                            objetActualImprimir.GestorNombreCompleto = await _PagoGestorService.ObtenerNombreCompletoGestorPorVentaDada(venta.Id);

                            resultList2.Add(objetActualImprimir);

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
                    .OrderByDescending(p => p.Pagado)
                    .ThenByDescending(p => p.VentaFecha)

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
