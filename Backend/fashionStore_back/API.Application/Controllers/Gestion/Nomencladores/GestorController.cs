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
       
        public GestorController(IMapper mapper, IGestorService servicioGestor, IGestorService gestorService) : base(mapper, servicioGestor)
        {
            _GestorService = gestorService;
         
        }


        protected override Task<(IEnumerable<Gestor>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoGestorIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Gestor, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
                filtros.Add(gestor => gestor.Nombre.Contains(inputDto.TextoBuscar));

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, null, filtros.ToArray());
        }
 
    }
}
