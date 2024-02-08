using System.ComponentModel.DataAnnotations;

namespace PelisPlusApp.Models
{
    public class DirectoresModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }
        [Display(Name = "Premios Obtenidos")]
        public int Premios { get; set; }
    }
}
