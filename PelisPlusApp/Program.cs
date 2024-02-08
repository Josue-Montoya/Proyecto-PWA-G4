using System.Globalization;
using FluentValidation;
using PelisPlusApp.Models;
using PelisPlusApp.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IValidator<PeliculasModel>, PeliculasValidaciones>();
builder.Services.AddScoped<IValidator<DirectoresModel>, DirectoresValidator>();
builder.Services.AddScoped<IValidator<CategoriasModel>, CategoriaValidations>();

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("es");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
