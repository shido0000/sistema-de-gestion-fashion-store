﻿using API.Data.Entidades.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;

namespace API.Domain.Interfaces.Gestion.Nomencladores
{
    public interface IEstadoProductoService : IBaseService<EstadoProducto, EstadoProductoValidator>
    {
        Task<Guid> ObtenerIdPorDescripcion(string descripcion);
    }
}