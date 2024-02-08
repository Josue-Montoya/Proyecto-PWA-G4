using FluentValidation;
using PelisPlusApp.Models;

namespace PelisPlusApp.Validations
{
    public class CategoriaValidations : AbstractValidator<CategoriasModel>
    {
        public CategoriaValidations()
        {
            RuleFor(categoria => categoria.Nombre_categoria)
                .NotNull().WithName("Nombre Categoria")
                .NotEmpty()
                .Matches(@"^[a-zA-Z]+$")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(categoria => categoria.Descripcion_categoria)
                .NotNull().WithName("Descripcion")
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(200);

            RuleFor(categoria => categoria.Restriccion_edad_categoria)
                .NotNull().WithName("Restriccion de edad")
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(5);

            RuleFor(categoria => categoria.Nota_categoria)
                .NotNull().WithName("Nota")
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(200);
        }
    }
}
