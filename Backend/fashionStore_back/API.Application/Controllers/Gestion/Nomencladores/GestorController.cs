using API.Application.Dtos.Comunes;
using API.Application.Dtos.Gestion.Nomencladores.Gestor;
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
using Newtonsoft.Json;
using System.Linq.Expressions;
using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;


namespace API.Application.Controllers.Gestion.Nomencladores
{

    public class GestorController : BasicController<Gestor, GestorValidator, DetallesGestorDto, CrearGestorInputDto, ActualizarGestorInputDto, ListadoPaginadoGestorDto, FiltrarConfigurarListadoPaginadoGestorIntputDto>
    {
        private readonly IGestorService _GestorService;
        private readonly IWebHostingEnvironment _webHostingEnvironment;
        public static readonly ILog _log = LogManager.GetLogger(typeof(Gestor));


        public GestorController(IWebHostingEnvironment webHostingEnvironment, IMapper mapper, IGestorService servicioGestor, IGestorService gestorService) : base(mapper, servicioGestor)
        {
            _GestorService = gestorService;
            _webHostingEnvironment = webHostingEnvironment;
        }


        protected override Task<(IEnumerable<Gestor>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoGestorIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Gestor, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
                filtros.Add(gestor => gestor.Nombre.Contains(inputDto.TextoBuscar) || gestor.Apellidos.Contains(inputDto.TextoBuscar));

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, null, filtros.ToArray());
        }

        /// <summary>
        /// Imprimir  Gestores con filtro
        /// </summary>
        [HttpGet("[action]")]
        public async Task<IActionResult> ImprimirPorFiltro(string? texto)
        {
            var name = typeof(GestorDto).Name.Replace("Dto", "");
            try
            {
                //IEnumerable<CLProvinciaDto> result = _mapper.Map<CLProvinciaDto>>(await _servicioBase.ObtenerTodos());
                IEnumerable<GestorDto> result = _mapper.Map<IEnumerable<GestorDto>>(await _servicioBase.ObtenerTodos());
                var resultList = result.ToList(); // Convertir a lista una sola vez
                List<GestorDto> resultFinal = new List<GestorDto>();
                var resultList2 = new List<GestorImprimirDto>();
                if (result.Count() == 0)
                {
                    _log.ErrorFormat($"No existen elementos de tipo {name} definidos");
                    return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = $"No existen elementos de tipo {name} definidos" });
                }

                if (texto != null)
                {
                    for (int i = 0; i < resultList.Count; i++)
                    {

                        if (resultList[i].Nombre.Contains(texto) || resultList[i].Apellidos.Contains(texto))
                        {
                            var objetActual = resultList[i];

                            GestorImprimirDto objetActualImprimir = new()
                            {
                                Id = objetActual.Id,
                                Nombre = objetActual.Nombre,
                                Apellidos = objetActual.Apellidos,
                                Direccion = objetActual.Direccion,
                                Telefono = objetActual.Telefono,
                                NombreCompleto = objetActual.Nombre + " " + objetActual.Apellidos,
                            };
                            resultList2.Add(objetActualImprimir);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        var objetActual = resultList[i];

                        GestorImprimirDto objetActualImprimir = new()
                        {
                            Id = objetActual.Id,
                            Nombre = objetActual.Nombre,
                            Apellidos = objetActual.Apellidos,
                            Direccion = objetActual.Direccion,
                            Telefono = objetActual.Telefono,
                            NombreCompleto = objetActual.Nombre + " " + objetActual.Apellidos,
                        };
                        resultList2.Add(objetActualImprimir);

                    }
                }
                // Ordenar la lista: PorDefecto (desc), Activo (desc), Descripcion (asc)
                resultList2 = resultList2
                    .OrderBy(x => x.NombreCompleto)
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
