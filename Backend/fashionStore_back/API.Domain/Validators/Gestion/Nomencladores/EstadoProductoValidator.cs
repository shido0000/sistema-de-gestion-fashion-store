using API.Data.Entidades.Gestion.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Gestion.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class EstadoProductoValidator : AbstractValidator<EstadoProducto>
    {
        private readonly IUnitOfWork<EstadoProducto> _repositorios;

        public EstadoProductoValidator(IUnitOfWork<EstadoProducto> repositorios)
        {
            _repositorios = repositorios;


            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                            .MaximumLength(100).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                            .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m).MustAsync(async (estadoProducto, cancelacion) => !(await _repositorios.BasicRepository.AnyAsync(e => e.Descripcion == estadoProducto.Descripcion && e.Id != estadoProducto.Id)))
              .WithMessage("Ya existe una Descripción con el mismo texto.");
        }

    }
}
