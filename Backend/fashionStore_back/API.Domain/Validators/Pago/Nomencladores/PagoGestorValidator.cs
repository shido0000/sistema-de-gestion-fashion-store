using API.Data.Entidades.Pago.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Pago.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class PagoGestorValidator : AbstractValidator<PagoGestor>
    {
        private readonly IUnitOfWork<PagoGestor> _repositorios;

        public PagoGestorValidator(IUnitOfWork<PagoGestor> repositorios)
        {
            _repositorios = repositorios;

            RuleFor(m => m.PagoTotal).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                     .NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.Pagado).NotNull().WithMessage("Es un campo obligatorio.");
            RuleFor(m => m.VentaId).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                    .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m).MustAsync(async (pagoGestor, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.VentaId == pagoGestor.VentaId && e.Id != pagoGestor.Id)))
               .WithMessage("Ya existe una venta con el mismo id.");
        }

    }
}
