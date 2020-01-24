using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class ExpedienteDocumentosModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un Tipo de Documento ")]
        [Display(Name = "Tipo Documento")]
        public Nullable<int> IdRetencionDocumental { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Tipo de Documento ")]
        [Display(Name = "Tipo Documento")]
        public string NombreRetencionDocumental { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Expediente ")]
        [Display(Name = "Expediente")] 
        public Nullable<int> IdExpediente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Expediente")]
        [Display(Name = "Expediente")]
        public string  NombreExpediente { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Pagina Inicial")]
        [Display(Name = "Pag Inicial")]
        public Nullable<int> PagInicial { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Pagina Final")]
        [Display(Name = "Pag Final")]
        public Nullable<int> PagFinal { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Pagina Final")]
        [Display(Name = "Pag Final")]
        public string Archivo { get; set; }
        public string ArchivoUrl { get; set; }
        public bool Estado { get; set; }
        public int EstadoExp { get; set; }
        public string FechaInserta { get; set; }
        public string FechaModifica { get; set; }
        public string UsuarioInserta { get; set; }
        public string UsuarioModifica { get; set; }


    }
}
