using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class Ba_MemorandoModel
    {
        public long Id { get; set; }
        public System.DateTime FechaInsercion { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public Nullable<int> Gestion { get; set; }
        public string IdAspNetUser { get; set; }
        public string rol { get; set; }
        public string NombreIdAspNetUser { get; set; }
        public string IdAspNetUserModifica { get; set; }
        public Nullable<long> IdExpediente { get; set; }
        public Nullable<int> Estado { get; set; }


       /// <summary>
       /// 
       /// </summary>

        [Display(Name = "NUMERO DE RADICADO")]
        [Required(ErrorMessage = ".")]
        public string Validacion1 { get; set; }

        [Display(Name = "FECHA RADICADO")]
        [Required(ErrorMessage = ".")]
        public string Validacion2 { get; set; }

        [Display(Name = "FISO NUMERICO")]
        [Required(ErrorMessage = ".")]
        public string Validacion3 { get; set; }

        [Display(Name = "DEPARTAMENTO")]
        [Required(ErrorMessage = ".")]
        public string Validacion4 { get; set; }

        [Display(Name = "MUNICIPIO")]
        [Required(ErrorMessage = ".")]
        public string Validacion5 { get; set; }

        [Display(Name = "NUMERO EXPEDIENTE")]
        [Required(ErrorMessage = ".")]
        public string Validacion6 { get; set; }

        [Display(Name = "FECHA DILIGENCIAMIENTO FISO")]
        [Required(ErrorMessage = ".")]
        public string Validacion7 { get; set; }

        [Display(Name = "TIPO SOLICITUD")]
        [Required(ErrorMessage = ".")]
        public string Validacion8 { get; set; }


        /// <summary>
        /// ///////////////
        /// </summary>

        [Display(Name = "SOLICITANTE")]
        [Required(ErrorMessage = ".")]
        public string Validacion9 { get; set; }

        [Display(Name = "DOCUMENTO IDENTIFICACIÓN")]
        [Required(ErrorMessage = ".")]
        public string Validacion10 { get; set; }


        [Display(Name = "COPIA DOCUMENTOS SOLICITANTE Y CONYUGE CARGADOS")]
        [Required(ErrorMessage = ".")]
        public string Validacion11 { get; set; }

        [Display(Name = "SI TIENE CERTIFICADO REPORTADO EN EL MEMO QUE SE ENCUENTRE CARGADO")]
        [Required(ErrorMessage = ".")]
        public string Validacion12 { get; set; }

        [Display(Name = "DECLARA RENTA SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion13 { get; set; }

        [Display(Name = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion14 { get; set; }

        [Display(Name = "PROPIETARIO DE OTRO PREDIO SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion15 { get; set; }

        [Display(Name = "PRESENTA PENDIENTES JUDICIALES SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion16 { get; set; }

        [Display(Name = "OCUPANTE INDEBIDO SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion17 { get; set; }

        [Display(Name = "VICTIMA DEL CONFLICTO ARMADO SOL")]
        [Required(ErrorMessage = ".")]
        public string Validacion18 { get; set; }

        /// <summary>
        /// 
        /// </summary>

        [Display(Name = "CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion19 { get; set; }

        [Display(Name = "IDENTIFICACION CONYUGE CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion20 { get; set; }

        [Display(Name = "DECLARA RENTA CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion21 { get; set; }

        [Display(Name = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion22 { get; set; }

        [Display(Name = "PROPIETARIO DE OTRO PREDIO CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion23 { get; set; }

        [Display(Name = "PRESENTA PENDIENTES JUDICIALES CONYUGE")]
        [Required(ErrorMessage = ".")]
        public string Validacion24 { get; set; }

        [Display(Name = "OCUPANTE INDEBIDO CONY")]
        [Required(ErrorMessage = ".")]
        public string Validacion25 { get; set; }


        [Display(Name = "VICTIMA DEL CONFLICTO ARMADO CONY")]
        [Required(ErrorMessage = ".")]
        public string Validacion26 { get; set; }

        [Display(Name = "INCLUSION RESO")]
        [Required(ErrorMessage = ".")]
        public string Validacion27 { get; set; }






        public string Validacion28 { get; set; }
        public string Validacion29 { get; set; }
        public string Validacion30 { get; set; }


        public string Validacion31 { get; set; }
        public string Validacion32 { get; set; }
        public string Validacion33 { get; set; }

        public string Validacion34 { get; set; }

        public string Validacion35 { get; set; }

        public string Validacion36 { get; set; }

        public string Validacion37 { get; set; }

        public string Validacion38 { get; set; }

        public string Validacion39 { get; set; }

        public string Validacion40 { get; set; }

        public string Validacion41 { get; set; }


        public string Validacion42 { get; set; }

        public string Validacion43 { get; set; }

        public string Validacion44 { get; set; }

        public string Validacion45 { get; set; }

        public string Validacion46 { get; set; }

        public string Validacion47 { get; set; }

        public string Validacion48 { get; set; }

        public string Validacion49 { get; set; }

        public string Validacion50 { get; set; }

        public string Validacion51 { get; set; }

        public string Validacion52 { get; set; }

        public string Validacion53 { get; set; }

        public string Validacion54 { get; set; }

        public string Validacion55 { get; set; }

        public string Validacion56 { get; set; }

        public string Validacion57 { get; set; }

        public string Validacion58 { get; set; }

        public string Validacion59 { get; set; }

        public string Validacion60 { get; set; }

        public string Validacion61 { get; set; }
        public string Validacion62 { get; set; }

        public string Validacion63 { get; set; }

    }
}
