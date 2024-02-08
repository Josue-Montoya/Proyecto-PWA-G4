using PelisPlusApp.Data;
using Microsoft.AspNetCore.Mvc;
using PelisPlusApp.Models;
using FluentValidation;
using FluentValidation.Results;
using PelisPlusApp.Validations;

namespace PelisPlusApp.Controllers
{
    public class PeliculasController : Controller
    {
        private IValidator<PeliculasModel> _peliculasValidator;

        public PeliculasController(IValidator<PeliculasModel> peliculasValidator)
        {
            _peliculasValidator = peliculasValidator;
        }

        public IActionResult Index()
        {
            PeliculasData peliculasData = new PeliculasData();

            return View(peliculasData.GetAll());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PeliculasModel peliculasModel)
        {

            ValidationResult validationResult = _peliculasValidator.Validate(peliculasModel);

            try
            {
                PeliculasData peliculasData = new PeliculasData();
                peliculasData.Insertar(peliculasModel);

                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

                validationResult.AddTModelState(this.ModelState);
                return View(peliculasModel);
            }
        }

        [HttpGet]
        public IActionResult Editar( int Id)
        {
            PeliculasData peliculasData = new PeliculasData();
            var pelicula = peliculasData.GetAll().FirstOrDefault(pelicula => pelicula.Id_pelicula == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(PeliculasModel peliculasModel)
        {
            try
            {
                PeliculasData peliculasData = new PeliculasData();
                peliculasData.Editar(peliculasModel);

                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

                return View(peliculasModel);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int Id)
        {
            PeliculasData peliculasData = new PeliculasData();
            var pelicula = peliculasData.GetAll().FirstOrDefault(pelicula => pelicula.Id_pelicula == Id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        [HttpPost]
        public IActionResult Eliminar(PeliculasModel peliculasModel)
        {
            try
            {
                PeliculasData peliculasData = new PeliculasData();
                peliculasData.Eliminar(peliculasModel.Id_pelicula);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;

                return View(peliculasModel);
            }
        }
    }
}
