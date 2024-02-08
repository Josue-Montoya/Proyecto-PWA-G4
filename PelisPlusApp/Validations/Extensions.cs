using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PelisPlusApp.Validations
{
    public static class Extensions
    {
        public static void AddTModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
