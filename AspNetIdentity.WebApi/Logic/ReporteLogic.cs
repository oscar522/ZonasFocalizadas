using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class ReporteLogic
    {
        public List<RegistroModel> ConsultaRegistro()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.BaldiosPersonaNatural // caracterizacion juridica y caracterizacion solicitante
                .Join(Ctx.Registro, b => b.id, r =>r.IdExpediente,(b,r) => new { b,r })
                .Where(a => a.r.EstadoRegistro == true).Select(a => new RegistroModel
                {
                    Id = a.r.Id,
                    IdExpediente = a.r.IdExpediente,
                    NumeroExpediente = a.b.NumeroExpediente,
                    IdAspNetUser = a.r.IdAspNetUser,
                    FVerificacion = a.r.FVerificacion,
                    Estado = a.r.Estado,
                    Matricula = a.r.Matricula,
                    Fapertura = a.r.Fapertura,
                    TipoDocumento = a.r.TipoDocumento,
                    NumDocumento = a.r.NumDocumento,
                    FDocumento = a.r.FDocumento,
                    IdDepto = a.r.IdDepto,
                    //NombreIdDepto = a.r.NombreIdDepto,
                    IdMunicipio = a.r.IdMunicipio,
                    //NombreIdMunicipio = a.r.NombreIdMunicipio,
                    Area = a.r.Area,
                    CcSolicitante = a.r.CcSolicitante,
                    CcConyugue = a.r.CcConyugue,
                    Conyuge = a.r.Conyuge,
                    EstadoRegistro = a.r.EstadoRegistro,
                    UsuarioModifica = a.r.UsuarioModifica,
                    UsuarioActualiza = a.r.UsuarioActualiza,
                    //NombreUsuario = a.r.NombreUsuario,
                    //RolUsuario = a.r.RolUsuario,
                });

            return lista.ToList();
        }

        public List<CaracterizacionSolicitanteModel> ConsultaSolicitante()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.BaldiosPersonaNatural // caracterizacion juridica y caracterizacion solicitante
                .Join(Ctx.CaracterizacionSolicitante, b => b.id, s => s.IdExpediente, (b, s) => new { b, s })
                .Where(a => a.s.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                {
                    Id = a.s.Id,
                    IdExpediente = a.s.IdExpediente,
                    //NumeroExpediente = a.s.NumeroExpediente,
                    //IdDepto = a.s.IdDepto,
                    //NombreDepto = a.s.NombreDepto,
                    //IdMunicipio = a.s.IdMunicipio,
                    //NombreMunicipio = a.s.NombreMunicipio,


                    //NombreSolicitanteExpediente = a.s.NombreSolicitanteExpediente,
                    //DocSolicitanteExpediente = a.s.DocSolicitanteExpediente,
                    //IdTipoDocSolicitanteExpediente = a.s.IdTipoDocSolicitanteExpediente,
                    //TipoDocSolicitanteExpediente = a.s.TipoDocSolicitanteExpediente,

                    //NombreConyugeExpediente = a.s.NombreConyugeExpediente,
                    //DocConyugeExpediente = a.s.DocConyugeExpediente,
                    //IdTipoDocConyugeExpediente = a.s.IdTipoDocConyugeExpediente,
                    //TipoDocConyugeExpediente = a.s.TipoDocConyugeExpediente,



                    DocVisibleSol = a.s.DocVisibleSol,
                    CedulaExpSol = a.s.CedulaExpSol,
                    NombreSolicitante = a.s.NombreSolicitante,
                    TipoDocumento = a.s.TipoDocumento,
                   // NombreTipoDocumento = a.s.NombreTipoDocumento,
                    NumeroIdentificacion = a.s.NumeroIdentificacion,
                    FechaExpedicionSolicitante = a.s.FechaExpedicionSolicitante,

                    DocVisibleCon = a.s.DocVisibleCon,
                    CedulaExpCon = a.s.CedulaExpCon,
                    NombreConyuge = a.s.NombreConyuge,
                    TipoDocumentoConyuge = a.s.TipoDocumentoConyuge,
                   // NombreTipoDocumentoConyuge = a.s.NombreTipoDocumentoConyuge,
                    NumeroIdentificacionConyuge = a.s.NumeroIdentificacionConyuge,
                    FechaExpedicionConyuge = a.s.FechaExpedicionConyuge,


                    VFechaSolicitante = a.s.VFechaSolicitante,
                    VArchivoSolicitante = a.s.VArchivoSolicitante,
                    VVivoSolicitante = a.s.VVivoSolicitante,

                    VFechaConyuge = a.s.VFechaConyuge,
                    VArchivoConyuge = a.s.VArchivoConyuge,
                    VVivoConyuge = a.s.VVivoConyuge,


                    PFechaSolicitante = a.s.PFechaSolicitante,
                    PArchivoSolicitante = a.s.PArchivoSolicitante,
                    PInhabilidadSolicitante = a.s.PInhabilidadSolicitante,

                    PFechaConyuge = a.s.PFechaConyuge,
                    PArchivoConyuge = a.s.PArchivoConyuge,
                    PInhabilidadConyuge = a.s.PInhabilidadConyuge,


                    CFechaSolicitante = a.s.CFechaSolicitante,
                    CArchivoSolicitante = a.s.CArchivoSolicitante,
                    CInhabilidadSolicitante = a.s.CInhabilidadSolicitante,

                    CFechaConyuge = a.s.CFechaConyuge,
                    CArchivoConyuge = a.s.CArchivoConyuge,
                    CInhabilidadConyuge = a.s.CInhabilidadConyuge,


                    AFechaSolicitante = a.s.AFechaSolicitante,
                    AArchivoSolicitante = a.s.AArchivoSolicitante,
                    AInhabilidadSolicitante = a.s.AInhabilidadSolicitante,

                    AFechaConyuge = a.s.AFechaConyuge,
                    AArchivoConyuge = a.s.AArchivoConyuge,
                    AInhabilidadConyuge = a.s.AInhabilidadConyuge,


                    Gestion = a.s.Gestion,
                    IdAspNetUser = a.s.IdAspNetUser,
                    //NombretUser = a.s.NombretUser,
                    //RolUser = a.s.RolUser,
                    //Estado = a.s.Estado,

                    //RolLogin = a.s.RolLogin,
                    //UserLogin = a.s.UserLogin,


                });

            return lista.ToList();
        }

        public List<CaracterizacionJuridicaModel> ConsultaJuridica()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.BaldiosPersonaNatural // y caracterizacion solicitante
                .Join(Ctx.CaracterizacionJuridica, b => b.id, j => j.IdExpediente, (b, j) => new { b, j })
                .Where(a => a.j.Estado == true).Select(a => new CaracterizacionJuridicaModel
                {
                    Id = a.j.Id,

                    IdExpediente = a.j.IdExpediente,


                    INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.j.INSPECCION_OCULAR_INSPECCION_OCULAR_53,

                    INSPECCION_OCULAR_FECHA_54 = a.j.INSPECCION_OCULAR_FECHA_54,

                    INSPECCION_OCULAR_FIRMA_55 = a.j.INSPECCION_OCULAR_FIRMA_55,

                    INSPECCION_OCULAR_OPOSICIONES_56 = a.j.INSPECCION_OCULAR_OPOSICIONES_56,

                    INSPECCION_OCULAR_CONCEPTO_57 = a.j.INSPECCION_OCULAR_CONCEPTO_57,

                    INSPECCION_OCULAR_VISIBLE = a.j.INSPECCION_OCULAR_VISIBLE,


                    ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.j.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58,

                    ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.j.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59,

                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.j.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60,

                    ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.j.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,

                    ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.j.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62,

                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.j.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63,

                    ACLARACION_DE_INSPECCION_VISIBLE = a.j.ACLARACION_DE_INSPECCION_VISIBLE,


                    FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.j.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64,

                    FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.j.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65,

                    FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.j.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66,

                    FIJACION_EN_LISTA_FIRMA_67 = a.j.FIJACION_EN_LISTA_FIRMA_67,

                    FIJACION_EN_LISTA_VISIBLE = a.j.FIJACION_EN_LISTA_VISIBLE,


                    OPOCISIONES_OPOCISIONES_68 = a.j.OPOCISIONES_OPOCISIONES_68,

                    OPOCISIONES_FECHA_69 = a.j.OPOCISIONES_FECHA_69,

                    OPOCISIONES_EN_LISTA_VISIBLE = a.j.OPOCISIONES_EN_LISTA_VISIBLE,


                    FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.j.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70,

                    FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.j.FORMATO_DE_REVISION_JURIDICA_FECHA_71,

                    FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.j.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72,

                    FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.j.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,

                    FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.j.FORMATO_DE_REVISION_JURIDICA_VISIBLE,


                    // RESOLUCION_RESOLUCION
                    RESOLUCION_RESOLUCION_74 = a.j.RESOLUCION_RESOLUCION_74,

                    RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.j.RESOLUCION_NUMERO_DE_RESOLUCION_75,

                    RESOLUCION_FECHA_DE_RESOLUCION_76 = a.j.RESOLUCION_FECHA_DE_RESOLUCION_76,

                    RESOLUCION_FIRMADA_77 = a.j.RESOLUCION_FIRMADA_77,

                    RESOLUCION_DECISION_78 = a.j.RESOLUCION_DECISION_78,

                    RESOLUCION_DATOS_SOLICITANTE_BIEN = a.j.RESOLUCION_DATOS_SOLICITANTE_BIEN,

                    RESOLUCION_DATOS_SOLICITANTE_EN = a.j.RESOLUCION_DATOS_SOLICITANTE_EN,

                    RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.j.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79,

                    RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.j.RESOLUCION_CONJUNTA_INDIVIDUAL_80,

                    RESOLUCION_VISIBLE = a.j.RESOLUCION_VISIBLE,

                    RESOLUCION_RAZON_NEGACION = a.j.RESOLUCION_RAZON_NEGACION,



                    NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.j.NOTIFICACION_NOTIFICACION_SOLICITANTES_81,

                    NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.j.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82,

                    NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.j.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83,

                    NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.j.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84,

                    NOTIFICACION_VISIBLE = a.j.NOTIFICACION_VISIBLE,


                    RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.j.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85,

                    RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.j.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86,

                    RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.j.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87,

                    RECURSO_SOLICITANTE_DECISION_N_1 = a.j.RECURSO_SOLICITANTE_DECISION_N_1,

                    RECURSO_SOLICITANTE_FIRMADA_88 = a.j.RECURSO_SOLICITANTE_FIRMADA_88,

                    RECURSO_SOLICITANTE_ACTO_89 = a.j.RECURSO_SOLICITANTE_ACTO_89,

                    RECURSO_SOLICITANTE_NUMERO_90 = a.j.RECURSO_SOLICITANTE_NUMERO_90,

                    RECURSO_SOLICITANTE_FECHA_91 = a.j.RECURSO_SOLICITANTE_FECHA_91,

                    RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,

                    RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.j.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93,

                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.j.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94,

                    RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.j.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95,

                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.j.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

                    RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.j.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2,

                    RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.j.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,

                    RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.j.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4,

                    RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.j.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5,

                    RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.j.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6,

                    RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.j.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6,

                    RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.j.RECURSO_SOLICITANTE_CONJUNA_IND_N_7,

                    RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.j.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8,

                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.j.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,

                    RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.j.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10,

                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.j.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,

                    RECURSO_SOLICITANTE_VISIBLE = a.j.RECURSO_SOLICITANTE_VISIBLE,


                    RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.j.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85,

                    RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.j.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86,

                    RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.j.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87,

                    RECURSO_MINISTERIO_DECISION_N_1 = a.j.RECURSO_MINISTERIO_DECISION_N_1,

                    RECURSO_MINISTERIO_FIRMADA_88 = a.j.RECURSO_MINISTERIO_FIRMADA_88,

                    RECURSO_MINISTERIO_ACTO_89 = a.j.RECURSO_MINISTERIO_ACTO_89,

                    RECURSO_MINISTERIO_NUMERO_90 = a.j.RECURSO_MINISTERIO_NUMERO_90,

                    RECURSO_MINISTERIO_FECHA_91 = a.j.RECURSO_MINISTERIO_FECHA_91,

                    RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92,

                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.j.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93,

                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.j.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94,

                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.j.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95,

                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.j.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

                    RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.j.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2,

                    RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.j.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,

                    RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.j.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4,

                    RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.j.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5,

                    RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.j.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6,

                    RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.j.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6,

                    RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.j.RECURSO_MINISTERIO_CONJUNA_IND_N_7,

                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.j.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8,

                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.j.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,

                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.j.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10,

                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.j.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,

                    RECURSO_MINISTERIO_VISIBLE = a.j.RECURSO_MINISTERIO_VISIBLE,


                    CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.j.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,

                    CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.j.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,

                    CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.j.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,

                    CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.j.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,

                    CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.j.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION,

                    CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.j.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA,

                    CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.j.CONSTANCIA_DE_EJECUTORIA_VISIBLE,


                    REVOCATORIA_REVOCATORIA_113 = a.j.REVOCATORIA_REVOCATORIA_113,

                    //REVOCATORIA_NUMERO_RESOLUCION_114 = a.j.REVOCATORIA_NUMERO_RESOLUCION_114,

                    //REVOCATORIA_FECHA_DE_RESOLUCION_115 = a.j.REVOCATORIA_FECHA_DE_RESOLUCION_115,

                    REVOCATORIA_VISIBLE = a.j.REVOCATORIA_VISIBLE,


                    REGISTRO_FMI_ = a.j.REGISTRO_FMI_,

                    REGISTRO_FMI = a.j.REGISTRO_FMI,

                    REGISTRO_FECHA_DE_REGISTRO_117 = a.j.REGISTRO_FECHA_DE_REGISTRO_117,

                    REGISTRO_NUMERO_DE_RESOLUCION_118 = a.j.REGISTRO_NUMERO_DE_RESOLUCION_118,

                    REGISTRO_FECHA_DE_RESOLUCION_119 = a.j.REGISTRO_FECHA_DE_RESOLUCION_119,

                    REGISTRO_VISIBLE = a.j.REGISTRO_VISIBLE,


                    SOLICITUD_SOLICITUD = a.j.SOLICITUD_SOLICITUD,

                    SOLICITUD_FECHA = a.j.SOLICITUD_FECHA,

                    SOLICITUD_FIRMA = a.j.SOLICITUD_FIRMA,

                    SOLICITUD_TIPO_SOLICITUD = a.j.SOLICITUD_TIPO_SOLICITUD,

                    SOLICITUD_CEDULA_SOLICITANTE = a.j.SOLICITUD_CEDULA_SOLICITANTE,

                    SOLICITUD_CEDULA_CONYUGE = a.j.SOLICITUD_CEDULA_CONYUGE,

                    SOLICITUD_CEDULA_PARIENTE = a.j.SOLICITUD_CEDULA_PARIENTE,

                    SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.j.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA,

                    SOLICITUD_VISIBLE = a.j.SOLICITUD_VISIBLE,


                    AUTODEACEPTACION_AUTODEACEPTACION = a.j.AUTODEACEPTACION_AUTODEACEPTACION,

                    AUTODEACEPTACION_FECHA = a.j.AUTODEACEPTACION_FECHA,

                    AUTODEACEPTACION_FIRMA = a.j.AUTODEACEPTACION_FIRMA,

                    AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.j.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO,

                    AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.j.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO,

                    AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.j.AUTODEACEPTACION_DATOSPREDIOSCORRECTO,

                    AUTODEACEPTACION_COLINDANTE_CORRECTO = a.j.AUTODEACEPTACION_COLINDANTE_CORRECTO,

                    AUTODEACEPTACION_VISIBLE = a.j.AUTODEACEPTACION_VISIBLE,


                    COMUNICACIONES_SOLICITANTE = a.j.COMUNICACIONES_SOLICITANTE,

                    COMUNICACIONES_SOLICITANTEFECHA = a.j.COMUNICACIONES_SOLICITANTEFECHA,

                    COMUNICACIONES_SOLICITANTEFIRMA = a.j.COMUNICACIONES_SOLICITANTEFIRMA,

                    COMUNICACIONES_FECHAINSPECCIONOCULAR = a.j.COMUNICACIONES_FECHAINSPECCIONOCULAR,

                    COMUNICACIONES_VISIBLE = a.j.COMUNICACIONES_VISIBLE,

                    COMUNICACIONES_PROCURADOR = a.j.COMUNICACIONES_PROCURADOR,

                    COMUNICACIONES_PROCURADORFECHA = a.j.COMUNICACIONES_PROCURADORFECHA,

                    COMUNICACIONES_PROCURADORFIRMA = a.j.COMUNICACIONES_PROCURADORFIRMA,

                    COMUNICACIONES_VISIBLE_PROCURADOR = a.j.COMUNICACIONES_VISIBLE_PROCURADOR,

                    COMUNICACIONES_AUTORIDADAMBIENTAL = a.j.COMUNICACIONES_AUTORIDADAMBIENTAL,

                    COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.j.COMUNICACIONES_AUTORIDADAMBIENTALFECHA,

                    COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.j.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA,

                    COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL = a.j.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL,

                    COMUNICACIONES_COLINDATES = a.j.COMUNICACIONES_COLINDATES,

                    COMUNICACIONES_COLINDATES_INCOMPLETOS = a.j.COMUNICACIONES_COLINDATES_INCOMPLETOS,

                    COMUNICACIONES_COLINDATESFECHA = a.j.COMUNICACIONES_COLINDATESFECHA,

                    COMUNICACIONES_COLINDATESFIRMA = a.j.COMUNICACIONES_COLINDATESFIRMA,

                    COMUNICACIONES_VISIBLE_COLINDATES = a.j.COMUNICACIONES_VISIBLE_COLINDATES,




                    PUBLICACIONES_ALCALDIA = a.j.PUBLICACIONES_ALCALDIA,

                    PUBLICACIONES_ALCALDIAFECHAFIJACION = a.j.PUBLICACIONES_ALCALDIAFECHAFIJACION,

                    PUBLICACIONES_ALCALDIADESFIJACION = a.j.PUBLICACIONES_ALCALDIADESFIJACION,

                    PUBLICACIONES_ALCALDIAFIRMA = a.j.PUBLICACIONES_ALCALDIAFIRMA,

                    PUBLICACIONES_VISIBLE = a.j.PUBLICACIONES_VISIBLE,


                    PUBLICACIONES_INCODER = a.j.PUBLICACIONES_INCODER,

                    PUBLICACIONES_INCODERFECHAFIJACION = a.j.PUBLICACIONES_INCODERFECHAFIJACION,

                    PUBLICACIONES_INCODERDESFIJACION = a.j.PUBLICACIONES_INCODERDESFIJACION,

                    PUBLICACIONES_INCODERFIRMA = a.j.PUBLICACIONES_INCODERFIRMA,

                    PUBLICACIONES_VISIBLE_INCODER = a.j.PUBLICACIONES_VISIBLE_INCODER,


                    PUBLICACIONES_EMISORA = a.j.PUBLICACIONES_EMISORA,

                    PUBLICACIONES_EMISORAFECHA1 = a.j.PUBLICACIONES_EMISORAFECHA1,

                    PUBLICACIONES_EMISORAFECHA2 = a.j.PUBLICACIONES_EMISORAFECHA2,

                    PUBLICACIONES_EMISORAFIRMA = a.j.PUBLICACIONES_EMISORAFIRMA,

                    PUBLICACIONES_VISIBLE_EMISORA = a.j.PUBLICACIONES_VISIBLE_EMISORA,


                    // SUBSIDIODEAPELACION
                    SUBSIDIODEAPELACION = a.j.SUBSIDIODEAPELACION,

                    SUBSIDIODEAPELACION_VISIBLE = a.j.SUBSIDIODEAPELACION_VISIBLE,

                    SUBSIDIODEAPELACION_FECHA = a.j.SUBSIDIODEAPELACION_FECHA,

                    SUBSIDIODEAPELACION_RESPUESTA = a.j.SUBSIDIODEAPELACION_RESPUESTA,

                    SUBSIDIODEAPELACION_DECISION = a.j.SUBSIDIODEAPELACION_DECISION,




                    SUSPENCION_SUSPENCION_113 = a.j.SUSPENCION_SUSPENCION_113,
                    SUSPENCION_VISIBLE = a.j.SUSPENCION_VISIBLE,
                    SUSPENCION_FECHA = a.j.SUSPENCION_FECHA,
                    SUSPENCION_FIRMADO = a.j.SUSPENCION_FIRMADO,

                    DESISTIMIENTO_DESISTIMIENTO_113 = a.j.DESISTIMIENTO_DESISTIMIENTO_113,
                    DESISTIMIENTO_VISIBLE = a.j.DESISTIMIENTO_VISIBLE,
                    DESISTIMIENTO_FECHA = a.j.DESISTIMIENTO_FECHA,
                    DESISTIMIENTO_FIRMADO = a.j.DESISTIMIENTO_FIRMADO,



                    //NombreINSPECCION_OCULAR_CONCEPTO_57 = a.j.NombreINSPECCION_OCULAR_CONCEPTO_57,
                    //NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.j.NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,
                    //NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.j.NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,
                    //NombreRESOLUCION_DECISION_78 = a.j.NombreRESOLUCION_DECISION_78,
                    //NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.j.NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80,
                    //NombreIdAspNetUser = a.j.NombreIdAspNetUser,
                    //nombreSOLICITUD_TIPO_SOLICITUD = a.j.nombreSOLICITUD_TIPO_SOLICITUD,
                    //nombreRECURSO_SOLICITANTE_DECISION_N_1 = a.j.nombreRECURSO_SOLICITANTE_DECISION_N_1,
                    //nombreRECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.j.nombreRECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6,
                    //nombreRECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.j.nombreRECURSO_SOLICITANTE_CONJUNA_IND_N_7,
                    //nombreRECURSO_SOLICITANTE_ACTO_89 = a.j.nombreRECURSO_SOLICITANTE_ACTO_89,
                    //nombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.nombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,
                    //nombreRECURSO_MINISTERIO_DECISION_N_1 = a.j.nombreRECURSO_MINISTERIO_DECISION_N_1,
                    //nombreRECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.j.nombreRECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6,
                    //nombreRECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.j.nombreRECURSO_MINISTERIO_CONJUNA_IND_N_7,
                    //nombreRECURSO_MINISTERIO_ACTO_89 = a.j.nombreRECURSO_MINISTERIO_ACTO_89,
                    //nombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.nombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92,
                    //NumeroExpediente = a.j.NumeroExpediente,



                    Estado = a.j.Estado,
                    IdAspNetUser = a.j.IdAspNetUser,
                    //rol = a.j.rol,
                    FechaModificacion = a.j.FechaModificacion,
                    Gestion = a.j.Gestion,



                }).ToList();

            return lista;
        }

        public object ConsultaActividades()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ActividadesDiarias // y caracterizacion solicitante
                                                        //.Join(Ctx.CaracterizacionJuridica, b => b.id, j => j.IdExpediente, (b, j) => new { b, j })
                .Where(a => a.Estado == true)
                .Select(a => new { a.Observacion })
                //{

                //})
                .ToList();

            //var obj = JObject.Parse(data);

            return lista;
        }

    }
}