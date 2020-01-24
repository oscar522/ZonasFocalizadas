using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class RetencionDocumentalModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un Nombre al Documento ")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Grupo")]
        [Display(Name = "IdGrupo")]
        public int IdGrupo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre Grupo")]
        [Display(Name = "Nombre Grupo")]
        public string NombreGrupo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Orden")]
        [Display(Name = "Orden")]
        public int Orden { get; set; }

        public bool Estado { get; set; }
       
    }
}
