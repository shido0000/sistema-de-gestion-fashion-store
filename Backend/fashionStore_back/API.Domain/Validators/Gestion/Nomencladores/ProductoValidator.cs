using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class ProductoValidator : AbstractValidator<Producto>
    {
        private readonly IUnitOfWork<Producto> _repositorios;

        public ProductoValidator(IUnitOfWork<Producto> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                     .MaximumLength(100).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                     .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .MaximumLength(255).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Costo).NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.PrecioUSD).NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Cantidad).NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.EstadoProductoId).NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m).MustAsync(async (producto, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.Codigo == producto.Codigo && e.Id != producto.Id)))
            .WithMessage("Ya existe una Código con el mismo texto.");

            RuleFor(m => m).MustAsync(async (producto, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.Descripcion == producto.Descripcion && e.Id != producto.Id)))
               .WithMessage("Ya existe una Descripción con el mismo texto.");
        }

    }
}
