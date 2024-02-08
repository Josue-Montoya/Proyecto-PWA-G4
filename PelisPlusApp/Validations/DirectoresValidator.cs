using FluentValidation;
using PelisPlusApp.Models;

namespace PelisPlusApp.Validations
{
    public class DirectoresValidator : AbstractValidator<DirectoresModel>
    {
        public DirectoresValidator()
        {
            /*Reglas de validacion para el Nombre*/
            RuleFor(directores => directores.Nombre)
                .NotNull().WithMessage("El nombre no debe estar vacio")
                .NotEmpty()
                .MinimumLength(3).WithMessage("Debe ingresar minimo 3 letras")
                .MaximumLength(75);

            RuleFor(directores => directores.Apellido)
                .NotNull().WithName("Apellido");
        }
    }
}
