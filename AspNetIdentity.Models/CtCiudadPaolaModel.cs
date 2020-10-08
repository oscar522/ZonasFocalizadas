using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class CtCiudadPaolaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un CODIGO DANE Departamento")]
        [Display(Name = "CODIGO DANE depto")]
        public Nullable<int> IdCtDepto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un NOMBRE Departamento")]
        [Display(Name = "CODIGO DANE")]
        public string NombreIdCtDepto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un CODIGO DANE Pais")]
        [Display(Name = "CODIGO DANE Pais")]
        public Nullable<int> IdCtPais { get; set; }

        [Required(ErrorMessage = "Debe ingresar un NOMBRE Pais")]
        [Display(Name = "CODIGO DANE Ciudad")]
        public string NombreIdCtPais { get; set; }

        public string Nombre { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
