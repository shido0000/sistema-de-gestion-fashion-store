﻿using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Domain.Interfaces.Gestion.Nomencladores;
using API.Domain.Validators.Gestion.Nomencladores;
using Microsoft.AspNetCore.Http;


namespace API.Domain.Services.Gestion.Nomencladores
{
    public class ProductoVentaService : BasicService<ProductoVenta, ProductoVentaValidator>, IProductoVentaService
    {

        public ProductoVentaService(IUnitOfWork<ProductoVenta> repositorios, IHttpContextAccessor httpContext) : base(repositorios, httpContext)
        {
        }

        public async Task EliminarPorVenta(Guid ventaId)
        {
       /*     var productosVentas = await _repositorios.ProductosVentas.GetAllAsync(e => e.VentaId == ventaId);
            _repositorios.ProductosVentas.RemoveRange(productosVentas);*/
        }
    }
}