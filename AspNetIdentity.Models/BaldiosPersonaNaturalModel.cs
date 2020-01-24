using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class BaldiosPersonaNaturalModel
    {

        public long id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Numero Expediente")]
        [Display(Name = "Numero Expediente")]
        public string NumeroExpediente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        [Display(Name = "Departamento")]
        public Nullable<long> IdDepto { get; set; }
        
        [Display(Name = "Departamento")]
        public string NombreIdDepto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Municipio")]
        [Display(Name = "Municipio")]
        public Nullable<long> IdCiudad { get; set; }
        
        [Display(Name = "Municipio")]
        public string NombreIdCiudad { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Vereda")]
        [Display(Name = "Vereda")]
        public string Vereda { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre del Predio")]
        [Display(Name = "Nombre Predio")]
        public string NombrePredio { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre del Bemeficiario")]
        [Display(Name = "Nombre Beneficiario")]
        public string NombreBeneficiario { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Tipo Identificacion")]
        [Display(Name = "Tipo Identificacion")]
        public Nullable<int> IdTipoIdentificacion { get; set; }
        
        [Display(Name = "Tipo Identificacion")]
        public string NombreIdTipoIdentificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Identificacion")]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Genero")]
        [Display(Name = "Genero")]
        public Nullable<int> IdGenero { get; set; }
        [Display(Name = "Genero")]
        public string NombreIdGenero { get; set; }


        [Required(ErrorMessage = "Debe ingresar un Tipo de Identificacion de Conyuge")]
        [Display(Name = "Tipo Identificacion Conyuge")]
        public Nullable<long> IdTipoIdentificacionConyuge { get; set; }

        [Display(Name = "Tipo Identificacion Conyuge")]
        public string NombreIdTipoIdentificacionConyuge { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Identificacion de Conyuge")]
        [Display(Name = "Identificacion Conyuge")]
        public string IdentificacionConyuge { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre del Conyuge")]
        [Display(Name = "Nombre Conyuge")]
        public string NombreConyuge { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Estado Inicial Migracion")]
        [Display(Name = "Estado Inicial Migracion")]
        public string EstadoInicialMigracion { get; set; }

        [Required(ErrorMessage = "Debe Asociarlo a un Usuario")]
        [Display(Name = "Usuario")]
        public string IdAspNetUser { get; set; }

        [Display(Name = "Usuario Asignado")]
        public string NombreIdAspNetUser { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Estado ")]
        [Display(Name = "Estado")]
        public Nullable<bool> EstadoCaracterizacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Archivo Pdf del Expediente")]
        [Display(Name = "Ruta Expediente")]
        public string RutaArchivoOriginal { get; set; }

        public string NombreArchivo { get; set; }
        public string TipoArchivo { get; set; }


    }
}
