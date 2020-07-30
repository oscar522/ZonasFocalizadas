using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspNetIdentity.Models
{
    public class GeneracionDocumentosModel
    {
        public int Id { get; set; }
        public Nullable<int> IdExpediente { get; set; }
        public string NumeroExpediente { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(-1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Validacion1 { get; set; }
        [Required(ErrorMessage = ".")]
        [Range(-1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Validacion2 { get; set; }
        [Required(ErrorMessage = ".")]
        [Range(-1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Validacion3 { get; set; }
        [Required(ErrorMessage = ".")]
        [Range(-1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Validacion4 { get; set; }
        [Required(ErrorMessage = ".")]
        [Range(-1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Validacion5 { get; set; }
        public Nullable<int> Validacion6 { get; set; }
        public Nullable<int> Validacion7 { get; set; }
        public Nullable<int> Validacion8 { get; set; }
        public Nullable<int> Validacion9 { get; set; }
        public Nullable<int> Validacion10 { get; set; }
        public Nullable<int> Gestion { get; set; }

        public string IdAspNetUser { get; set; }
        public string NombreIdAspNetUser { get; set; }
        public string rol { get; set; }

        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaCargue { get; set; }
    }
}
