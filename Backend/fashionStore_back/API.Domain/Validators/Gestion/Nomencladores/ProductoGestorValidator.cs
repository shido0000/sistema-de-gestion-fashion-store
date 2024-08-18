using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class ProductoGestorValidator : AbstractValidator<ProductoGestor>
    {
        private readonly IUnitOfWork<ProductoGestor> _repositorios;

        public ProductoGestorValidator(IUnitOfWork<ProductoGestor> repositorios)
        {
            _repositorios = repositorios;

          /*  RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                .MaximumLength(255).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                .NotNull().WithMessage("Es un campo obligatorio.");
           */
            
            RuleFor(m => m.ProductoId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.GestorId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
        }

    }
}
