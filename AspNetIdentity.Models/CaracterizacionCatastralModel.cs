using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class CaracterizacionCatastralModel
    {

        [Display(Name = "no. expediente ")]
        [Required(ErrorMessage = ".")]
        public string EXPEDIENTE { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "departamento ")]
        public string DEPARTAMEN { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "municipio ")]
        public string MUNICIPIO { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "vereda expediente ")]
        public string VeredaExpe { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "direccion o nombre del predio individual ")]
        public string NombrePred { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "centro poblado/rural disperso ")]
        public string Tipo_Ubica { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "existen restricciones  de áreas espaciales reportadas en inspeccion ocular? ")]
        public string Restriccio { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tipo de restricción espacial reportada en la inspección ocular. ")]
        public string TipoRestri { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "datos relevantes reportados en la inspeccion ocular ")]
        public string Observacio { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "se describe una presunta propiedad privada?  ")]
        public string PresuntaPr { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "observacion reporte revisión tecnica de planos ")]
        public string Observac_1 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "número del plano ")]
        public string NumeroPlan { get; set; }

        [Display(Name = "fecha plano ")]
        public Nullable<System.DateTime> FechaPlano { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "datum del plano ")]
        public string DATUMplano { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "el datum corresponde? ")]
        public string Correponde { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "nombre del topografo ")]

        public string NombreTopo { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cumple acuerdo 180? ")]
        public string CumpleAcue { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "numero hoja pdf ")]
        public string HojaPDFPla { get; set; }

        [Display(Name = "área total de terreno metros cuadrados ")]
        public Nullable<double> AreaTotalT { get; set; }

        [Display(Name = "area restringida metros cuadrados ")]
        public Nullable<double> AreaRestri { get; set; }

        [Display(Name = "área util de terreno metros cuadrados ")]
        public Nullable<double> AreaUtilTe { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "el plano tiene restricciones ")]
        public string Restricc_1 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cuál restricción?  ")]
        public string CualResPla { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "existe la rtdl? ")]
        public string ExisteRTDL { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento car? ")]
        public string Requerimie { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento urt? ")]
        public string Requerim_1 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento invias? ")]
        public string Requerim_2 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento anh? ")]
        public string Requerim_3 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento anm? ")]
        public string Requerim_4 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento asuntos etnicos? ")]
        public string Requerim_5 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene requerimiento zrc? ")]
        public string Requerim_6 { get; set; }
        public Nullable<System.DateTime> FechaEdici { get; set; }

        [Required(ErrorMessage = ".")]
        public string UsuarioEdi { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene levantamiento topográfico? ")]
        public string ExistePlan { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fiso ")]
        public string FISO { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "el expediente tiene inspección ocular?  ")]
        public string Inspeccion { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "número plano reportado en la inspección ocular ")]
        public string nPlanoIO { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "los colindantes de inspección ocular coinciden con los del plano topográfico? ")]
        public string Colindante { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "existe restricción reportada en el concepto ambiental? ")]
        public string ResConcept { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "en caso afirmativo, describa la restricción en el concepto ambiental ")]
        public string ConceptoAm { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "según la inspección ocular requiere concepto ambiental de las car? ")]
        public string Recomienda { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "el expediente tiene revisión tecnica de planos topograficos? ")]
        public string TieneRTP { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha de entrega revisión tecnica de planos ")]
        public string FechaRTP { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "está aprobado incoder (con sello y firma)? ")]
        public string PlanoAprob { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "trascripción de la rtdl ")]
        public string RTDL { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "se descuenta la restricción? ")]
        public string AreaDescon { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene inconsistencia la rtdl con respecto al plano? ")]
        public string ExisteInco { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cuál es la fuente de rtdl? ")]
        public string FuenteRTDL { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta car ")]
        public string FechaCAR { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "corporación autonoma de consulta ")]
        public string CARConsult { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRespu { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string RespuestaC { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta urt ")]
        public string FechaURT { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "dirección urt de consulta ")]
        public string DireccionC { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_1 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string RespuestaU { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta invias ")]
        public string FechaINVIA { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_2 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string RespuestaI { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta anh ")]
        public string FechaANH { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_3 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string RespuestaA { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta anm ")]
        public string FechaANM { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_4 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string Respuest_1 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene solicitud ani por área de reserva proyectos de infraestructura futuros? ")]
        public string Requerim_7 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta ani ")]
        public string FechaANI { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_5 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string Respuest_2 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta asuntos etnicos ")]
        public string FechaAE { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_6 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string Respuest_3 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "fecha en que se realiza la consulta zrc ")]
        public string FechaZRC { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "tiene respuesta la solicitud? ")]
        public string TieneRes_7 { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "resuma la respuesta si la tiene ")]
        public string RespuestaZ { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "está georeferenciado? ")]
        public string Esta_Georr { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cuál es la incosistencia en la rtdl? ")]
        public string CualIncons { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cumple con la geometría? ")]
        public string CumpleGeom { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "por qué no cumple con la geometría? ")]
        public string ObserNoCum { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "hay concordancia entre las coordenadas digitadas y las coordenadas del plano? ")]
        public string CoorDigVsC { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cumple con la exactitud posicional? ")]
        public string ExacPosici { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "por qué el plano no está georreferenciadio? ")]
        public string RazonPlano { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "existe traslape con otro expediente? ")]
        public string TraslapeEx { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "con cuál expediente traslapa? ")]
        public string TranslapeC { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "cuál es el insumo fuente para la georreferenciación? ")]
        public string Fuente_Dat { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "está desplazado? ")]
        public string Desplazado { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "por qué se considera desplazado? ")]
        public string Causa_Desp { get; set; }

        [Required(ErrorMessage = ".")]
        [Display(Name = "por que no existe concordancia en las coordenadas? ")]
        public string Causa_CDgV { get; set; }

        public Nullable<System.DateTime> FechaInsercion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> Gestion { get; set; }

        [Required(ErrorMessage = ".")]
        public string IdAspNetUser { get; set; }

        [Required(ErrorMessage = ".")]
        public string IdAspNetUserModifica { get; set; }
        public long Id { get; set; }
        public Nullable<long> IdExpediente { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string rol { get; set; }
        public string NombreIdAspNetUser { get; set; }

    }
}
