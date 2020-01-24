using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class CtCiudadModel
    {
        public int id { get; set; }
        public int IdCtMuncipio { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        [Display(Name = "DEPARTAMENTO")]
        public int IdCtDepto { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NOMBRE_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        [Display(Name = "PAIS")]
        public int IdCtPais { get; set; }
        [Display(Name = "PAIS")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Descripion ")]

        public string Nombre { get; set; }
    }
}
