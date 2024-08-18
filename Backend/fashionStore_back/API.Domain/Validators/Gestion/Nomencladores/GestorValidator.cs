using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class GestorValidator : AbstractValidator<Gestor>
    {
        private readonly IUnitOfWork<Gestor> _repositorios;

        public GestorValidator(IUnitOfWork<Gestor> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.Nombre).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .MaximumLength(255).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Apellidos).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .MaximumLength(255).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Direccion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                              .MaximumLength(255).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                              .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Telefono).NotEmpty().WithMessage("No puede ser un texto vacio.")
                              .MaximumLength(8).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                              .NotNull().WithMessage("Es un campo obligatorio.");

          /*  RuleFor(m => m).MustAsync(async (conceptoSimple, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.Codigo == conceptoSimple.Codigo && e.Id != conceptoSimple.Id)))
                .OverridePropertyName(nameof(Gestor.Nombre,Gestor.Apellidos))
                .WithMessage("Ya existe un Codigo de Concepto Simple con el mismo texto.");
          */
 
        }

    }
}
