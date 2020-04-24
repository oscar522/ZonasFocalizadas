using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    public class CaracterizacionJuridicaModel
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<long> IdExpediente { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public string NumeroExpediente { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> INSPECCION_OCULAR_INSPECCION_OCULAR_53 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> INSPECCION_OCULAR_FECHA_54 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> INSPECCION_OCULAR_FIRMA_55 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> INSPECCION_OCULAR_OPOSICIONES_56 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> INSPECCION_OCULAR_CONCEPTO_57 { get; set; }
        public string NombreINSPECCION_OCULAR_CONCEPTO_57 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 { get; set; }
        public string NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62  { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> FIJACION_EN_LISTA_FIRMA_67 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> OPOCISIONES_OPOCISIONES_68 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> OPOCISIONES_FECHA_69 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> FORMATO_DE_REVISION_JURIDICA_FECHA_71 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 { get; set; }
        public string NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RESOLUCION_RESOLUCION_74 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        //[Range(0.01, 999.99, ErrorMessage = "* Requerido")]
        public Nullable<long> RESOLUCION_NUMERO_DE_RESOLUCION_75 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RESOLUCION_FECHA_DE_RESOLUCION_76 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RESOLUCION_FIRMADA_77 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RESOLUCION_DECISION_78 { get; set; }
        public string NombreRESOLUCION_DECISION_78 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        // [Range(0.01, 999.99, ErrorMessage = "* Requerido")]

        public Nullable<long> RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RESOLUCION_CONJUNTA_INDIVIDUAL_80 { get; set; }
        public string NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> NOTIFICACION_NOTIFICACION_SOLICITANTES_81 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_SOLICITANTE_FIRMADA_88 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RECURSO_SOLICITANTE_ACTO_89 { get; set; }
        public string NombreRECURSO_SOLICITANTE_ACTO_89 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        // [Range(0.01, 999.99, ErrorMessage = "* Requerido")]

        public Nullable<long> RECURSO_SOLICITANTE_NUMERO_90 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_91 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }
        public string NombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_MINISTERIO_RECURSO_MINISTERIO_97 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_MINISTERIO_RESPUESTA_RECURSO_99 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_MINISTERIO_FIRMADA_100 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RECURSO_MINISTERIO_ACTO_101 { get; set; }
        public string NombreRECURSO_MINISTERIO_ACTO_101 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        // [Range(0.01, 999.99, ErrorMessage = "* Requerido")]

        public Nullable<long> RECURSO_MINISTERIO_NUMERO_102 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_103 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<int> RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 { get; set; }
        public string NombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<bool> REVOCATORIA_REVOCATORIA_113 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        //[Range(0.01, 999.99, ErrorMessage = "* Requerido")]

        public Nullable<long> REVOCATORIA_NUMERO_RESOLUCION_114 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> REVOCATORIA_FECHA_DE_RESOLUCION_115 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public string REGISTRO_FMI_116 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> REGISTRO_FECHA_DE_REGISTRO_117 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        //[Range(0.01, 999.99, ErrorMessage = "* Requerido")]
        public Nullable<long> REGISTRO_NUMERO_DE_RESOLUCION_118 { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public Nullable<System.DateTime> REGISTRO_FECHA_DE_RESOLUCION_119 { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public Nullable<bool> Estado { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public string IdAspNetUser { get; set; }

        [Required(ErrorMessage = "* Requerido")]

        public string NombreIdAspNetUser { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public string rol { get; set; }

        [Required(ErrorMessage = "* Requerido")]
        public string FechaModificacion { get; set; }
    }
}
