using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class RetencionDocumentalGrupoModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un Nombre de Grupo Documental ")]
        [Display(Name = "Nombre Grupo")]
        public string NombreGrupo { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Orden")]
        [Display(Name = "Orden")]
        public int Orden { get; set; }
        
        public bool Estado { get; set; }
       
    }
}
