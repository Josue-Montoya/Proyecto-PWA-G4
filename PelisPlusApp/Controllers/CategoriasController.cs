using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PelisPlusApp.Data;
using PelisPlusApp.Models;
using PelisPlusApp.Validations;

namespace PelisPlusApp.Controllers
{
    public class CategoriasController : Controller
    {
        private IValidator<CategoriasModel> _categoriaValidator;

        public CategoriasController(IValidator<CategoriasModel> categoriaValidator)
        {
            _categoriaValidator = categoriaValidator;
        }

        public IActionResult IndexCategorias()
        {
            CategoriasData categoriasData = new CategoriasData();
            return View(categoriasData.GetAllsCategorias());
        }

        [HttpGet]
        public IActionResult CrearCategoria()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCategoria(CategoriasModel categoriasModel)
        {
            ValidationResult validationResult = _categoriaValidator.Validate(categoriasModel);

            try
            {
                CategoriasData categoriasData = new CategoriasData();
                categoriasData.Añadir_Categorias(categoriasModel);
                return RedirectToAction(nameof(IndexCategorias));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                validationResult.AddTModelState(this.ModelState);

                return View(categoriasModel);
            }
        }

        [HttpGet]
        public IActionResult EditarCategoria(int id)
        {
            CategoriasData categoriasData = new CategoriasData();
            var categoria = categoriasData.GetAllsCategorias().FirstOrDefault(categoria => categoria.Id_categoria == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarCategoria(CategoriasModel categoriasModel)
        {
            try
            {
                CategoriasData categoriasData = new CategoriasData();
                categoriasData.Editar_Categorias(categoriasModel);
                return RedirectToAction(nameof(IndexCategorias));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View(categoriasModel);
            }
        }


        [HttpGet]
        public IActionResult EliminarCategorias(int id)
        {
            CategoriasData categoriasData = new CategoriasData();
            var categoria = categoriasData.GetAllsCategorias().FirstOrDefault(categoria => categoria.Id_categoria == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCategorias(CategoriasModel categoriasModel)
        {
            try
            {
                CategoriasData categoriasData = new CategoriasData();
                categoriasData.Eliminar_Categorias(categoriasModel);
                return RedirectToAction(nameof(IndexCategorias));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View(categoriasModel);
            }
        }
    }
}
