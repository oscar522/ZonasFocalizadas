using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class Ba_Memorando_newModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "  N/A  ")] 
        [Required(ErrorMessage = ".")] 
        public Int64 Id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "NÚMERO DE MEMORANDO")] [Required(ErrorMessage = ".")] 
        public  string  radicado    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "CARGA ORFEO")] [Required(ErrorMessage = ".")] 
        public  string  cargaorfeo  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ASIGNADO")] [Required(ErrorMessage = ".")] 
        public  string  asignado    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FECHA DE ASIGNACION")] [Required(ErrorMessage = ".")] 
        public Nullable<DateTime> Fechasignado    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FECHA MEMORANDO")] [Required(ErrorMessage = ".")] 
        public Nullable<DateTime> feacharadicado  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FISO")] 
        [Required(ErrorMessage = ".")] 
        public  int fiso    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "MUNICIPIO")] 
        [Required(ErrorMessage = ".")] 
        public  string  municipio   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DEPARTAMENTO")] 
        [Required(ErrorMessage = ".")] 
        public  string  departamento    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "NUMERO EXPEDIENTE")] 
        [Required(ErrorMessage = ".")] 
        public  string  expediente  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "FECHA DILIGENCIAMIENTO FISO")] [Required(ErrorMessage = ".")] 
        public Nullable<DateTime> fechafiso   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "TIPO SOLICITUD")] 
        [Required(ErrorMessage = ".")] 
        public  string  tiposolicitud   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "NOMBRE SOLCITANTE")] 
        [Required(ErrorMessage = ".")] 
        public  string  solicitante { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DOCUMENTO IDENTIFICACIÓN")] 
        [Required(ErrorMessage = ".")] 
        public  string  docidentificacionsol    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "COPIA DOCUMENTOS SOLICITANTE Y CONYUGE CARGADOS")] [Required(ErrorMessage = ".")] 
        public  string  copiadoc    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "COPIA DE CURSO AGRONOMICO ENUNCIADO EN EL MEMORANDO")] [Required(ErrorMessage = ".")] 
        public  string  copiacertificadocurso   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DECLARA RENTA")] 
        [Required(ErrorMessage = ".")] 
        public  string  declararentasol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS")] 
        [Required(ErrorMessage = ".")] 
        public  string  beneficiariosol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PROPIETARIO DE OTRO PREDIO")] 
        [Required(ErrorMessage = ".")] 
        public  string  propietariosol  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PRESENTA PENDIENTES JUDICIALES")] 
        [Required(ErrorMessage = ".")] 
        public  string  penjudicialessol    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "OCUPANTE INDEBIDO")] 
        [Required(ErrorMessage = ".")] 
        public  string  ocupanteindebidosol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "VICTIMA DEL CONFLICTO ARMADO")] 
        [Required(ErrorMessage = ".")] 
        public  string  victimadsol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "NOMBRE CONYUGE")] 
        [Required(ErrorMessage = ".")] 
        public  string  conyuge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "IDENTIFICACION CONYUGE ")] [Required(ErrorMessage = ".")] 
        public  string  docidentificacioncony   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "DECLARA RENTA")] 
        [Required(ErrorMessage = ".")] 
        public  string  declararentacony    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "BENEFICIARIO DE OTRO PROGRAMA DE TIERRAS")] 
        [Required(ErrorMessage = ".")] 
        public  string  beneficiariocony    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PROPIETARIO DE OTRO PREDIO")] 
        [Required(ErrorMessage = ".")] 
        public  string  propietariocony { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "PRESENTA PENDIENTES JUDICIALES")] 
        [Required(ErrorMessage = ".")] 
        public  string  penjudicialescony   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "OCUPANTE INDEBIDO")] 
        [Required(ErrorMessage = ".")] 
        public  string  ocupanteindevidocony    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "VICTIMA DEL CONFLICTO ARMADO")] 
        [Required(ErrorMessage = ".")] 
        public  string  victimadcony    { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "INCLUSIÓN RESO")] 
        [Required(ErrorMessage = ".")] 
        public  string  inclusionreso   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "RESPOSABLE JURIDICO")] [Required(ErrorMessage = ".")] 
        public  string  respojuridico   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "RESPOSABLE AGRONOMO")] [Required(ErrorMessage = ".")] 
        public  string  respoagronomo   { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "RESPOSABLE CATASTRAL")] [Required(ErrorMessage = ".")] 
        public  string  respocatastral  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "RESPOSABLE")] [Required(ErrorMessage = ".")] 
        public  string  responsable { get; set; }

        [Display(Name = "FECHA DE EDICCION")]
        public string  fechaediccion { get; set; }


        [Display(Name = "FECHA DE INSERCION")]
        public Nullable<DateTime> FechaInsercion { get ; set ;}


        [Display(Name = "FECHA DE MODIFICACION")]
        public Nullable<DateTime> FechaModificacion { get ; set ;}


        public Nullable<int> Gestion  { get ; set ; }
        public int Estado  { get ; set; }

        public string IdAspNetUser  { get ; set ;}
        public string IdAspNetUserModifica  { get ; set ;}

        public string rol { get; set; }
        public string NombreIdAspNetUser { get; set; }


    }
}
