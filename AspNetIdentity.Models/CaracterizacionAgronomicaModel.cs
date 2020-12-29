using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class CaracterizacionAgronomicaModel
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

        [Display(Name = "FISO")]
        [Required(ErrorMessage = ".")]
        public string Validacion61 { get; set; }

        [Display(Name = "Código QR")]
        [Required(ErrorMessage = ".")]
        public string Validacion1 { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = ".")]
        public string Validacion2 { get; set; }

        [Display(Name = "Municipio")]
        [Required(ErrorMessage = ".")]
        public string Validacion3 { get; set; }

        [Display(Name = "Corregimiento/Vereda")]
        [Required(ErrorMessage = ".")]
        public string Validacion4 { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        [Required(ErrorMessage = ".")]
        public string Validacion5 { get; set; }

        [Display(Name = "Identificación Solicitante")]
        [Required(ErrorMessage = ".")]
        public string Validacion6 { get; set; }

        [Display(Name = "Nombre completo del Solicitante")]
        [Required(ErrorMessage = ".")]
        public string Validacion7 { get; set; }

        [Display(Name = "Identificación Cónyuge")]
        [Required(ErrorMessage = ".")]
        public string Validacion8 { get; set; }

        [Display(Name = "Nombre completo del Cónyuge")]
        [Required(ErrorMessage = ".")]
        public string Validacion9 { get; set; }

        [Display(Name = "Número de Contacto")]
        [Required(ErrorMessage = ".")]
        public string Validacion10 { get; set; }

        [Display(Name = "ITJD Régimen de Escogencia (SIT o Excel Barrido")]
        [Required(ErrorMessage = ".")]
        public string Validacion11 { get; set; }

        [Display(Name = "ITJD Ubicación del Predio (Uso del Suelo, Excel Barrido")]
        [Required(ErrorMessage = ".")]
        public string Validacion12 { get; set; }

        [Display(Name = "ITJD Área (ha)  Plano - (SIT")]
        [Required(ErrorMessage = ".")]
        public string Validacion13 { get; set; }

        [Display(Name = "¿Cuenta con Inspeción Ocular")]
        [Required(ErrorMessage = ".")]
        public string Validacion14 { get; set; }

        [Display(Name = "Nombre del Predio")]
        [Required(ErrorMessage = ".")]
        public string Validacion15 { get; set; }

        [Display(Name = "¿Cuenta con Certificado de Uso del Suelo ?")]
        [Required(ErrorMessage = ".")]
        public string Validacion16 { get; set; }

        [Display(Name = "Uso principal del certificado de Uso de Suelo")]
        [Required(ErrorMessage = ".")]
        public string Validacion17 { get; set; }

        [Display(Name = "¿Cuenta con Cáculo de UAF ? ")]
        [Required(ErrorMessage = ".")]
        public string Validacion18 { get; set; }

        [Display(Name = "¿El predio cuenta con Vivienda?  (Si/No)(FISO Información del Predio - Fotografías - Plano ?")]
        [Required(ErrorMessage = ".")]
        public string Validacion19 { get; set; }

        [Display(Name = "Tipo de explotación (FISO 11.2 Clase de explotación ")]
        [Required(ErrorMessage = ".")]
        public string Validacion20 { get; set; }

        [Display(Name = "Años de ocupación o explotación (FISO")]
        [Required(ErrorMessage = ".")]
        public string Validacion21 { get; set; }

        [Display(Name = "Observación agronómica")]
        [Required(ErrorMessage = ".")]
        public string Validacion22 { get; set; }

        [Display(Name = "ITJP (902) UAF PREDIAL UAF* (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion23 { get; set; }

        [Display(Name = "ITJP (Rango 160) UAF por ZRH UAF* (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion24 { get; set; }

        [Display(Name = "ITJD (160 Y 902) UAF* (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion25 { get; set; }

        [Display(Name = "¿El solicitante es propietarios de otros predios rurales? (Si/No) (SIT- VUR - Abogado - Catrastral")]
        [Required(ErrorMessage = ".")]
        public string Validacion26 { get; set; }

        [Display(Name = "Área registrada y encontrada en el VUR a nombre del solicitante")]
        [Required(ErrorMessage = ".")]
        public string Validacion27 { get; set; }

        [Display(Name = "Área que suman los predios Privados del Solicitante (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion28 { get; set; }

        [Display(Name = "Número de solicitudes a nombre del Solicitante en el SIT")]
        [Required(ErrorMessage = ".")]
        public string Validacion29 { get; set; }

        [Display(Name = "Área que suman las solicitudes del Solicitante (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion30 { get; set; }

        [Display(Name = "¿El cónyuge es propietario de otros predios rurales? (Si/No) (SIT- VUR - Abogado - Catrastral")]
        [Required(ErrorMessage = ".")]
        public string Validacion31 { get; set; }

        [Display(Name = "Área registrada y encontrada en el VUR a nombre del Cónyuge")]
        [Required(ErrorMessage = ".")]
        public string Validacion32 { get; set; }

        [Display(Name = "Área que suman los predios privados del Cónyuge (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion33 { get; set; }

        [Display(Name = "Número de solicitudes a nombre del Cónyuge en el SIT")]
        [Required(ErrorMessage = ".")]
        public string Validacion34 { get; set; }

        [Display(Name = "Área que suman las solicitudes del Cónyuge (ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion35 { get; set; }

        [Display(Name = "Suma de Áreas de Todos Los Predios (Privados + Solicitudes)(ha")]
        [Required(ErrorMessage = ".")]
        public string Validacion36 { get; set; }

        [Display(Name = "ITJP LITERAL C")]
        [Required(ErrorMessage = ".")]
        public string Validacion37 { get; set; }

        [Display(Name = "ITJP LITERAL D")]
        [Required(ErrorMessage = ".")]
        public string Validacion38 { get; set; }

        [Display(Name = "ITJP LITERAL E")]
        [Required(ErrorMessage = ".")]
        public string Validacion39 { get; set; }

        [Display(Name = "ITJP LITERAL F")]
        [Required(ErrorMessage = ".")]
        public string Validacion40 { get; set; }

        [Display(Name = "ITJP LITERAL G")]
        [Required(ErrorMessage = ".")]
        public string Validacion41 { get; set; }

        [Display(Name = "ITJP UAF Predial Decreto 902")]
        [Required(ErrorMessage = ".")]
        public string Validacion42 { get; set; }

        [Display(Name = "ITJP UAF Predial Excepción Decreto 902")]
        [Required(ErrorMessage = ".")]
        public string Validacion43 { get; set; }

        [Display(Name = "ITJP Dentro del rango UAF – ZRH Ley 160")]
        [Required(ErrorMessage = ".")]
        public string Validacion44 { get; set; }

        [Display(Name = "ITJP Menor al rango de UAF – ZRH Ley 160")]
        [Required(ErrorMessage = ".")]
        public string Validacion45 { get; set; }

        [Display(Name = "ITJP Menor al rango de UAF – ZRH EXCEPCIÓN Ley 160  (solo si llena la columna anterior AK")]
        [Required(ErrorMessage = ".")]
        public string Validacion46 { get; set; }

        [Display(Name = "ITJD Aval agronómico")]
        [Required(ErrorMessage = ".")]
        public string Validacion47 { get; set; }

        [Display(Name = "ITJP 4.2. USO")]
        [Required(ErrorMessage = ".")]
        public string Validacion48 { get; set; }

        [Display(Name = "RESTRICCIÓN POR CAMBIO DE REGIMEN")]
        [Required(ErrorMessage = ".")]
        public string Validacion49 { get; set; }

        [Display(Name = "RESTRICCIÓN POR ACUMULACIÓN DE UAF")]
        [Required(ErrorMessage = ".")]
        public string Validacion50 { get; set; }

        [Display(Name = "RESTRICCIÓN POR AUSENCIA DE INSPECCIÓN OCULAR")]
        [Required(ErrorMessage = ".")]
        public string Validacion51 { get; set; }

        [Display(Name = "RESTRICCIÓN POR AUSENCIA DE USO DE SUELO")]
        [Required(ErrorMessage = ".")]
        public string Validacion52 { get; set; }

        [Display(Name = "RESTRICCIÓN POR AUSENCIA DE CÁLCULO DE UAF PREDIAL")]
        [Required(ErrorMessage = ".")]
        public string Validacion53 { get; set; }

        [Display(Name = "RESTRICCIÓN POR AUSENCIA DE FOTOGRAFIAS  O INFORMACIÓN INCOMPLETA DE FISO")]
        [Required(ErrorMessage = ".")]
        public string Validacion54 { get; set; }

        [Display(Name = "RESTRICCIÓN CONCEPTO AMBIENTAL")]
        [Required(ErrorMessage = ".")]
        public string Validacion55 { get; set; }

        [Display(Name = "ALERTA RONDA HÍDRICA")]
        [Required(ErrorMessage = ".")]
        public string Validacion56 { get; set; }

        [Display(Name = "OTROS (PROPIEDAD PRIVADA, CLARIDAD DEL CONYUGE, FISO REPETIDO, DOS SOLICITUES SOBRE EL MISMO PREDIO…")]
        [Required(ErrorMessage = ".")]
        public string Validacion57 { get; set; }

        [Display(Name = "IMPRIMIR RESOLUCIÓN DE APERTURA")]
        [Required(ErrorMessage = ".")]
        public string Validacion58 { get; set; }

        [Display(Name = "IMPRIMIR RESOLUCIÓN DE CIERRE")]
        [Required(ErrorMessage = ".")]
        public string Validacion59 { get; set; }

        [Display(Name = "ITJP e ITJD AGRONOMO RESPONSABLE")]
        [Required(ErrorMessage = ".")]
        public string Validacion60 { get; set; }



        public string Validacion62 { get; set; }

        public string Validacion63 { get; set; }






    }
}
