﻿using API.Application.Dtos.Gestion.Nomencladores.Gestor;
using API.Application.Dtos.Gestion.Nomencladores.Producto;
using API.Application.Dtos.Gestion.Nomencladores.Venta;
using API.Application.Dtos.Seguridad.Permiso;

namespace API.Application.Dtos.Gestion.Nomencladores.Gestor
{
    public class DetallesGestorDto : GestorDto
    {
        public List<ProductoDto> Productos { get; set; } = new();
        public List<VentaDto> Ventas { get; set; } = new();
    }
}