﻿using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class VentaValidator : AbstractValidator<Venta>
    {
        private readonly IUnitOfWork<Venta> _repositorios;

        public VentaValidator(IUnitOfWork<Venta> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.Fecha).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
           
            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .MaximumLength(100).WithMessage("Solo se admiten 100 carácteres.")
                                  .NotNull().WithMessage("Es un campo obligatorio.");

           
    }

    }
}
