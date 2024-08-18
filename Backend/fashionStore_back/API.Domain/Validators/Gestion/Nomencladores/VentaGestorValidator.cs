using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using API.Data.IUnitOfWorks.Interfaces.Gestion.Nomencladores;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class VentaGestorValidator : AbstractValidator<VentaGestor>
    {
        private readonly IUnitOfWork<VentaGestor> _repositorios;

        public VentaGestorValidator(IUnitOfWork<VentaGestor> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.VentaId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.GestorId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                 .NotNull().WithMessage("Es un campo obligatorio.");
        }

    }
}
