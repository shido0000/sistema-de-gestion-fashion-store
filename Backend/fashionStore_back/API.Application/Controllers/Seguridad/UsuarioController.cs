using API.Application.Dtos.Comunes;
using API.Application.Dtos.Seguridad.Usuario;
using API.Application.Validadotors.Seguridad;
using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Domain.Exceptions;
using API.Domain.Interfaces.Seguridad;
using API.Domain.Validators.Seguridad;
using AutoMapper;
using FastReport.Data.JsonConnection;
using FastReport.Export.Pdf;
using FastReport.Utils;
using FastReport.Web;
using FluentValidation;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Web.Helpers;
using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace API.Application.Controllers.Seguridad
{
    public class UsuarioController : BasicController<Usuario, UsuarioValidator, DetallesUsuarioDto, CrearUsuarioInputDto, ActualizarUsuarioInputDto, ListadoPaginadoUsuarioDto, FiltrarConfigurarListadoPaginadoUsuarioIntputDto>
    {
        private readonly IUsuarioService _UsuarioService;
        private readonly IUsuarioService _UsuarioService2;

        private readonly IRolService _rolService;

        private readonly IWebHostingEnvironment _webHostingEnvironment;
        public static readonly ILog _log = LogManager.GetLogger(typeof(Gestor));


        public UsuarioController(IWebHostingEnvironment webHostingEnvironment, IMapper mapper, IUsuarioService usuarioService, IUsuarioService servicioUsuario, IRolService rolService) : base(mapper, servicioUsuario)
        {
            _UsuarioService = usuarioService;
            _UsuarioService2 = servicioUsuario;
            _webHostingEnvironment = webHostingEnvironment;
            _rolService = rolService;
        }

        /// <summary>
        /// Cambiar contraseña de un usuario
        /// </summary>
        /// <param name="cambiarContrasennaDto">Elemento a editar</param>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        /// <response code="404">Elemento no encontrado</response>
        [HttpPost("[action]")]
        public async Task<IActionResult> CambiarContrasenna(CambiarContrasennaInputDto cambiarContrasennaDto)
        {
            await new CambiarContrasennaDtoValidator().ValidateAndThrowAsync(cambiarContrasennaDto);

            //si no se inserta la contraseña antigua es porque el endpoint lo esta llamando un administrador de usuarios
            if (string.IsNullOrWhiteSpace(cambiarContrasennaDto.ContrasennaAntigua))
            {
                _servicioBase.ValidarPermisos("gestionar");
                await ((IUsuarioService)_servicioBase).CambiarContrasenna(cambiarContrasennaDto.UsuarioId, cambiarContrasennaDto.NuevaContrasenna, true);
            }
            else
            {
                Usuario? usuario = await _servicioBase.ObtenerPorId(cambiarContrasennaDto.UsuarioId) ?? throw new CustomException { Status = StatusCodes.Status404NotFound, Message = "Elemento no encontrado." };

                if (User.Identity?.Name == usuario.Username)
                    throw new CustomException { Status = StatusCodes.Status401Unauthorized, Message = "El usuario no tiene permisos para realizar esta acción." };

                if (!Crypto.VerifyHashedPassword(usuario.Contrasenna, cambiarContrasennaDto.ContrasennaAntigua))
                    throw new CustomException { Status = StatusCodes.Status500InternalServerError, Message = "La contraseña antigua es incorrecta." };

                await ((IUsuarioService)_servicioBase).CambiarContrasenna(cambiarContrasennaDto.UsuarioId, cambiarContrasennaDto.NuevaContrasenna);
            }

            await _servicioBase.GuardarTraza(usuario, $"Se ha camibado la contraseña para del usuario con id = {cambiarContrasennaDto.UsuarioId}", typeof(Usuario).Name);
            await _servicioBase.SalvarCambios();

            return Ok(new ResponseDto { Status = StatusCodes.Status200OK });
        }

        /*   protected override Task<(IEnumerable<Usuario>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoUsuarioIntputDto inputDto)
           {
               //agregando filtros
               List<Expression<Func<Usuario, bool>>> filtros = new();
               if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
               {
                   filtros.Add(usuario => usuario.Nombre.Contains(inputDto.TextoBuscar) ||
                                          usuario.Apellidos.Contains(inputDto.TextoBuscar) ||

                                          usuario.Username.Contains(inputDto.TextoBuscar));
               }

               //IIncludableQueryable<Usuario, object> propiedadesIncluidas(IQueryable<Usuario> query) => query.Include(e => e.ShipmentItems);
             //  IIncludableQueryable<Usuario, object> propiedadesIncluidas(IQueryable<Usuario> query) => query.Include(e => e.Rol);
               return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.Rol), filtros.ToArray());
           }*/

        protected override Task<(IEnumerable<Usuario>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoUsuarioIntputDto inputDto)
        {
            // Agregando filtros
            List<Expression<Func<Usuario, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(usuario => usuario.Nombre.Contains(inputDto.TextoBuscar) ||
                                       usuario.Apellidos.Contains(inputDto.TextoBuscar) ||
                                       usuario.Username.Contains(inputDto.TextoBuscar)

                                       || usuario.Rol.Nombre.Contains(inputDto.TextoBuscar)
                                       );
            }

            // Incluyendo la propiedad Rol en la consulta
            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.Rol), filtros.ToArray());
        }


        protected override async Task<Usuario?> ObtenerElementoPorId(Guid id)
            => await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Rol));

        protected override async Task<IEnumerable<DetallesUsuarioDto>> ObtenerTodosElementos(string? secuenciaOrdenamiento = null)
            => _mapper.Map<IEnumerable<DetallesUsuarioDto>>(await _servicioBase.ObtenerTodos(secuenciaOrdenamiento, propiedadesIncluidas: query => query.Include(e => e.Rol)));



        /// <summary>
        /// Obtener un elemento por el nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario del elemento</param>
        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        /// <response code="404">Elemento no encontrado</response>
        [HttpGet("[action]/{nombreUsuario}")]
        public async Task<Usuario?> ObtenerElementoPorUsuario(string nombreUsuario)
        {
            return await _UsuarioService2.ObtenerPorUsername(nombreUsuario, propiedadesIncluidas: query => query.Include(e => e.Rol));
        }
        //public async Task<Usuario?> ObtenerElementoPorUsuario(string nombreUsuario) {
        //    return await _UsuarioService2.ObtenerElementoPorUsuario(nombreUsuario);
        //}

        /// <summary>
        /// Imprimir Usuarios con filtro
        /// </summary>
        [HttpGet("[action]")]
        public async Task<IActionResult> ImprimirPorFiltro(string? texto)
        {
            var name = typeof(UsuarioDto).Name.Replace("Dto", "");
            try
            {
                IEnumerable<UsuarioDto> result = _mapper.Map<IEnumerable<UsuarioDto>>(await _servicioBase.ObtenerTodos());
                var resultList = result.ToList(); // Convertir a lista una sola vez
                List<UsuarioDto> resultFinal = new List<UsuarioDto>();
                var resultList2 = new List<UsuarioImprimirDto>();

                if (result.Count() == 0)
                {
                    _log.ErrorFormat($"No existen elementos de tipo {name} definidos");
                    return BadRequest(new ResponseDto { Status = StatusCodes.Status400BadRequest, ErrorMessage = $"No existen elementos de tipo {name} definidos" });
                }

                if (texto != null)
                {
                    string textoLower = texto.ToLower();
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        if (resultList[i].Nombre.ToLower().Contains(textoLower) || resultList[i].Apellidos.ToLower().Contains(textoLower) || resultList[i].Username.ToLower().Contains(textoLower))
                        {
                            Rol? rol = await _rolService.ObtenerPorId(resultList[i].RolId);
                            var objetActual = resultList[i];
                            UsuarioImprimirDto objetActualImprimir = new()
                            {
                                Id = objetActual.Id,
                                Nombre = objetActual.Nombre,
                                Apellidos = objetActual.Apellidos,
                                NombreCompletoDescripcion = objetActual.NombreCompleto,
                                Username = objetActual.Username,
                                RolId = objetActual.RolId,
                                RolDescripcion = "-",
                            };
                            if (rol != null)
                            {
                                objetActualImprimir.RolDescripcion = rol.Nombre;
                                resultList2.Add(objetActualImprimir);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        Rol? rol = await _rolService.ObtenerPorId(resultList[i].RolId);
                        var objetActual = resultList[i];
                        UsuarioImprimirDto objetActualImprimir = new()
                        {
                            Id = objetActual.Id,
                            Nombre = objetActual.Nombre,
                            Apellidos = objetActual.Apellidos,
                            NombreCompletoDescripcion = objetActual.NombreCompleto,
                            Username = objetActual.Username,
                            RolId = objetActual.RolId,
                            RolDescripcion = "-",
                        };
                        if (rol != null)
                        {
                            objetActualImprimir.RolDescripcion = rol.Nombre;
                            resultList2.Add(objetActualImprimir);
                        }
                    }
                }

                resultFinal = resultFinal
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


        /// <summary>
        /// Verificar si un usuario es Administrador
        /// </summary>

        /// <response code="200">Completado con exito!</response>
        /// <response code="400">Ha ocurrido un error</response>
        /// <response code="404">Elemento no encontrado</response>
        [HttpGet("[action]")]
        public async Task<bool> EsAdministrador(Guid usuarioId)
        {
            return await _UsuarioService.EsAdministrador(usuarioId);
        }

    }

}
