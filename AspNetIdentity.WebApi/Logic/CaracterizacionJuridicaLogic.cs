using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CaracterizacionJuridicaLogic
    {
        CaracterizacionJuridica ModCtx = new CaracterizacionJuridica();

        public CaracterizacionJuridicaModel Crear(CaracterizacionJuridicaModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CaracterizacionJuridica Nuevo = new CaracterizacionJuridica
                {
                    Id = a.Id,
                    IdExpediente = a.IdExpediente,
                    INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.INSPECCION_OCULAR_INSPECCION_OCULAR_53,
                    INSPECCION_OCULAR_FECHA_54 = a.INSPECCION_OCULAR_FECHA_54,
                    INSPECCION_OCULAR_FIRMA_55 = a.INSPECCION_OCULAR_FIRMA_55,
                    INSPECCION_OCULAR_OPOSICIONES_56 = a.INSPECCION_OCULAR_OPOSICIONES_56,
                    INSPECCION_OCULAR_CONCEPTO_57 = a.INSPECCION_OCULAR_CONCEPTO_57,

                    ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58,
                    ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59,
                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60,
                    ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,
                    ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62,
                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63,

                    FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64,
                    FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65,
                    FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66,
                    FIJACION_EN_LISTA_FIRMA_67 = a.FIJACION_EN_LISTA_FIRMA_67,

                    OPOCISIONES_OPOCISIONES_68 = a.OPOCISIONES_OPOCISIONES_68,
                    OPOCISIONES_FECHA_69 = a.OPOCISIONES_FECHA_69,

                    FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70,
                    FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.FORMATO_DE_REVISION_JURIDICA_FECHA_71,
                    FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72,
                    FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,

                    RESOLUCION_RESOLUCION_74 = a.RESOLUCION_RESOLUCION_74,
                    RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.RESOLUCION_NUMERO_DE_RESOLUCION_75,
                    RESOLUCION_FECHA_DE_RESOLUCION_76 = a.RESOLUCION_FECHA_DE_RESOLUCION_76,
                    RESOLUCION_FIRMADA_77 = a.RESOLUCION_FIRMADA_77,
                    RESOLUCION_DECISION_78 = a.RESOLUCION_DECISION_78,
                    RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79,
                    RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.RESOLUCION_CONJUNTA_INDIVIDUAL_80,
                    
                    NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.NOTIFICACION_NOTIFICACION_SOLICITANTES_81,
                    NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82,
                    NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83,
                    NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84,

                    RECURSO_SOLICITANTE_DECISION_N_1 = a.RECURSO_SOLICITANTE_DECISION_N_1,
                    RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2,
                    RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
                    RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4,
                    RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5,
                    RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6,
                    RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6,
                    RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.RECURSO_SOLICITANTE_CONJUNA_IND_N_7,
                    RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
                    RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
                    RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85,
                    RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86,
                    RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87,
                    RECURSO_SOLICITANTE_FIRMADA_88 = a.RECURSO_SOLICITANTE_FIRMADA_88,
                    RECURSO_SOLICITANTE_ACTO_89 = a.RECURSO_SOLICITANTE_ACTO_89,
                    RECURSO_SOLICITANTE_NUMERO_90 = a.RECURSO_SOLICITANTE_NUMERO_90,
                    RECURSO_SOLICITANTE_FECHA_91 = a.RECURSO_SOLICITANTE_FECHA_91,
                    RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,
                    RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
                    RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

                    RECURSO_MINISTERIO_DECISION_N_1 = a.RECURSO_MINISTERIO_DECISION_N_1,
                    RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2,
                    RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
                    RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4,
                    RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5,
                    RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6,
                    RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6,
                    RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.RECURSO_MINISTERIO_CONJUNA_IND_N_7,
                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
                    RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85,
                    RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86,
                    RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87,
                    RECURSO_MINISTERIO_FIRMADA_88 = a.RECURSO_MINISTERIO_FIRMADA_88,
                    RECURSO_MINISTERIO_ACTO_89 = a.RECURSO_MINISTERIO_ACTO_89,
                    RECURSO_MINISTERIO_NUMERO_90 = a.RECURSO_MINISTERIO_NUMERO_90,
                    RECURSO_MINISTERIO_FECHA_91 = a.RECURSO_MINISTERIO_FECHA_91,
                    RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92,
                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,

                    CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,
                    CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,
                    CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,
                    CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,
                    CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION,
                    CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA,

                    REVOCATORIA_REVOCATORIA_113 = a.REVOCATORIA_REVOCATORIA_113,
                    REVOCATORIA_NUMERO_RESOLUCIÓN_114 = a.REVOCATORIA_NUMERO_RESOLUCION_114,
                    REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = a.REVOCATORIA_FECHA_DE_RESOLUCION_115,
                    REGISTRO_FMI_ = a.REGISTRO_FMI_,
                    REGISTRO_FMI = a.REGISTRO_FMI,
                    REGISTRO_FECHA_DE_REGISTRO_117 = a.REGISTRO_FECHA_DE_REGISTRO_117,
                    REGISTRO_NUMERO_DE_RESOLUCION_118 = a.REGISTRO_NUMERO_DE_RESOLUCION_118,
                    REGISTRO_FECHA_DE_RESOLUCION_119 = a.REGISTRO_FECHA_DE_RESOLUCION_119,

                    SOLICITUD_SOLICITUD = a.SOLICITUD_SOLICITUD,
                    SOLICITUD_FECHA = a.SOLICITUD_FECHA,
                    SOLICITUD_FIRMA = a.SOLICITUD_FIRMA,
                    SOLICITUD_TIPO_SOLICITUD = a.SOLICITUD_TIPO_SOLICITUD,
                    SOLICITUD_CEDULA_SOLICITANTE = a.SOLICITUD_CEDULA_SOLICITANTE,
                    SOLICITUD_CEDULA_CONYUGE = a.SOLICITUD_CEDULA_CONYUGE,
                    SOLICITUD_CEDULA_PARIENTE = a.SOLICITUD_CEDULA_PARIENTE,
                    SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA,

                    AUTODEACEPTACION_AUTODEACEPTACION = a.AUTODEACEPTACION_AUTODEACEPTACION,
                    AUTODEACEPTACION_FECHA = a.AUTODEACEPTACION_FECHA,
                    AUTODEACEPTACION_FIRMA = a.AUTODEACEPTACION_FIRMA,
                    AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO,
                    AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO,
                    AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.AUTODEACEPTACION_DATOSPREDIOSCORRECTO,

                    COMUNICACIONES_SOLICITANTE = a.COMUNICACIONES_SOLICITANTE,
                    COMUNICACIONES_SOLICITANTEFECHA = a.COMUNICACIONES_SOLICITANTEFECHA,
                    COMUNICACIONES_SOLICITANTEFIRMA = a.COMUNICACIONES_SOLICITANTEFIRMA,
                    COMUNICACIONES_FECHAINSPECCIONOCULAR = a.COMUNICACIONES_FECHAINSPECCIONOCULAR,
                    COMUNICACIONES_PROCURADOR = a.COMUNICACIONES_PROCURADOR,
                    COMUNICACIONES_PROCURADORFECHA = a.COMUNICACIONES_PROCURADORFECHA,
                    COMUNICACIONES_PROCURADORFIRMA = a.COMUNICACIONES_PROCURADORFIRMA,
                    COMUNICACIONES_AUTORIDADAMBIENTAL = a.COMUNICACIONES_AUTORIDADAMBIENTAL,
                    COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.COMUNICACIONES_AUTORIDADAMBIENTALFECHA,
                    COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA,
                    COMUNICACIONES_COLINDATES = a.COMUNICACIONES_COLINDATES,
                    COMUNICACIONES_COLINDATESFECHA = a.COMUNICACIONES_COLINDATESFECHA,
                    COMUNICACIONES_COLINDATESFIRMA = a.COMUNICACIONES_COLINDATESFIRMA,

                    PUBLICACIONES_ALCALDIA = a.PUBLICACIONES_ALCALDIA,
                    PUBLICACIONES_ALCALDIAFECHAFIJACION = a.PUBLICACIONES_ALCALDIAFECHAFIJACION,
                    PUBLICACIONES_ALCALDIADESFIJACION = a.PUBLICACIONES_ALCALDIADESFIJACION,
                    PUBLICACIONES_ALCALDIAFIRMA = a.PUBLICACIONES_ALCALDIAFIRMA,
                    PUBLICACIONES_VISIBLE = a.PUBLICACIONES_VISIBLE,

                    PUBLICACIONES_INCODER = a.PUBLICACIONES_INCODER,
                    PUBLICACIONES_INCODERFECHAFIJACION = a.PUBLICACIONES_INCODERFECHAFIJACION,
                    PUBLICACIONES_INCODERDESFIJACION = a.PUBLICACIONES_INCODERDESFIJACION,
                    PUBLICACIONES_INCODERFIRMA = a.PUBLICACIONES_INCODERFIRMA,
                    PUBLICACIONES_VISIBLE_INCODER = a.PUBLICACIONES_VISIBLE_INCODER,

                    PUBLICACIONES_EMISORA = a.PUBLICACIONES_EMISORA,
                    PUBLICACIONES_EMISORAFECHA1 = a.PUBLICACIONES_EMISORAFECHA1,
                    PUBLICACIONES_EMISORAFECHA2 = a.PUBLICACIONES_EMISORAFECHA2,
                    PUBLICACIONES_EMISORAFIRMA = a.PUBLICACIONES_EMISORAFIRMA,
                    PUBLICACIONES_VISIBLE_EMISORA = a.PUBLICACIONES_VISIBLE_EMISORA,

                    INSPECCION_OCULAR_VISIBLE = a.INSPECCION_OCULAR_VISIBLE,
                    ACLARACION_DE_INSPECCION_VISIBLE = a.ACLARACION_DE_INSPECCION_VISIBLE,
                    FIJACION_EN_LISTA_VISIBLE = a.FIJACION_EN_LISTA_VISIBLE,
                    OPOCISIONES_EN_LISTA_VISIBLE = a.OPOCISIONES_EN_LISTA_VISIBLE,
                    FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.FORMATO_DE_REVISION_JURIDICA_VISIBLE,
                    RESOLUCION_VISIBLE = a.RESOLUCION_VISIBLE,
                    NOTIFICACION_VISIBLE = a.NOTIFICACION_VISIBLE,
                    RECURSO_SOLICITANTE_VISIBLE = a.RECURSO_SOLICITANTE_VISIBLE,
                    RECURSO_MINISTERIO_VISIBLE = a.RECURSO_MINISTERIO_VISIBLE,
                    CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.CONSTANCIA_DE_EJECUTORIA_VISIBLE,
                    REVOCATORIA_VISIBLE = a.REVOCATORIA_VISIBLE,
                    REGISTRO_VISIBLE = a.REGISTRO_VISIBLE,
                    SOLICITUD_VISIBLE = a.SOLICITUD_VISIBLE,
                    AUTODEACEPTACION_VISIBLE = a.AUTODEACEPTACION_VISIBLE,
                    COMUNICACIONES_VISIBLE = a.COMUNICACIONES_VISIBLE,
                    AUTODEACEPTACION_COLINDANTE_CORRECTO = a.AUTODEACEPTACION_COLINDANTE_CORRECTO,
                    COMUNICACIONES_COLINDATES_INCOMPLETOS = a.COMUNICACIONES_COLINDATES_INCOMPLETOS,
                    RESOLUCION_DATOS_SOLICITANTE_BIEN = a.RESOLUCION_DATOS_SOLICITANTE_BIEN,
                    RESOLUCION_DATOS_SOLICITANTE_EN = a.RESOLUCION_DATOS_SOLICITANTE_EN,


                    Estado = true,
                    IdAspNetUser = a.IdAspNetUser,
                    FechaModificacion = DateTime.Now,
                    Gestion = null
                   

                };

                Ctx.CaracterizacionJuridica.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionJuridica
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
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
                 .Join(Ctx.CaracterizacionJuridica, b => b.id, c => c.IdExpediente, (b, c) => new { b, c })
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

        public CaracterizacionJuridicaModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.CaracterizacionJuridica.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new {b.b, b.c , ll, b.Name })
                .FirstOrDefault();

            CaracterizacionJuridicaModel CaracterizacionJuridicaModel_ = new CaracterizacionJuridicaModel();

            CaracterizacionJuridicaModel_.Id = a.b.Id;
            CaracterizacionJuridicaModel_.IdExpediente = a.b.IdExpediente;
            CaracterizacionJuridicaModel_.NumeroExpediente = a.ll.NumeroExpediente;
            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.b.INSPECCION_OCULAR_INSPECCION_OCULAR_53;
            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_FECHA_54 = a.b.INSPECCION_OCULAR_FECHA_54;
            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_FIRMA_55 = a.b.INSPECCION_OCULAR_FIRMA_55;
            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_OPOSICIONES_56 = a.b.INSPECCION_OCULAR_OPOSICIONES_56;
            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_CONCEPTO_57 = a.b.INSPECCION_OCULAR_CONCEPTO_57;
            CaracterizacionJuridicaModel_.NombreINSPECCION_OCULAR_CONCEPTO_57 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.INSPECCION_OCULAR_CONCEPTO_57.Value).Select(g => g.Nombre).FirstOrDefault();

            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.b.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58;
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59;
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60;
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61;
            CaracterizacionJuridicaModel_.NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.b.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62;
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63;

            CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.b.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64;
            CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.b.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65;
            CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.b.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66;
            CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FIRMA_67 = a.b.FIJACION_EN_LISTA_FIRMA_67;

            CaracterizacionJuridicaModel_.OPOCISIONES_OPOCISIONES_68 = a.b.OPOCISIONES_OPOCISIONES_68;
            CaracterizacionJuridicaModel_.OPOCISIONES_FECHA_69 = a.b.OPOCISIONES_FECHA_69;

            CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.b.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70;
            CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.b.FORMATO_DE_REVISION_JURIDICA_FECHA_71;
            CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.b.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72;
            CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73;
            CaracterizacionJuridicaModel_.NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73.Value).Select(g => g.Nombre).FirstOrDefault();

            CaracterizacionJuridicaModel_.RESOLUCION_RESOLUCION_74 = a.b.RESOLUCION_RESOLUCION_74;
            CaracterizacionJuridicaModel_.RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.b.RESOLUCION_NUMERO_DE_RESOLUCION_75;
            CaracterizacionJuridicaModel_.RESOLUCION_FECHA_DE_RESOLUCION_76 = a.b.RESOLUCION_FECHA_DE_RESOLUCION_76;
            CaracterizacionJuridicaModel_.RESOLUCION_FIRMADA_77 = a.b.RESOLUCION_FIRMADA_77;
            CaracterizacionJuridicaModel_.RESOLUCION_DECISION_78 = a.b.RESOLUCION_DECISION_78;
            CaracterizacionJuridicaModel_.NombreRESOLUCION_DECISION_78 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RESOLUCION_DECISION_78.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.b.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79;
            CaracterizacionJuridicaModel_.NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80;
            CaracterizacionJuridicaModel_.RESOLUCION_RAZON_NEGACION = a.b.RESOLUCION_RAZON_NEGACION;

            CaracterizacionJuridicaModel_.NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.b.NOTIFICACION_NOTIFICACION_SOLICITANTES_81;
            CaracterizacionJuridicaModel_.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82;
            CaracterizacionJuridicaModel_.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.b.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83;
            CaracterizacionJuridicaModel_.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84;

            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_N_1 = a.b.RECURSO_SOLICITANTE_DECISION_N_1;
            CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_N_1 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_N_1.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.b.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.b.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.b.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.b.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.b.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6;
            CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.b.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.b.RECURSO_SOLICITANTE_CONJUNA_IND_N_7;
            CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_CONJUNA_IND_N_7 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_CONJUNA_IND_N_7.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.b.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.b.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FIRMADA_88 = a.b.RECURSO_SOLICITANTE_FIRMADA_88;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_ACTO_89 = a.b.RECURSO_SOLICITANTE_ACTO_89;
            CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_ACTO_89 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_ACTO_89.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NUMERO_90 = a.b.RECURSO_SOLICITANTE_NUMERO_90;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_91 = a.b.RECURSO_SOLICITANTE_FECHA_91;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92;
            CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;


            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_N_1 = a.b.RECURSO_MINISTERIO_DECISION_N_1;
            CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_N_1 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_N_1.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.b.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.b.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.b.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.b.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.b.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6;
            CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.b.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.b.RECURSO_MINISTERIO_CONJUNA_IND_N_7;
            CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_CONJUNA_IND_N_7 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_CONJUNA_IND_N_7.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.b.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.b.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FIRMADA_88 = a.b.RECURSO_MINISTERIO_FIRMADA_88;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_ACTO_89 = a.b.RECURSO_MINISTERIO_ACTO_89;
            CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_ACTO_89 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_ACTO_89.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NUMERO_90 = a.b.RECURSO_MINISTERIO_NUMERO_90;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_91 = a.b.RECURSO_MINISTERIO_FECHA_91;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92;
            CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;


            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.b.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.b.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.b.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.b.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.b.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.b.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA;

            CaracterizacionJuridicaModel_.REVOCATORIA_REVOCATORIA_113 = a.b.REVOCATORIA_REVOCATORIA_113;
            CaracterizacionJuridicaModel_.REVOCATORIA_NUMERO_RESOLUCION_114 = a.b.REVOCATORIA_NUMERO_RESOLUCIÓN_114;
            CaracterizacionJuridicaModel_.REVOCATORIA_FECHA_DE_RESOLUCION_115 = a.b.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115;
            CaracterizacionJuridicaModel_.REGISTRO_FMI_ = a.b.REGISTRO_FMI_;
            CaracterizacionJuridicaModel_.REGISTRO_FMI = a.b.REGISTRO_FMI;
            CaracterizacionJuridicaModel_.REGISTRO_FECHA_DE_REGISTRO_117 = a.b.REGISTRO_FECHA_DE_REGISTRO_117;
            CaracterizacionJuridicaModel_.REGISTRO_NUMERO_DE_RESOLUCION_118 = a.b.REGISTRO_NUMERO_DE_RESOLUCION_118;
            CaracterizacionJuridicaModel_.REGISTRO_FECHA_DE_RESOLUCION_119 = a.b.REGISTRO_FECHA_DE_RESOLUCION_119;

            CaracterizacionJuridicaModel_.SOLICITUD_SOLICITUD = a.b.SOLICITUD_SOLICITUD;
            CaracterizacionJuridicaModel_.SOLICITUD_FECHA = a.b.SOLICITUD_FECHA;
            CaracterizacionJuridicaModel_.SOLICITUD_FIRMA = a.b.SOLICITUD_FIRMA;
            CaracterizacionJuridicaModel_.SOLICITUD_TIPO_SOLICITUD = a.b.SOLICITUD_TIPO_SOLICITUD;
            CaracterizacionJuridicaModel_.nombreSOLICITUD_TIPO_SOLICITUD = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.SOLICITUD_TIPO_SOLICITUD.Value).Select(g => g.Nombre).FirstOrDefault();
            CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_SOLICITANTE = a.b.SOLICITUD_CEDULA_SOLICITANTE;
            CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_CONYUGE = a.b.SOLICITUD_CEDULA_CONYUGE;
            CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_PARIENTE = a.b.SOLICITUD_CEDULA_PARIENTE;
            CaracterizacionJuridicaModel_.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.b.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA;

            CaracterizacionJuridicaModel_.AUTODEACEPTACION_AUTODEACEPTACION = a.b.AUTODEACEPTACION_AUTODEACEPTACION;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_FECHA = a.b.AUTODEACEPTACION_FECHA;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_FIRMA = a.b.AUTODEACEPTACION_FIRMA;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.b.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.b.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.b.AUTODEACEPTACION_DATOSPREDIOSCORRECTO;


            CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTE = a.b.COMUNICACIONES_SOLICITANTE;
            CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTEFECHA = a.b.COMUNICACIONES_SOLICITANTEFECHA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTEFIRMA = a.b.COMUNICACIONES_SOLICITANTEFIRMA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_FECHAINSPECCIONOCULAR = a.b.COMUNICACIONES_FECHAINSPECCIONOCULAR;
            CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE = a.b.COMUNICACIONES_VISIBLE;
            
            CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADOR = a.b.COMUNICACIONES_PROCURADOR;
            CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADORFECHA = a.b.COMUNICACIONES_PROCURADORFECHA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADORFIRMA = a.b.COMUNICACIONES_PROCURADORFIRMA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_PROCURADOR = a.b.COMUNICACIONES_VISIBLE_PROCURADOR;
            
            CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTAL = a.b.COMUNICACIONES_AUTORIDADAMBIENTAL;
            CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.b.COMUNICACIONES_AUTORIDADAMBIENTALFECHA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.b.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL = a.b.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL;

            CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATES = a.b.COMUNICACIONES_COLINDATES;
            CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATESFECHA = a.b.COMUNICACIONES_COLINDATESFECHA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATESFIRMA = a.b.COMUNICACIONES_COLINDATESFIRMA;
            CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATES_INCOMPLETOS = a.b.COMUNICACIONES_COLINDATES_INCOMPLETOS;
            CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_COLINDATES = a.b.COMUNICACIONES_VISIBLE_COLINDATES;


            CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIA = a.b.PUBLICACIONES_ALCALDIA;
            CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIAFECHAFIJACION = a.b.PUBLICACIONES_ALCALDIAFECHAFIJACION;
            CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIADESFIJACION = a.b.PUBLICACIONES_ALCALDIADESFIJACION;
            CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIAFIRMA = a.b.PUBLICACIONES_ALCALDIAFIRMA;
            CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE = a.b.PUBLICACIONES_VISIBLE;

            CaracterizacionJuridicaModel_.PUBLICACIONES_INCODER = a.b.PUBLICACIONES_INCODER;
            CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERFECHAFIJACION = a.b.PUBLICACIONES_INCODERFECHAFIJACION;
            CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERDESFIJACION = a.b.PUBLICACIONES_INCODERDESFIJACION;
            CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERFIRMA = a.b.PUBLICACIONES_INCODERFIRMA;
            CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE_INCODER = a.b.PUBLICACIONES_VISIBLE_INCODER;

            CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORA = a.b.PUBLICACIONES_EMISORA;
            CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFECHA1 = a.b.PUBLICACIONES_EMISORAFECHA1;
            CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFECHA2 = a.b.PUBLICACIONES_EMISORAFECHA2;
            CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFIRMA = a.b.PUBLICACIONES_EMISORAFIRMA;
            CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE_EMISORA = a.b.PUBLICACIONES_VISIBLE_EMISORA;

            CaracterizacionJuridicaModel_.INSPECCION_OCULAR_VISIBLE = a.b.INSPECCION_OCULAR_VISIBLE;
            CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_VISIBLE = a.b.ACLARACION_DE_INSPECCION_VISIBLE;
            CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_VISIBLE = a.b.FIJACION_EN_LISTA_VISIBLE;
            CaracterizacionJuridicaModel_.OPOCISIONES_EN_LISTA_VISIBLE = a.b.OPOCISIONES_EN_LISTA_VISIBLE;
            CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.b.FORMATO_DE_REVISION_JURIDICA_VISIBLE;
            CaracterizacionJuridicaModel_.RESOLUCION_VISIBLE = a.b.RESOLUCION_VISIBLE;
            CaracterizacionJuridicaModel_.NOTIFICACION_VISIBLE = a.b.NOTIFICACION_VISIBLE;
            CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_VISIBLE = a.b.RECURSO_SOLICITANTE_VISIBLE;
            CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_VISIBLE = a.b.RECURSO_MINISTERIO_VISIBLE;
            CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.b.CONSTANCIA_DE_EJECUTORIA_VISIBLE;
            CaracterizacionJuridicaModel_.REVOCATORIA_VISIBLE = a.b.REVOCATORIA_VISIBLE;
            CaracterizacionJuridicaModel_.REGISTRO_VISIBLE = a.b.REGISTRO_VISIBLE;
            CaracterizacionJuridicaModel_.SOLICITUD_VISIBLE = a.b.SOLICITUD_VISIBLE;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_VISIBLE = a.b.AUTODEACEPTACION_VISIBLE;
            CaracterizacionJuridicaModel_.AUTODEACEPTACION_COLINDANTE_CORRECTO = a.b.AUTODEACEPTACION_COLINDANTE_CORRECTO;
            CaracterizacionJuridicaModel_.RESOLUCION_DATOS_SOLICITANTE_BIEN = a.b.RESOLUCION_DATOS_SOLICITANTE_BIEN;
            CaracterizacionJuridicaModel_.RESOLUCION_DATOS_SOLICITANTE_EN = a.b.RESOLUCION_DATOS_SOLICITANTE_EN;

            //SUBSIDIODEAPELACION
            CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION = a.b.SUBSIDIODEAPELACION;
            CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_VISIBLE = a.b.SUBSIDIODEAPELACION_VISIBLE;
            CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_FECHA = a.b.SUBSIDIODEAPELACION_FECHA;
            CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_RESPUESTA = a.b.SUBSIDIODEAPELACION_RESPUESTA;
            CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_DECISION = a.b.SUBSIDIODEAPELACION_DECISION;

            //DESISTIMIENTO
            CaracterizacionJuridicaModel_.DESISTIMIENTO_DESISTIMIENTO_113 = a.b.DESISTIMIENTO_DESISTIMIENTO_113;
            CaracterizacionJuridicaModel_.DESISTIMIENTO_VISIBLE = a.b.DESISTIMIENTO_VISIBLE;
            CaracterizacionJuridicaModel_.DESISTIMIENTO_FECHA = a.b.DESISTIMIENTO_FECHA;
            CaracterizacionJuridicaModel_.DESISTIMIENTO_FIRMADO = a.b.DESISTIMIENTO_FIRMADO;

            CaracterizacionJuridicaModel_.Estado = true;
            CaracterizacionJuridicaModel_.IdAspNetUser = a.b.IdAspNetUser;
            CaracterizacionJuridicaModel_.rol = a.Name;
            CaracterizacionJuridicaModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
            CaracterizacionJuridicaModel_.FechaModificacion = a.b.FechaModificacion;
            CaracterizacionJuridicaModel_.Gestion = a.b.Gestion;
            return CaracterizacionJuridicaModel_;
        }

        public CaracterizacionJuridicaModel ConsultarIdExp(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.CaracterizacionJuridica.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new { b.b, b.c, ll, b.Name })
                .FirstOrDefault();
            
            CaracterizacionJuridicaModel CaracterizacionJuridicaModel_ = new CaracterizacionJuridicaModel();


            if (a != null)
            {

                CaracterizacionJuridicaModel_.Id = a.b.Id;
                CaracterizacionJuridicaModel_.IdExpediente = a.b.IdExpediente;
                CaracterizacionJuridicaModel_.NumeroExpediente = a.ll.NumeroExpediente;
                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.b.INSPECCION_OCULAR_INSPECCION_OCULAR_53;
                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_FECHA_54 = a.b.INSPECCION_OCULAR_FECHA_54;
                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_FIRMA_55 = a.b.INSPECCION_OCULAR_FIRMA_55;
                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_OPOSICIONES_56 = a.b.INSPECCION_OCULAR_OPOSICIONES_56;
                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_CONCEPTO_57 = a.b.INSPECCION_OCULAR_CONCEPTO_57;
                CaracterizacionJuridicaModel_.NombreINSPECCION_OCULAR_CONCEPTO_57 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.INSPECCION_OCULAR_CONCEPTO_57.Value).Select(g => g.Nombre).FirstOrDefault();

                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.b.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58;
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59;
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60;
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61;
                CaracterizacionJuridicaModel_.NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.b.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62;
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63;

                CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.b.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64;
                CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.b.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65;
                CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.b.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66;
                CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_FIRMA_67 = a.b.FIJACION_EN_LISTA_FIRMA_67;

                CaracterizacionJuridicaModel_.OPOCISIONES_OPOCISIONES_68 = a.b.OPOCISIONES_OPOCISIONES_68;
                CaracterizacionJuridicaModel_.OPOCISIONES_FECHA_69 = a.b.OPOCISIONES_FECHA_69;

                CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.b.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70;
                CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.b.FORMATO_DE_REVISION_JURIDICA_FECHA_71;
                CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.b.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72;
                CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73;
                CaracterizacionJuridicaModel_.NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73.Value).Select(g => g.Nombre).FirstOrDefault();

                CaracterizacionJuridicaModel_.RESOLUCION_RESOLUCION_74 = a.b.RESOLUCION_RESOLUCION_74;
                CaracterizacionJuridicaModel_.RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.b.RESOLUCION_NUMERO_DE_RESOLUCION_75;
                CaracterizacionJuridicaModel_.RESOLUCION_FECHA_DE_RESOLUCION_76 = a.b.RESOLUCION_FECHA_DE_RESOLUCION_76;
                CaracterizacionJuridicaModel_.RESOLUCION_FIRMADA_77 = a.b.RESOLUCION_FIRMADA_77;
                CaracterizacionJuridicaModel_.RESOLUCION_DECISION_78 = a.b.RESOLUCION_DECISION_78;
                CaracterizacionJuridicaModel_.NombreRESOLUCION_DECISION_78 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RESOLUCION_DECISION_78.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.b.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79;
                CaracterizacionJuridicaModel_.NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80;
                CaracterizacionJuridicaModel_.RESOLUCION_RAZON_NEGACION = a.b.RESOLUCION_RAZON_NEGACION;

                CaracterizacionJuridicaModel_.NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.b.NOTIFICACION_NOTIFICACION_SOLICITANTES_81;
                CaracterizacionJuridicaModel_.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82;
                CaracterizacionJuridicaModel_.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.b.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83;
                CaracterizacionJuridicaModel_.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84;

                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_N_1 = a.b.RECURSO_SOLICITANTE_DECISION_N_1;
                CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_N_1 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_N_1.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.b.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.b.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.b.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.b.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.b.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6;
                CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.b.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.b.RECURSO_SOLICITANTE_CONJUNA_IND_N_7;
                CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_CONJUNA_IND_N_7 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_CONJUNA_IND_N_7.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.b.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.b.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FIRMADA_88 = a.b.RECURSO_SOLICITANTE_FIRMADA_88;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_ACTO_89 = a.b.RECURSO_SOLICITANTE_ACTO_89;
                CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_ACTO_89 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_ACTO_89.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NUMERO_90 = a.b.RECURSO_SOLICITANTE_NUMERO_90;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_91 = a.b.RECURSO_SOLICITANTE_FECHA_91;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92;
                CaracterizacionJuridicaModel_.nombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;


                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_N_1 = a.b.RECURSO_MINISTERIO_DECISION_N_1;
                CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_N_1 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_N_1.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.b.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.b.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.b.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.b.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.b.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6;
                CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.b.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.b.RECURSO_MINISTERIO_CONJUNA_IND_N_7;
                CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_CONJUNA_IND_N_7 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_CONJUNA_IND_N_7.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.b.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.b.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FIRMADA_88 = a.b.RECURSO_MINISTERIO_FIRMADA_88;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_ACTO_89 = a.b.RECURSO_MINISTERIO_ACTO_89;
                CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_ACTO_89 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_ACTO_89.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NUMERO_90 = a.b.RECURSO_MINISTERIO_NUMERO_90;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_91 = a.b.RECURSO_MINISTERIO_FECHA_91;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92;
                CaracterizacionJuridicaModel_.nombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;


                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.b.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.b.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.b.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.b.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.b.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.b.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA;

                CaracterizacionJuridicaModel_.REVOCATORIA_REVOCATORIA_113 = a.b.REVOCATORIA_REVOCATORIA_113;
                CaracterizacionJuridicaModel_.REVOCATORIA_NUMERO_RESOLUCION_114 = a.b.REVOCATORIA_NUMERO_RESOLUCIÓN_114;
                CaracterizacionJuridicaModel_.REVOCATORIA_FECHA_DE_RESOLUCION_115 = a.b.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115;
                CaracterizacionJuridicaModel_.REGISTRO_FMI_ = a.b.REGISTRO_FMI_;
                CaracterizacionJuridicaModel_.REGISTRO_FMI = a.b.REGISTRO_FMI;
                CaracterizacionJuridicaModel_.REGISTRO_FECHA_DE_REGISTRO_117 = a.b.REGISTRO_FECHA_DE_REGISTRO_117;
                CaracterizacionJuridicaModel_.REGISTRO_NUMERO_DE_RESOLUCION_118 = a.b.REGISTRO_NUMERO_DE_RESOLUCION_118;
                CaracterizacionJuridicaModel_.REGISTRO_FECHA_DE_RESOLUCION_119 = a.b.REGISTRO_FECHA_DE_RESOLUCION_119;

                CaracterizacionJuridicaModel_.SOLICITUD_SOLICITUD = a.b.SOLICITUD_SOLICITUD;
                CaracterizacionJuridicaModel_.SOLICITUD_FECHA = a.b.SOLICITUD_FECHA;
                CaracterizacionJuridicaModel_.SOLICITUD_FIRMA = a.b.SOLICITUD_FIRMA;
                CaracterizacionJuridicaModel_.SOLICITUD_TIPO_SOLICITUD = a.b.SOLICITUD_TIPO_SOLICITUD;
                CaracterizacionJuridicaModel_.nombreSOLICITUD_TIPO_SOLICITUD = Ctx.CaracterizacionJuridicaCatalogos.Where(x => x.Id == a.b.SOLICITUD_TIPO_SOLICITUD.Value).Select(g => g.Nombre).FirstOrDefault();
                CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_SOLICITANTE = a.b.SOLICITUD_CEDULA_SOLICITANTE;
                CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_CONYUGE = a.b.SOLICITUD_CEDULA_CONYUGE;
                CaracterizacionJuridicaModel_.SOLICITUD_CEDULA_PARIENTE = a.b.SOLICITUD_CEDULA_PARIENTE;
                CaracterizacionJuridicaModel_.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.b.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA;

                CaracterizacionJuridicaModel_.AUTODEACEPTACION_AUTODEACEPTACION = a.b.AUTODEACEPTACION_AUTODEACEPTACION;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_FECHA = a.b.AUTODEACEPTACION_FECHA;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_FIRMA = a.b.AUTODEACEPTACION_FIRMA;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.b.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.b.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.b.AUTODEACEPTACION_DATOSPREDIOSCORRECTO;


                CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTE = a.b.COMUNICACIONES_SOLICITANTE;
                CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTEFECHA = a.b.COMUNICACIONES_SOLICITANTEFECHA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_SOLICITANTEFIRMA = a.b.COMUNICACIONES_SOLICITANTEFIRMA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_FECHAINSPECCIONOCULAR = a.b.COMUNICACIONES_FECHAINSPECCIONOCULAR;
                CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE = a.b.COMUNICACIONES_VISIBLE;

                CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADOR = a.b.COMUNICACIONES_PROCURADOR;
                CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADORFECHA = a.b.COMUNICACIONES_PROCURADORFECHA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_PROCURADORFIRMA = a.b.COMUNICACIONES_PROCURADORFIRMA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_PROCURADOR = a.b.COMUNICACIONES_VISIBLE_PROCURADOR;

                CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTAL = a.b.COMUNICACIONES_AUTORIDADAMBIENTAL;
                CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.b.COMUNICACIONES_AUTORIDADAMBIENTALFECHA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.b.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL = a.b.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL;

                CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATES = a.b.COMUNICACIONES_COLINDATES;
                CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATESFECHA = a.b.COMUNICACIONES_COLINDATESFECHA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATESFIRMA = a.b.COMUNICACIONES_COLINDATESFIRMA;
                CaracterizacionJuridicaModel_.COMUNICACIONES_COLINDATES_INCOMPLETOS = a.b.COMUNICACIONES_COLINDATES_INCOMPLETOS;
                CaracterizacionJuridicaModel_.COMUNICACIONES_VISIBLE_COLINDATES = a.b.COMUNICACIONES_VISIBLE_COLINDATES;


                CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIA = a.b.PUBLICACIONES_ALCALDIA;
                CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIAFECHAFIJACION = a.b.PUBLICACIONES_ALCALDIAFECHAFIJACION;
                CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIADESFIJACION = a.b.PUBLICACIONES_ALCALDIADESFIJACION;
                CaracterizacionJuridicaModel_.PUBLICACIONES_ALCALDIAFIRMA = a.b.PUBLICACIONES_ALCALDIAFIRMA;
                CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE = a.b.PUBLICACIONES_VISIBLE;

                CaracterizacionJuridicaModel_.PUBLICACIONES_INCODER = a.b.PUBLICACIONES_INCODER;
                CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERFECHAFIJACION = a.b.PUBLICACIONES_INCODERFECHAFIJACION;
                CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERDESFIJACION = a.b.PUBLICACIONES_INCODERDESFIJACION;
                CaracterizacionJuridicaModel_.PUBLICACIONES_INCODERFIRMA = a.b.PUBLICACIONES_INCODERFIRMA;
                CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE_INCODER = a.b.PUBLICACIONES_VISIBLE_INCODER;

                CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORA = a.b.PUBLICACIONES_EMISORA;
                CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFECHA1 = a.b.PUBLICACIONES_EMISORAFECHA1;
                CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFECHA2 = a.b.PUBLICACIONES_EMISORAFECHA2;
                CaracterizacionJuridicaModel_.PUBLICACIONES_EMISORAFIRMA = a.b.PUBLICACIONES_EMISORAFIRMA;
                CaracterizacionJuridicaModel_.PUBLICACIONES_VISIBLE_EMISORA = a.b.PUBLICACIONES_VISIBLE_EMISORA;

                CaracterizacionJuridicaModel_.INSPECCION_OCULAR_VISIBLE = a.b.INSPECCION_OCULAR_VISIBLE;
                CaracterizacionJuridicaModel_.ACLARACION_DE_INSPECCION_VISIBLE = a.b.ACLARACION_DE_INSPECCION_VISIBLE;
                CaracterizacionJuridicaModel_.FIJACION_EN_LISTA_VISIBLE = a.b.FIJACION_EN_LISTA_VISIBLE;
                CaracterizacionJuridicaModel_.OPOCISIONES_EN_LISTA_VISIBLE = a.b.OPOCISIONES_EN_LISTA_VISIBLE;
                CaracterizacionJuridicaModel_.FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.b.FORMATO_DE_REVISION_JURIDICA_VISIBLE;
                CaracterizacionJuridicaModel_.RESOLUCION_VISIBLE = a.b.RESOLUCION_VISIBLE;
                CaracterizacionJuridicaModel_.NOTIFICACION_VISIBLE = a.b.NOTIFICACION_VISIBLE;
                CaracterizacionJuridicaModel_.RECURSO_SOLICITANTE_VISIBLE = a.b.RECURSO_SOLICITANTE_VISIBLE;
                CaracterizacionJuridicaModel_.RECURSO_MINISTERIO_VISIBLE = a.b.RECURSO_MINISTERIO_VISIBLE;
                CaracterizacionJuridicaModel_.CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.b.CONSTANCIA_DE_EJECUTORIA_VISIBLE;
                CaracterizacionJuridicaModel_.REVOCATORIA_VISIBLE = a.b.REVOCATORIA_VISIBLE;
                CaracterizacionJuridicaModel_.REGISTRO_VISIBLE = a.b.REGISTRO_VISIBLE;
                CaracterizacionJuridicaModel_.SOLICITUD_VISIBLE = a.b.SOLICITUD_VISIBLE;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_VISIBLE = a.b.AUTODEACEPTACION_VISIBLE;
                CaracterizacionJuridicaModel_.AUTODEACEPTACION_COLINDANTE_CORRECTO = a.b.AUTODEACEPTACION_COLINDANTE_CORRECTO;
                CaracterizacionJuridicaModel_.RESOLUCION_DATOS_SOLICITANTE_BIEN = a.b.RESOLUCION_DATOS_SOLICITANTE_BIEN;
                CaracterizacionJuridicaModel_.RESOLUCION_DATOS_SOLICITANTE_EN = a.b.RESOLUCION_DATOS_SOLICITANTE_EN;

                //SUBSIDIODEAPELACION
                CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION = a.b.SUBSIDIODEAPELACION;
                CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_VISIBLE = a.b.SUBSIDIODEAPELACION_VISIBLE;
                CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_FECHA = a.b.SUBSIDIODEAPELACION_FECHA;
                CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_RESPUESTA = a.b.SUBSIDIODEAPELACION_RESPUESTA;
                CaracterizacionJuridicaModel_.SUBSIDIODEAPELACION_DECISION = a.b.SUBSIDIODEAPELACION_DECISION;

                //DESISTIMIENTO
                CaracterizacionJuridicaModel_.DESISTIMIENTO_DESISTIMIENTO_113 = a.b.DESISTIMIENTO_DESISTIMIENTO_113;
                CaracterizacionJuridicaModel_.DESISTIMIENTO_VISIBLE = a.b.DESISTIMIENTO_VISIBLE;
                CaracterizacionJuridicaModel_.DESISTIMIENTO_FECHA = a.b.DESISTIMIENTO_FECHA;
                CaracterizacionJuridicaModel_.DESISTIMIENTO_FIRMADO = a.b.DESISTIMIENTO_FIRMADO;

                CaracterizacionJuridicaModel_.Estado = true;
                CaracterizacionJuridicaModel_.IdAspNetUser = a.b.IdAspNetUser;
                CaracterizacionJuridicaModel_.rol = a.Name;
                CaracterizacionJuridicaModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
                CaracterizacionJuridicaModel_.FechaModificacion = a.b.FechaModificacion;
                CaracterizacionJuridicaModel_.Gestion = a.b.Gestion;

            }

            return CaracterizacionJuridicaModel_;
        }

        public CaracterizacionJuridicaModel Actualizar(CaracterizacionJuridicaModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionJuridica.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.INSPECCION_OCULAR_INSPECCION_OCULAR_53;
                    ResCtx.INSPECCION_OCULAR_FECHA_54 = a.INSPECCION_OCULAR_FECHA_54;
                    ResCtx.INSPECCION_OCULAR_FIRMA_55 = a.INSPECCION_OCULAR_FIRMA_55;
                    ResCtx.INSPECCION_OCULAR_OPOSICIONES_56 = a.INSPECCION_OCULAR_OPOSICIONES_56;
                    ResCtx.INSPECCION_OCULAR_CONCEPTO_57 = a.INSPECCION_OCULAR_CONCEPTO_57;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62;
                    ResCtx.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63;
                    ResCtx.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64;
                    ResCtx.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65;
                    ResCtx.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66;
                    ResCtx.FIJACION_EN_LISTA_FIRMA_67 = a.FIJACION_EN_LISTA_FIRMA_67;
                    ResCtx.OPOCISIONES_OPOCISIONES_68 = a.OPOCISIONES_OPOCISIONES_68;
                    ResCtx.OPOCISIONES_FECHA_69 = a.OPOCISIONES_FECHA_69;
                    ResCtx.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70;
                    ResCtx.FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.FORMATO_DE_REVISION_JURIDICA_FECHA_71;
                    ResCtx.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72;
                    ResCtx.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73;


                    ResCtx.RESOLUCION_RESOLUCION_74 = a.RESOLUCION_RESOLUCION_74;
                    ResCtx.RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.RESOLUCION_NUMERO_DE_RESOLUCION_75;
                    ResCtx.RESOLUCION_FECHA_DE_RESOLUCION_76 = a.RESOLUCION_FECHA_DE_RESOLUCION_76;
                    ResCtx.RESOLUCION_FIRMADA_77 = a.RESOLUCION_FIRMADA_77;
                    ResCtx.RESOLUCION_DECISION_78 = a.RESOLUCION_DECISION_78;
                    ResCtx.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79;
                    ResCtx.RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.RESOLUCION_CONJUNTA_INDIVIDUAL_80;
                    ResCtx.NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.NOTIFICACION_NOTIFICACION_SOLICITANTES_81;
                    ResCtx.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82;
                    ResCtx.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83;
                    ResCtx.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84;
                    ResCtx.RESOLUCION_RAZON_NEGACION = a.RESOLUCION_RAZON_NEGACION;


                    ResCtx.RECURSO_SOLICITANTE_DECISION_N_1 = a.RECURSO_SOLICITANTE_DECISION_N_1;
                    ResCtx.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2;
                    ResCtx.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4;
                    ResCtx.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5;
                    ResCtx.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6;
                    ResCtx.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = a.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6;
                    ResCtx.RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = a.RECURSO_SOLICITANTE_CONJUNA_IND_N_7;
                    ResCtx.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
                    ResCtx.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
                    ResCtx.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86;
                    ResCtx.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87;
                    ResCtx.RECURSO_SOLICITANTE_FIRMADA_88 = a.RECURSO_SOLICITANTE_FIRMADA_88;
                    ResCtx.RECURSO_SOLICITANTE_ACTO_89 = a.RECURSO_SOLICITANTE_ACTO_89;
                    ResCtx.RECURSO_SOLICITANTE_NUMERO_90 = a.RECURSO_SOLICITANTE_NUMERO_90;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_91 = a.RECURSO_SOLICITANTE_FECHA_91;
                    ResCtx.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92;
                    ResCtx.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
                    ResCtx.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95;
                    ResCtx.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;

                    ResCtx.RECURSO_MINISTERIO_DECISION_N_1 = a.RECURSO_MINISTERIO_DECISION_N_1;
                    ResCtx.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = a.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2;
                    ResCtx.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = a.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3;
                    ResCtx.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = a.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4;
                    ResCtx.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = a.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5;
                    ResCtx.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = a.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6;
                    ResCtx.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = a.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6;
                    ResCtx.RECURSO_MINISTERIO_CONJUNA_IND_N_7 = a.RECURSO_MINISTERIO_CONJUNA_IND_N_7;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11;
                    ResCtx.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = a.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = a.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86;
                    ResCtx.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = a.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87;
                    ResCtx.RECURSO_MINISTERIO_FIRMADA_88 = a.RECURSO_MINISTERIO_FIRMADA_88;
                    ResCtx.RECURSO_MINISTERIO_ACTO_89 = a.RECURSO_MINISTERIO_ACTO_89;
                    ResCtx.RECURSO_MINISTERIO_NUMERO_90 = a.RECURSO_MINISTERIO_NUMERO_90;
                    ResCtx.RECURSO_MINISTERIO_FECHA_91 = a.RECURSO_MINISTERIO_FECHA_91;
                    ResCtx.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96;


                    ResCtx.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = a.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA;
                    ResCtx.REVOCATORIA_REVOCATORIA_113 = a.REVOCATORIA_REVOCATORIA_113;
                    ResCtx.REVOCATORIA_NUMERO_RESOLUCIÓN_114 = a.REVOCATORIA_NUMERO_RESOLUCION_114;
                    ResCtx.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = a.REVOCATORIA_FECHA_DE_RESOLUCION_115;
                    ResCtx.REGISTRO_FMI_ = a.REGISTRO_FMI_;
                    ResCtx.REGISTRO_FMI = a.REGISTRO_FMI;
                    ResCtx.REGISTRO_FECHA_DE_REGISTRO_117 = a.REGISTRO_FECHA_DE_REGISTRO_117;
                    ResCtx.REGISTRO_NUMERO_DE_RESOLUCION_118 = a.REGISTRO_NUMERO_DE_RESOLUCION_118;
                    ResCtx.REGISTRO_FECHA_DE_RESOLUCION_119 = a.REGISTRO_FECHA_DE_RESOLUCION_119;

                    ResCtx.SOLICITUD_SOLICITUD = a.SOLICITUD_SOLICITUD;
                    ResCtx.SOLICITUD_FECHA = a.SOLICITUD_FECHA;
                    ResCtx.SOLICITUD_FIRMA = a.SOLICITUD_FIRMA;
                    ResCtx.SOLICITUD_TIPO_SOLICITUD = a.SOLICITUD_TIPO_SOLICITUD;
                    ResCtx.SOLICITUD_CEDULA_SOLICITANTE = a.SOLICITUD_CEDULA_SOLICITANTE;
                    ResCtx.SOLICITUD_CEDULA_CONYUGE = a.SOLICITUD_CEDULA_CONYUGE;
                    ResCtx.SOLICITUD_CEDULA_PARIENTE = a.SOLICITUD_CEDULA_PARIENTE;
                    ResCtx.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = a.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA;
                    ResCtx.AUTODEACEPTACION_AUTODEACEPTACION = a.AUTODEACEPTACION_AUTODEACEPTACION;
                    ResCtx.AUTODEACEPTACION_FECHA = a.AUTODEACEPTACION_FECHA;
                    ResCtx.AUTODEACEPTACION_FIRMA = a.AUTODEACEPTACION_FIRMA;
                    ResCtx.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = a.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO;
                    ResCtx.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = a.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO;
                    ResCtx.AUTODEACEPTACION_DATOSPREDIOSCORRECTO = a.AUTODEACEPTACION_DATOSPREDIOSCORRECTO;


                    ResCtx.COMUNICACIONES_SOLICITANTE = a.COMUNICACIONES_SOLICITANTE;
                    ResCtx.COMUNICACIONES_SOLICITANTEFECHA = a.COMUNICACIONES_SOLICITANTEFECHA;
                    ResCtx.COMUNICACIONES_SOLICITANTEFIRMA = a.COMUNICACIONES_SOLICITANTEFIRMA;
                    ResCtx.COMUNICACIONES_FECHAINSPECCIONOCULAR = a.COMUNICACIONES_FECHAINSPECCIONOCULAR;
                    ResCtx.COMUNICACIONES_VISIBLE = a.COMUNICACIONES_VISIBLE;

                    ResCtx.COMUNICACIONES_PROCURADOR = a.COMUNICACIONES_PROCURADOR;
                    ResCtx.COMUNICACIONES_PROCURADORFECHA = a.COMUNICACIONES_PROCURADORFECHA;
                    ResCtx.COMUNICACIONES_PROCURADORFIRMA = a.COMUNICACIONES_PROCURADORFIRMA;
                    ResCtx.COMUNICACIONES_VISIBLE_PROCURADOR = a.COMUNICACIONES_VISIBLE_PROCURADOR;
                    
                    ResCtx.COMUNICACIONES_AUTORIDADAMBIENTAL = a.COMUNICACIONES_AUTORIDADAMBIENTAL;
                    ResCtx.COMUNICACIONES_AUTORIDADAMBIENTALFECHA = a.COMUNICACIONES_AUTORIDADAMBIENTALFECHA;
                    ResCtx.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = a.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA;
                    ResCtx.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL = a.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL;

                    ResCtx.COMUNICACIONES_COLINDATES = a.COMUNICACIONES_COLINDATES;
                    ResCtx.COMUNICACIONES_COLINDATESFECHA = a.COMUNICACIONES_COLINDATESFECHA;
                    ResCtx.COMUNICACIONES_COLINDATESFIRMA = a.COMUNICACIONES_COLINDATESFIRMA;
                    ResCtx.COMUNICACIONES_COLINDATES_INCOMPLETOS = a.COMUNICACIONES_COLINDATES_INCOMPLETOS;
                    ResCtx.COMUNICACIONES_VISIBLE_COLINDATES = a.COMUNICACIONES_VISIBLE_COLINDATES;


                    ResCtx.PUBLICACIONES_ALCALDIA = a.PUBLICACIONES_ALCALDIA;
                    ResCtx.PUBLICACIONES_ALCALDIAFECHAFIJACION = a.PUBLICACIONES_ALCALDIAFECHAFIJACION;
                    ResCtx.PUBLICACIONES_ALCALDIADESFIJACION = a.PUBLICACIONES_ALCALDIADESFIJACION;
                    ResCtx.PUBLICACIONES_ALCALDIAFIRMA = a.PUBLICACIONES_ALCALDIAFIRMA;
                    ResCtx.PUBLICACIONES_VISIBLE = a.PUBLICACIONES_VISIBLE;

                    ResCtx.PUBLICACIONES_INCODER = a.PUBLICACIONES_INCODER;
                    ResCtx.PUBLICACIONES_INCODERFECHAFIJACION = a.PUBLICACIONES_INCODERFECHAFIJACION;
                    ResCtx.PUBLICACIONES_INCODERDESFIJACION = a.PUBLICACIONES_INCODERDESFIJACION;
                    ResCtx.PUBLICACIONES_INCODERFIRMA = a.PUBLICACIONES_INCODERFIRMA;
                    ResCtx.PUBLICACIONES_VISIBLE_INCODER = a.PUBLICACIONES_VISIBLE_INCODER;

                    ResCtx.PUBLICACIONES_EMISORA = a.PUBLICACIONES_EMISORA;
                    ResCtx.PUBLICACIONES_EMISORAFECHA1 = a.PUBLICACIONES_EMISORAFECHA1;
                    ResCtx.PUBLICACIONES_EMISORAFECHA2 = a.PUBLICACIONES_EMISORAFECHA2;
                    ResCtx.PUBLICACIONES_EMISORAFIRMA = a.PUBLICACIONES_EMISORAFIRMA;
                    ResCtx.PUBLICACIONES_VISIBLE_EMISORA = a.PUBLICACIONES_VISIBLE_EMISORA;

                    ResCtx.INSPECCION_OCULAR_VISIBLE = a.INSPECCION_OCULAR_VISIBLE;
                    ResCtx.ACLARACION_DE_INSPECCION_VISIBLE = a.ACLARACION_DE_INSPECCION_VISIBLE;
                    ResCtx.FIJACION_EN_LISTA_VISIBLE = a.FIJACION_EN_LISTA_VISIBLE;
                    ResCtx.OPOCISIONES_EN_LISTA_VISIBLE = a.OPOCISIONES_EN_LISTA_VISIBLE;
                    ResCtx.FORMATO_DE_REVISION_JURIDICA_VISIBLE = a.FORMATO_DE_REVISION_JURIDICA_VISIBLE;
                    ResCtx.RESOLUCION_VISIBLE = a.RESOLUCION_VISIBLE;
                    ResCtx.NOTIFICACION_VISIBLE = a.NOTIFICACION_VISIBLE;
                    ResCtx.RECURSO_SOLICITANTE_VISIBLE = a.RECURSO_SOLICITANTE_VISIBLE;
                    ResCtx.RECURSO_MINISTERIO_VISIBLE = a.RECURSO_MINISTERIO_VISIBLE;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_VISIBLE = a.CONSTANCIA_DE_EJECUTORIA_VISIBLE;
                    ResCtx.REVOCATORIA_VISIBLE = a.REVOCATORIA_VISIBLE;
                    ResCtx.REGISTRO_VISIBLE = a.REGISTRO_VISIBLE;
                    ResCtx.SOLICITUD_VISIBLE = a.SOLICITUD_VISIBLE;
                    ResCtx.AUTODEACEPTACION_VISIBLE = a.AUTODEACEPTACION_VISIBLE;
                    ResCtx.RESOLUCION_DATOS_SOLICITANTE_BIEN = a.RESOLUCION_DATOS_SOLICITANTE_BIEN;
                    ResCtx.RESOLUCION_DATOS_SOLICITANTE_EN = a.RESOLUCION_DATOS_SOLICITANTE_EN;
                    ResCtx.AUTODEACEPTACION_COLINDANTE_CORRECTO = a.AUTODEACEPTACION_COLINDANTE_CORRECTO;

                    //SUBSIDIODEAPELACION
                    ResCtx.SUBSIDIODEAPELACION = a.SUBSIDIODEAPELACION;
                    ResCtx.SUBSIDIODEAPELACION_VISIBLE = a.SUBSIDIODEAPELACION_VISIBLE;
                    ResCtx.SUBSIDIODEAPELACION_FECHA = a.SUBSIDIODEAPELACION_FECHA;
                    ResCtx.SUBSIDIODEAPELACION_RESPUESTA = a.SUBSIDIODEAPELACION_RESPUESTA;
                    ResCtx.SUBSIDIODEAPELACION_DECISION = a.SUBSIDIODEAPELACION_DECISION;

                    //DESISTIMIENTO
                    ResCtx.DESISTIMIENTO_DESISTIMIENTO_113 = a.DESISTIMIENTO_DESISTIMIENTO_113;
                    ResCtx.DESISTIMIENTO_VISIBLE = a.DESISTIMIENTO_VISIBLE;
                    ResCtx.DESISTIMIENTO_FECHA = a.DESISTIMIENTO_FECHA;
                    ResCtx.DESISTIMIENTO_FIRMADO = a.DESISTIMIENTO_FIRMADO;

                    ResCtx.FechaModificacion = DateTime.Now;
                    ResCtx.Gestion = 1;
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