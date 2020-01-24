using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AspNetIdentity.Models
{
    public class DatosBasicosDtoModel
    {

        public int ID_DATOS_BASICOS { get; set; }
        public int ID_USERS { get; set; }
        [Display(Name = "PAIS")]
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        public int ID_CT_PAIS { get; set; }
        public string NOMBRE_PAIS { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        public int ID_CT_DEPTO { get; set; }
        public string NOMBRE_DEPTO { get; set; }
        [Display(Name = "CIUDAD")]
        [Required(ErrorMessage = "Debe ingresar una Ciudad")]
        public int ID_CT_CIUDAD { get; set; }
        public string NOMBRE_CIUDAD { get; set; }
        [Display(Name = "ESTADO CIVIL")]
        [Required(ErrorMessage = "Debe ingresar un Estado Civil")]
        public int ID_CT_ESTADO_CIVIL { get; set; }
        public string NOMBRE_ESTADO_CIVIL { get; set; }
        [Display(Name = "TIPO DE IDENTIFICACION")]
        [Required(ErrorMessage = "Debe ingresar un Tipo de Identificación")]
        public int ID_CT_TIPO_IDENTIFICACION { get; set; }
        public string NOMBRE_TIPO_IDENTIFICACION { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRES { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Apellido")]
        public string APELLIDOS { get; set; }

        [Required(ErrorMessage = "Debe ingresar una Identificación")]
        public int IDENTIFICACION { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Nacimiento")]
        public System.DateTime F_NACIMIENTO { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Genero")]
        public int GENERO { get; set; }
        [Display(Name = "GENERO")]
        public string NOMBRE_GENERO{ get; set; }

        public string DIRECCION { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Descripción")]
        public string DESCRIPCION { get; set; }

        public string IMAGE_NAME { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Perfil")]
        public int ID_PERFIL { get; set; }
        [Display(Name = "PERFIL")]
        public string NOMBRE_PERFIL { get; set; }

        [Display(Name = "CREO")]
        public int USUARIO_CREO { get; set; }
        [Display(Name = "CREO")]
        public string USUARIO_CREO_NOMBRE { get; set; }
        [Display(Name = "F.CREO")]
        public DateTime FECHA_CREO { get; set; }


        [Display(Name = "CONTRASEÑA")]
        public string PasswordHash { get; set; }
        [Display(Name = "CONTRASEÑA")]
        public string PasswordHashConfir { get; set; }
        [Display(Name = "USUARIO")]
        public string UserName { get; set; }
        [Display(Name = "EMAIL")]
        public string Email { get; set; }
        [Display(Name = "IMAGEN")]
        public string ImageName { get; set; }
        


    }
}
