using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class GeneracionDocumentosLogic
    {
        CaracterizacionJuridica ModCtx = new CaracterizacionJuridica();

        //public CaracterizacionJuridicaModel Crear(CaracterizacionJuridicaModel a)
        //{
        //    using (ZonasFEntities Ctx = new ZonasFEntities())
        //    {
        //        CaracterizacionJuridica Nuevo = new CaracterizacionJuridica
        //        {
        //            Id = a.Id,
        //            IdExpediente = a.IdExpediente,
        //            INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.INSPECCION_OCULAR_INSPECCION_OCULAR_53,
        //            INSPECCION_OCULAR_FECHA_54 = a.INSPECCION_OCULAR_FECHA_54,
        //            INSPECCION_OCULAR_FIRMA_55 = a.INSPECCION_OCULAR_FIRMA_55,
        //            INSPECCION_OCULAR_OPOSICIONES_56 = a.INSPECCION_OCULAR_OPOSICIONES_56,
        //            INSPECCION_OCULAR_CONCEPTO_57 = a.INSPECCION_OCULAR_CONCEPTO_57,

        //            ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58,
        //            ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59,
        //            ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60,
        //            ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,
        //            ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62,
        //            ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63,

        //            FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64,
        //            FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65,
        //            FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66,
        //            FIJACION_EN_LISTA_FIRMA_67 = a.FIJACION_EN_LISTA_FIRMA_67,

        //            OPOCISIONES_OPOCISIONES_68 = a.OPOCISIONES_OPOCISIONES_68,
        //            OPOCISIONES_FECHA_69 = a.OPOCISIONES_FECHA_69,

        //            FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70,
        //            FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.FORMATO_DE_REVISION_JURIDICA_FECHA_71,
        //            FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72,
        //            FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,

        //            RESOLUCION_RESOLUCION_74 = a.RESOLUCION_RESOLUCION_74,
        //            RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.RESOLUCION_NUMERO_DE_RESOLUCION_75,
        //            RESOLUCION_FECHA_DE_RESOLUCION_76 = a.RESOLUCION_FECHA_DE_RESOLUCION_76,
        //            RESOLUCION_FIRMADA_77 = a.RESOLUCION_FIRMADA_77,
        //            RESOLUCION_DECISION_78 = a.RESOLUCION_DECISION_78,
        //            RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79,
        //            RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.RESOLUCION_CONJUNTA_INDIVIDUAL_80,
                    
        //            NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.NOTIFICACION_NOTIFICACION_SOLICITANTES_81,
        //            NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82,
        //            NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83,
        //            NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84,

        //            RECURSO_SOLICITANTE_DECISION_N_1 = a.RECURSO_SOLICITANTE_DECISION_N_1,
        //            RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2,
        //            RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
        //            RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4,
        //            RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5,
        //            RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6,
        //            RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6,
        //            RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.RECURSO_SOLICITANTE_CONJUNA_IND_N_7,
        //            RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8,
        //            RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
        //            RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
        //            RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
        //            RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85,
        //            RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86,
        //            RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87,
        //            RECURSO_SOLICITANTE_FIRMADA_88 = a.RECURSO_SOLICITANTE_FIRMADA_88,
        //            RECURSO_SOLICITANTE_ACTO_89 = a.RECURSO_SOLICITANTE_ACTO_89,
        //            RECURSO_SOLICITANTE_NUMERO_90 = a.RECURSO_SOLICITANTE_NUMERO_90,
        //            RECURSO_SOLICITANTE_FECHA_91 = a.RECURSO_SOLICITANTE_FECHA_91,
        //            RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,
        //            RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93,
        //            RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
        //            RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95,
        //            RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

        //            RECURSO_MINISTERIO_DECISION_N_1 = a.RECURSO_MINISTERIO_DECISION_N_1,
        //            RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2,
        //            RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
        //            RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4,
        //            RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5,
        //            RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6,
        //            RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6,
        //            RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.RECURSO_MINISTERIO_CONJUNA_IND_N_7,
        //            RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8,
        //            RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
        //            RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
        //            RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
        //            RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85,
        //            RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86,
        //            RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87,
        //            RECURSO_MINISTERIO_FIRMADA_88 = a.RECURSO_MINISTERIO_FIRMADA_88,
        //            RECURSO_MINISTERIO_ACTO_89 = a.RECURSO_MINISTERIO_ACTO_89,
        //            RECURSO_MINISTERIO_NUMERO_90 = a.RECURSO_MINISTERIO_NUMERO_90,
        //            RECURSO_MINISTERIO_FECHA_91 = a.RECURSO_MINISTERIO_FECHA_91,
        //            RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92,
        //            RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93,
        //            RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
        //            RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95,
        //            RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

        //            CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,
        //            CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,
        //            CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,
        //            CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,
        //            CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION,
        //            CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA,

        //            REVOCATORIA_REVOCATORIA_113 = a.REVOCATORIA_REVOCATORIA_113,
        //            REVOCATORIA_NUMERO_RESOLUCIÓN_114 = a.REVOCATORIA_NUMERO_RESOLUCION_114,
        //            REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = a.REVOCATORIA_FECHA_DE_RESOLUCION_115,
        //            REGISTRO_FMI_ = a.REGISTRO_FMI_,
        //            REGISTRO_FMI = a.REGISTRO_FMI,
        //            REGISTRO_FECHA_DE_REGISTRO_117 = a.REGISTRO_FECHA_DE_REGISTRO_117,
        //            REGISTRO_NUMERO_DE_RESOLUCION_118 = a.REGISTRO_NUMERO_DE_RESOLUCION_118,
        //            REGISTRO_FECHA_DE_RESOLUCION_119 = a.REGISTRO_FECHA_DE_RESOLUCION_119,

        //            SOLICITUD_SOLICITUD = a.SOLICITUD_SOLICITUD,
        //            SOLICITUD_FECHA = a.SOLICITUD_FECHA,
        //            SOLICITUD_FIRMA = a.SOLICITUD_FIRMA,
        //            SOLICITUD_TIPO_SOLICITUD = a.SOLICITUD_TIPO_SOLICITUD,
        //            SOLICITUD_CEDULA_SOLICITANTE = a.SOLICITUD_CEDULA_SOLICITANTE,
        //            SOLICITUD_CEDULA_CONYUGE = a.SOLICITUD_CEDULA_CONYUGE,
        //            SOLICITUD_CEDULA_PARIENTE = a.SOLICITUD_CEDULA_PARIENTE,
        //            SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA,

        //            AUTODEACEPTACION_AUTODEACEPTACION = a.AUTODEACEPTACION_AUTODEACEPTACION,
        //            AUTODEACEPTACION_FECHA = a.AUTODEACEPTACION_FECHA,
        //            AUTODEACEPTACION_FIRMA = a.AUTODEACEPTACION_FIRMA,
        //            AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO,
        //            AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO,
        //            AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.AUTODEACEPTACION_DATOSPREDIOSCORRECTO,

        //            COMUNICACIONES_SOLICITANTE = a.COMUNICACIONES_SOLICITANTE,
        //            COMUNICACIONES_SOLICITANTEFECHA = a.COMUNICACIONES_SOLICITANTEFECHA,
        //            COMUNICACIONES_SOLICITANTEFIRMA = a.COMUNICACIONES_SOLICITANTEFIRMA,
        //            COMUNICACIONES_FECHAINSPECCIONOCULAR = a.COMUNICACIONES_FECHAINSPECCIONOCULAR,
        //            COMUNICACIONES_PROCURADOR = a.COMUNICACIONES_PROCURADOR,
        //            COMUNICACIONES_PROCURADORFECHA = a.COMUNICACIONES_PROCURADORFECHA,
        //            COMUNICACIONES_PROCURADORFIRMA = a.COMUNICACIONES_PROCURADORFIRMA,
        //            COMUNICACIONES_AUTORIDADAMBIENTAL = a.COMUNICACIONES_AUTORIDADAMBIENTAL,
        //            COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.COMUNICACIONES_AUTORIDADAMBIENTALFECHA,
        //            COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA,
        //            COMUNICACIONES_COLINDATES = a.COMUNICACIONES_COLINDATES,
        //            COMUNICACIONES_COLINDATESFECHA = a.COMUNICACIONES_COLINDATESFECHA,
        //            COMUNICACIONES_COLINDATESFIRMA = a.COMUNICACIONES_COLINDATESFIRMA,

        //            PUBLICACIONES_ALCALDIA = a.PUBLICACIONES_ALCALDIA,
        //            PUBLICACIONES_ALCALDIAFECHAFIJACION = a.PUBLICACIONES_ALCALDIAFECHAFIJACION,
        //            PUBLICACIONES_ALCALDIADESFIJACION = a.PUBLICACIONES_ALCALDIADESFIJACION,
        //            PUBLICACIONES_ALCALDIAFIRMA = a.PUBLICACIONES_ALCALDIAFIRMA,
        //            PUBLICACIONES_VISIBLE = a.PUBLICACIONES_VISIBLE,

        //            PUBLICACIONES_INCODER = a.PUBLICACIONES_INCODER,
        //            PUBLICACIONES_INCODERFECHAFIJACION = a.PUBLICACIONES_INCODERFECHAFIJACION,
        //            PUBLICACIONES_INCODERDESFIJACION = a.PUBLICACIONES_INCODERDESFIJACION,
        //            PUBLICACIONES_INCODERFIRMA = a.PUBLICACIONES_INCODERFIRMA,
        //            PUBLICACIONES_VISIBLE_INCODER = a.PUBLICACIONES_VISIBLE_INCODER,

        //            PUBLICACIONES_EMISORA = a.PUBLICACIONES_EMISORA,
        //            PUBLICACIONES_EMISORAFECHA1 = a.PUBLICACIONES_EMISORAFECHA1,
        //            PUBLICACIONES_EMISORAFECHA2 = a.PUBLICACIONES_EMISORAFECHA2,
        //            PUBLICACIONES_EMISORAFIRMA = a.PUBLICACIONES_EMISORAFIRMA,
        //            PUBLICACIONES_VISIBLE_EMISORA = a.PUBLICACIONES_VISIBLE_EMISORA,

        //            INSPECCION_OCULAR_VISIBLE = a.INSPECCION_OCULAR_VISIBLE,
        //            ACLARACION_DE_INSPECCION_VISIBLE = a.ACLARACION_DE_INSPECCION_VISIBLE,
        //            FIJACION_EN_LISTA_VISIBLE = a.FIJACION_EN_LISTA_VISIBLE,
        //            OPOCISIONES_EN_LISTA_VISIBLE = a.OPOCISIONES_EN_LISTA_VISIBLE,
        //            FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.FORMATO_DE_REVISION_JURIDICA_VISIBLE,
        //            RESOLUCION_VISIBLE = a.RESOLUCION_VISIBLE,
        //            NOTIFICACION_VISIBLE = a.NOTIFICACION_VISIBLE,
        //            RECURSO_SOLICITANTE_VISIBLE = a.RECURSO_SOLICITANTE_VISIBLE,
        //            RECURSO_MINISTERIO_VISIBLE = a.RECURSO_MINISTERIO_VISIBLE,
        //            CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.CONSTANCIA_DE_EJECUTORIA_VISIBLE,
        //            REVOCATORIA_VISIBLE = a.REVOCATORIA_VISIBLE,
        //            REGISTRO_VISIBLE = a.REGISTRO_VISIBLE,
        //            SOLICITUD_VISIBLE = a.SOLICITUD_VISIBLE,
        //            AUTODEACEPTACION_VISIBLE = a.AUTODEACEPTACION_VISIBLE,
        //            COMUNICACIONES_VISIBLE = a.COMUNICACIONES_VISIBLE,
        //            AUTODEACEPTACION_COLINDANTE_CORRECTO = a.AUTODEACEPTACION_COLINDANTE_CORRECTO,
        //            COMUNICACIONES_COLINDATES_INCOMPLETOS = a.COMUNICACIONES_COLINDATES_INCOMPLETOS,
        //            RESOLUCION_DATOS_SOLICITANTE_BIEN = a.RESOLUCION_DATOS_SOLICITANTE_BIEN,
        //            RESOLUCION_DATOS_SOLICITANTE_EN = a.RESOLUCION_DATOS_SOLICITANTE_EN,


        //            Estado = true,
        //            IdAspNetUser = a.IdAspNetUser,
        //            FechaModificacion = DateTime.Now,
        //            Gestion = null
                   

        //        };

        //        Ctx.CaracterizacionJuridica.Add(Nuevo);
        //        Ctx.SaveChanges();
        //        return a;
        //    }
        //}

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.GeneracionDocumentos
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente.Value, c => c.id, (b, c) => new { caracte = b, baldios = c })
                .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                .Where(x => x.caracte.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                {
                  //  Id = Convert.ToInt32( a.caracte.Id),
                    IdExpediente = a.caracte.IdExpediente,
                    NumeroExpediente = a.baldios.NumeroExpediente,
                    IdDepto = a.depto.ID_CT_DEPTO,
                    NombreDepto = a.depto.NOMBRE,
                    IdMunicipio = a.munic.IdCtMuncipio,
                    NombreMunicipio = a.munic.Nombre,

                    NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                    DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),

                    NombreConyugeExpediente = a.baldios.NombreConyuge,
                    DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),

                    Gestion = a.caracte.Gestion,
                    //IdAspNetUser = a.caracte.IdAspNetUser,
                    IdAspNetUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x => x.Id_Hash).FirstOrDefault(),
                    ///NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                    NombretUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x => x.Name + " " + x.FirstName + " " + x.LastName).FirstOrDefault(),
                    RolUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser)
                                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) => new { UserRoles = c })
                                .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { c }).Select(f => f.c.Name).FirstOrDefault(),
                    Estado = a.caracte.Estado,

                }).ToList();



            return lista.ToList();
        }

        public List<BaldiosPersonaNaturalModel> Consulta(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var Resumen = Ctx.PlResumenTipificacionAll(73, 73, "da825085-c7c2-48b8-ab8f-11637623e1bd") 
                            .Select(c => c).ToList();
            var tipo = Ctx.ResumenCaracterizacionJuridica(id).Select(c => c).ToList(); ; //NombrePredio
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Join(Ctx.GeneracionDocumentos, b => b.id, c => c.IdExpediente.Value, (b, c) => new { b, c })
                 .Where(w => w.c.IdAspNetUser == id).ToList();
            #region Sql
            var lista = listaBaldios
                //.Where(w => w.IdAspNetUser == IdP)
                .Join(Ctx.CtDepto, b => b.b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new { b, NombrDepto = c.NOMBRE })
                .Join(Ctx.CtCiudad, d => d.b.b.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                 new {d.b,  d.NombrDepto, NombreMunicipio = e.Nombre, MunicipioIdDepto = e.IdCtDepto })
                .Join(Ctx.CtTipoIdentificacion, f => f.b.b.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                 new {f.b,f.NombrDepto, f.NombreMunicipio, NombreTipoIdentificacion = g.NOMBRE,f.MunicipioIdDepto})
                .Join(Ctx.CtGenero, h => h.b.b.IdGenero, i => i.ID_GENERO, (h, i) =>
                 new {h.b,h.NombrDepto,h.NombreMunicipio,h.NombreTipoIdentificacion, h.MunicipioIdDepto,NombreGenero = i.NOMBRE })
                .Join(Ctx.CtTipoIdentificacion, j => j.b.b.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new { j.b,j.NombrDepto,j.NombreMunicipio,j.NombreTipoIdentificacion,j.MunicipioIdDepto,j.NombreGenero,NombreTipoIdentificacionConyuge = k.NOMBRE})
                 .Where(w => w.MunicipioIdDepto == w.b.b.IdDepto)
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.b.b.id,
                    NumeroExpediente = c.b.b.NumeroExpediente,
                    IdDepto = c.b.b.IdDepto,
                    IdCiudad = c.b.c.Gestion,
                    Vereda = c.b.b.Vereda,
                    NombrePredio = tipo.Where(x =>x.IdExpediente == c.b.b.id).Select(u =>u.Tipo).FirstOrDefault(),
                    NombreBeneficiario = c.b.b.NombreBeneficiario,
                    NombreIdGenero = tipo.Where(x => x.IdExpediente == c.b.b.id).Select(u => u.SubTipo).FirstOrDefault(),
                    IdTipoIdentificacion = c.b.b.IdTipoIdentificacion,
                    Identificacion = c.b.b.Identificacion,
                    IdGenero = c.b.b.IdGenero,
                    NombreArchivo = Resumen.Where(x=>x.IdExpediente == c.b.b.id).Select(f => f.Grupo).FirstOrDefault(),
                    IdTipoIdentificacionConyuge = c.b.b.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.b.b.IdentificacionConyuge,
                    NombreConyuge = c.b.b.NombreConyuge,
                    EstadoInicialMigracion = c.b.b.EstadoInicialMigracion,
                    IdAspNetUser = c.b.c.FechaModificacion.ToString(),
                    NombreIdAspNetUser = c.b.c.Id.ToString(),
                    EstadoCaracterizacion = c.b.b.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.b.b.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                }).OrderByDescending(d => d.EstadoCaracterizacion);

            #endregion
            return lista.ToList();
        }

        public GeneracionDocumentosModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.GeneracionDocumentos.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente.Value, ll => ll.id, (b, ll) => new {b.b, b.c , ll, b.Name })
                .FirstOrDefault();

            GeneracionDocumentosModel GeneracionDocumentosModel_ = new GeneracionDocumentosModel();

            string RegistroDepto = "";
            string RegistroMuni = "";

            var Registro = Ctx.Registro.Where(x => x.IdExpediente == a.b.IdExpediente).FirstOrDefault();
            if (Registro.IdDepto > 0)
            {
                RegistroDepto = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO == Registro.IdDepto).FirstOrDefault().NOMBRE;

                if (RegistroDepto != "")
                {
                    RegistroMuni = Ctx.CtCiudad.Where(x => x.IdCtDepto == Registro.IdDepto && x.IdCtMuncipio == Registro.IdMunicipio).FirstOrDefault().Nombre;
                }
            }
            
            GeneracionDocumentosModel_.Id = a.b.Id;
            GeneracionDocumentosModel_.IdExpediente = a.b.IdExpediente;
            GeneracionDocumentosModel_.NumeroExpediente = a.ll.NumeroExpediente + "-" + RegistroDepto + "-" + RegistroMuni + "-" + Registro.Matricula + "-" +Registro.IdExpediente ;
            GeneracionDocumentosModel_.Validacion1 = a.b.Validacion1;
            GeneracionDocumentosModel_.Validacion2 = a.b.Validacion2;
            GeneracionDocumentosModel_.Validacion3 = a.b.Validacion3;
            GeneracionDocumentosModel_.Validacion4 = a.b.Validacion4;
            GeneracionDocumentosModel_.Validacion5 = a.b.Validacion5;
            GeneracionDocumentosModel_.Validacion6 = a.b.Validacion6;
            GeneracionDocumentosModel_.Validacion7 = a.b.Validacion7;
            GeneracionDocumentosModel_.Validacion8 = a.b.Validacion8;
            GeneracionDocumentosModel_.Validacion9 = a.b.Validacion9;
            GeneracionDocumentosModel_.Validacion10 = a.b.Validacion10;
            GeneracionDocumentosModel_.Gestion = a.b.Gestion;
            GeneracionDocumentosModel_.IdAspNetUser = a.b.IdAspNetUser;
            GeneracionDocumentosModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
            GeneracionDocumentosModel_.rol = a.Name;
            GeneracionDocumentosModel_.Estado = a.b.Estado;
            GeneracionDocumentosModel_.FechaModificacion = a.b.FechaModificacion;
            GeneracionDocumentosModel_.FechaCargue = a.b.FechaCargue;
            return GeneracionDocumentosModel_;
        }

        public GeneracionDocumentosModel Actualizar(GeneracionDocumentosModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var GeneracionDocumentosModel_ = Ctx.GeneracionDocumentos.Where(s => s.Id == a.Id).FirstOrDefault();
                if (GeneracionDocumentosModel_ != null)
                {
                    GeneracionDocumentosModel_.Validacion1 = a.Validacion1;
                    GeneracionDocumentosModel_.Validacion2 = a.Validacion2;
                    GeneracionDocumentosModel_.Validacion3 = a.Validacion3;
                    GeneracionDocumentosModel_.Validacion4 = a.Validacion4;
                    GeneracionDocumentosModel_.Validacion5 = a.Validacion5;
                    GeneracionDocumentosModel_.Validacion6 = a.Validacion6;
                    GeneracionDocumentosModel_.Validacion7 = a.Validacion7;
                    GeneracionDocumentosModel_.Validacion8 = a.Validacion8;
                    GeneracionDocumentosModel_.Validacion9 = a.Validacion9;
                    GeneracionDocumentosModel_.Validacion10 = a.Validacion10;
                    GeneracionDocumentosModel_.Gestion = 1;
                    GeneracionDocumentosModel_.FechaModificacion = DateTime.Now;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionJuridica.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        public List<CaracterizacionJuridicaCatalogosModel> ConsultarCatalogo(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Tipo == id)
                .Select(a => new CaracterizacionJuridicaCatalogosModel
                {
                   Id = a.Id,
                   Nombre = a.Nombre,
                   Tipo = a.Tipo,
                   Estado = a.Estado
                }).ToList();

            return lista;
        }
    }
}