using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class ConversionPrecioValidator : AbstractValidator<ConversionPrecio>
    {
        private readonly IUnitOfWork<ConversionPrecio> _repositorios;

        public ConversionPrecioValidator(IUnitOfWork<ConversionPrecio> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .MaximumLength(100).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.valorCambio).NotNull().WithMessage("Es un campo obligatorio.");


            RuleFor(m => m).MustAsync(async (conversionPrecio, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.Descripcion == conversionPrecio.Descripcion && e.Id != conversionPrecio.Id)))
               .WithMessage("Ya existe una Descripción con el mismo texto.");
        }

    }
}
