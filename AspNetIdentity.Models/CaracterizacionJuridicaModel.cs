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

        [Required(ErrorMessage = ".")]
        public long IdExpediente { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> INSPECCION_OCULAR_INSPECCION_OCULAR_53 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> INSPECCION_OCULAR_FECHA_54 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> INSPECCION_OCULAR_FIRMA_55 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> INSPECCION_OCULAR_OPOSICIONES_56 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> INSPECCION_OCULAR_CONCEPTO_57 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> INSPECCION_OCULAR_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> ACLARACION_DE_INSPECCION_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> FIJACION_EN_LISTA_FIRMA_67 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> FIJACION_EN_LISTA_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> OPOCISIONES_OPOCISIONES_68 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> OPOCISIONES_FECHA_69 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> OPOCISIONES_EN_LISTA_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> FORMATO_DE_REVISION_JURIDICA_FECHA_71 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> FORMATO_DE_REVISION_JURIDICA_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> RESOLUCION_RESOLUCION_74 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<long> RESOLUCION_NUMERO_DE_RESOLUCION_75 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RESOLUCION_FECHA_DE_RESOLUCION_76 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RESOLUCION_FIRMADA_77 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RESOLUCION_DECISION_78 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RESOLUCION_DATOS_SOLICITANTE_BIEN { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(0, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RESOLUCION_DATOS_SOLICITANTE_EN { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<long> RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RESOLUCION_CONJUNTA_INDIVIDUAL_80 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RESOLUCION_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> NOTIFICACION_NOTIFICACION_SOLICITANTES_81 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> NOTIFICACION_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_DECISION_N_1 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_FIRMADA_88 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_ACTO_89 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_SOLICITANTE_NUMERO_90 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_91 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_CONJUNA_IND_N_7 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_SOLICITANTE_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_DECISION_N_1 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_FIRMADA_88 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_ACTO_89 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_MINISTERIO_NUMERO_90 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_91 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 { get; set; }

        [Required(ErrorMessage = ".")]
        public string RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_CONJUNA_IND_N_7 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> RECURSO_MINISTERIO_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 { get; set; }

        [Required(ErrorMessage = ".")]
        public string CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> CONSTANCIA_DE_EJECUTORIA_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> REVOCATORIA_REVOCATORIA_113 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<long> REVOCATORIA_NUMERO_RESOLUCION_114 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> REVOCATORIA_FECHA_DE_RESOLUCION_115 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> REVOCATORIA_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> REGISTRO_FMI_ { get; set; }

        [Required(ErrorMessage = ".")]
        public string REGISTRO_FMI { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> REGISTRO_FECHA_DE_REGISTRO_117 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<long> REGISTRO_NUMERO_DE_RESOLUCION_118 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> REGISTRO_FECHA_DE_RESOLUCION_119 { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> REGISTRO_VISIBLE { get; set; }

        [Required(ErrorMessage = ".")]

        public Nullable<bool> SOLICITUD_SOLICITUD { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> SOLICITUD_FECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> SOLICITUD_FIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> SOLICITUD_TIPO_SOLICITUD { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> SOLICITUD_CEDULA_SOLICITANTE { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> SOLICITUD_CEDULA_CONYUGE { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> SOLICITUD_CEDULA_PARIENTE { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> SOLICITUD_VISIBLE { get; set; }

        [Required(ErrorMessage = ".")]

        public Nullable<bool> AUTODEACEPTACION_AUTODEACEPTACION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> AUTODEACEPTACION_FECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> AUTODEACEPTACION_FIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> AUTODEACEPTACION_DATOSPREDIOSCORRECTO { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> AUTODEACEPTACION_COLINDANTE_CORRECTO { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> AUTODEACEPTACION_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_SOLICITANTE { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> COMUNICACIONES_SOLICITANTEFECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_SOLICITANTEFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> COMUNICACIONES_FECHAINSPECCIONOCULAR { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_PROCURADOR { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> COMUNICACIONES_PROCURADORFECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_PROCURADORFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_AUTORIDADAMBIENTAL { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> COMUNICACIONES_AUTORIDADAMBIENTALFECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_AUTORIDADAMBIENTALFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> COMUNICACIONES_COLINDATES { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> COMUNICACIONES_COLINDATES_INCOMPLETOS { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> COMUNICACIONES_COLINDATESFECHA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> COMUNICACIONES_COLINDATESFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> COMUNICACIONES_VISIBLE { get; set; }


        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_ALCALDIA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_ALCALDIAFECHAFIJACION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_ALCALDIADESFIJACION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_ALCALDIAFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_INCODER { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_INCODERFECHAFIJACION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_INCODERDESFIJACION { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_INCODERFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_EMISORA { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_EMISORAFECHA1 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<System.DateTime> PUBLICACIONES_EMISORAFECHA2 { get; set; }

        [Required(ErrorMessage = ".")]
        public Nullable<bool> PUBLICACIONES_EMISORAFIRMA { get; set; }

        [Required(ErrorMessage = ".")]
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> PUBLICACIONES_VISIBLE { get; set; }

        public string NombreINSPECCION_OCULAR_CONCEPTO_57 { get; set; }
        public string NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 { get; set; }
        public string NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 { get; set; }
        public string NombreRESOLUCION_DECISION_78 { get; set; }
        public string NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 { get; set; }
        public string NombreIdAspNetUser { get; set; }
        public string nombreSOLICITUD_TIPO_SOLICITUD { get; set; }
        public string nombreRECURSO_SOLICITANTE_DECISION_N_1 { get; set; }
        public string nombreRECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 { get; set; }
        public string nombreRECURSO_SOLICITANTE_CONJUNA_IND_N_7 { get; set; }
        public string nombreRECURSO_SOLICITANTE_ACTO_89 { get; set; }
        public string nombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }
        public string nombreRECURSO_MINISTERIO_DECISION_N_1 { get; set; }
        public string nombreRECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 { get; set; }
        public string nombreRECURSO_MINISTERIO_CONJUNA_IND_N_7 { get; set; }
        public string nombreRECURSO_MINISTERIO_ACTO_89 { get; set; }
        public string nombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 { get; set; }
        public string NumeroExpediente { get; set; }

        public bool Estado { get; set; }
        public string IdAspNetUser { get; set; }
        public string rol { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = ".")]
        public Nullable<int> Gestion { get; set; }


    }
}
