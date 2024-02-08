using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PelisPlusApp.Data;
using PelisPlusApp.Models;
using PelisPlusApp.Validations;


namespace PelisPlusApp.Controllers 
{
    public class DirectoresController : Controller
    {
        /*Inyeccion de dependencias*/
        private IValidator<DirectoresModel> _directoresValidator;

        /*Constructor*/
        public DirectoresController(IValidator<DirectoresModel> directoresValidator)
        {
            _directoresValidator = directoresValidator;
        }
        public IActionResult IndexDirectores()
        {
            DirectoresData directoresData = new DirectoresData();

            return View(directoresData.GetAllDirectores());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DirectoresModel directoresModel)
        {
            ValidationResult validationResult = _directoresValidator.Validate(directoresModel);

            try
            {
                DirectoresData directoresData = new DirectoresData();
                directoresData.Add(directoresModel);

                return RedirectToAction(nameof(IndexDirectores));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddTModelState(this.ModelState);

                return View(directoresModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DirectoresData directoresData = new DirectoresData();

            var employee = directoresData.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DirectoresModel directoresModel)
        {
            try
            {
                DirectoresData directoresData = new DirectoresData();
                directoresData.Edit(directoresModel);

                return RedirectToAction(nameof(IndexDirectores));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(directoresModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            DirectoresData directoresData = new DirectoresData();

            var directores = directoresData.GetById(id);

            if (directores == null)
            {
                return NotFound();
            }

            return View(directores);
        }

        [HttpPost]
        public IActionResult Delete(DirectoresModel directoresModel)
        {
            try
            {
                DirectoresData directoresData = new DirectoresData();
                directoresData.Delete(directoresModel.Id);

                return RedirectToAction(nameof(IndexDirectores));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(directoresModel);
            }
        }
    }
}
