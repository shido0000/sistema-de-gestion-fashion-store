using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class ProductoVentaValidator : AbstractValidator<ProductoVenta>
    {
        private readonly IUnitOfWork<ProductoVenta> _repositorios;

        public ProductoVentaValidator(IUnitOfWork<ProductoVenta> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.PrecioGestor).NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Cantidad).NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.ProductoId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.VentaId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
        }

    }
}
