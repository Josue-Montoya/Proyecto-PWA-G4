using FluentValidation;
using PelisPlusApp.Models;

namespace PelisPlusApp.Validations
{
    public class PeliculasValidaciones : AbstractValidator<PeliculasModel>
    {
        public PeliculasValidaciones()
        {
            RuleFor(pelicula => pelicula.Titulo).NotNull().MaximumLength(20);

            RuleFor(pelicula => pelicula.Categoria).NotNull().MaximumLength(20);

            RuleFor(pelicula => pelicula.Sinopsis).MaximumLength(100);

            RuleFor(pelicula => pelicula.Duracion).MaximumLength(12).NotNull();

            RuleFor(pelicula => pelicula.Director).MaximumLength(20).NotNull();

            RuleFor(pelicula => pelicula.Fecha_estreno).MaximumLength(20).NotNull();
        }

    }
}
