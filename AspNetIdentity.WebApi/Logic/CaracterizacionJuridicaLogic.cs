﻿using AspNetIdentity.Models;
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
                    RECURSO_MINISTERIO_RECURSO_MINISTERIO_97 = a.RECURSO_MINISTERIO_RECURSO_MINISTERIO_97,
                    RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98 = a.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98,
                    RECURSO_MINISTERIO_RESPUESTA_RECURSO_99 = a.RECURSO_MINISTERIO_RESPUESTA_RECURSO_99,
                    RECURSO_MINISTERIO_FIRMADA_100 = a.RECURSO_MINISTERIO_FIRMADA_100,
                    RECURSO_MINISTERIO_ACTO_101 = a.RECURSO_MINISTERIO_ACTO_101,
                    RECURSO_MINISTERIO_NUMERO_102 = a.RECURSO_MINISTERIO_NUMERO_102,
                    RECURSO_MINISTERIO_FECHA_103 = a.RECURSO_MINISTERIO_FECHA_103,
                    RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104,
                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106,
                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108,
                    CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,
                    CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,
                    CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,
                    CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,
                    REVOCATORIA_REVOCATORIA_113 = a.REVOCATORIA_REVOCATORIA_113,
                    REVOCATORIA_NUMERO_RESOLUCIÓN_114 = a.REVOCATORIA_NUMERO_RESOLUCION_114,
                    REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = a.REVOCATORIA_FECHA_DE_RESOLUCION_115,
                    REGISTRO_FMI_116 = a.REGISTRO_FMI_116,
                    REGISTRO_FECHA_DE_REGISTRO_117 = a.REGISTRO_FECHA_DE_REGISTRO_117,
                    REGISTRO_NUMERO_DE_RESOLUCION_118 = a.REGISTRO_NUMERO_DE_RESOLUCION_118,
                    REGISTRO_FECHA_DE_RESOLUCION_119 = a.REGISTRO_FECHA_DE_RESOLUCION_119,
                    Estado = true,
                    IdAspNetUser = a.IdAspNetUser,
                    FechaModificacion = DateTime.Now


                };

                Ctx.CaracterizacionJuridica.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        //public List<CaracterizacionJuridicaModel> Consulta(string id)
        //{
        //    ZonasFEntities Ctx = new ZonasFEntities();
        //    var lista = Ctx.CaracterizacionJuridica.Where(x => x.Estado == true && x.IdAspNetUser == id)
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.INSPECCION_OCULAR_CONCEPTO_57, d => d.Id, (b, d) => new { b.b, b.c, d })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61, e => e.Id, (b, e) => new { b.b, b.c, b.d, e })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73, f => f.Id, (b, f) => new { b.b, b.c, b.d, b.e, f })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RESOLUCION_DECISION_78, g => g.Id, (b, g) => new { b.b, b.c, b.d, b.e, b.f, g })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80, h => h.Id, (b, h) => new { b.b, b.c, b.d, b.e, b.f, b.g, h })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_SOLICITANTE_ACTO_89, i => i.Id, (b, i) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, i })
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92, j => j.Id, (b, j) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, j})
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_MINISTERIO_ACTO_101, k => k.Id, (b, k) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, b.j, k})
        //        .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104, l => l.Id, (b, l) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, b.j, b.k, l})
        //        .Select(a => new CaracterizacionJuridicaModel
        //    {
        //        Id = a.b.Id,
        //        IdExpediente = a.b.IdExpediente,
        //        INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.b.INSPECCION_OCULAR_INSPECCION_OCULAR_53,
        //        INSPECCION_OCULAR_FECHA_54 = a.b.INSPECCION_OCULAR_FECHA_54,
        //        INSPECCION_OCULAR_FIRMA_55 = a.b.INSPECCION_OCULAR_FIRMA_55,
        //        INSPECCION_OCULAR_OPOSICIONES_56 = a.b.INSPECCION_OCULAR_OPOSICIONES_56,
        //        INSPECCION_OCULAR_CONCEPTO_57 = a.b.INSPECCION_OCULAR_CONCEPTO_57,
        //        NombreINSPECCION_OCULAR_CONCEPTO_57 = a.d.Nombre,
        //        ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.b.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58,
        //        ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59,
        //        ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60,
        //        ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,
        //        NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.e.Nombre,
        //        ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.b.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62,
        //        ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63,
        //        FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.b.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64,
        //        FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.b.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65,
        //        FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.b.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66,
        //        FIJACION_EN_LISTA_FIRMA_67 = a.b.FIJACION_EN_LISTA_FIRMA_67,
        //        OPOCISIONES_OPOCISIONES_68 = a.b.OPOCISIONES_OPOCISIONES_68,
        //        OPOCISIONES_FECHA_69 = a.b.OPOCISIONES_FECHA_69,
        //        FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.b.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70,
        //        FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.b.FORMATO_DE_REVISION_JURIDICA_FECHA_71,
        //        FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.b.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72,
        //        FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,
        //        NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.f.Nombre,
        //        RESOLUCION_RESOLUCION_74 = a.b.RESOLUCION_RESOLUCION_74,
        //        RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.b.RESOLUCION_NUMERO_DE_RESOLUCION_75,
        //        RESOLUCION_FECHA_DE_RESOLUCION_76 = a.b.RESOLUCION_FECHA_DE_RESOLUCION_76,
        //        RESOLUCION_FIRMADA_77 = a.b.RESOLUCION_FIRMADA_77,
        //        RESOLUCION_DECISION_78 = a.b.RESOLUCION_DECISION_78,
        //        NombreRESOLUCION_DECISION_78 = a.g.Nombre,
        //        RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.b.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79,
        //        NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.h.Nombre,
        //        RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80,
        //        NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.b.NOTIFICACION_NOTIFICACION_SOLICITANTES_81,
        //        NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82,
        //        NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.b.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83,
        //        NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84,
        //        RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.b.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85,
        //        RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86,
        //        RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.b.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87,
        //        RECURSO_SOLICITANTE_FIRMADA_88 = a.b.RECURSO_SOLICITANTE_FIRMADA_88,
        //        RECURSO_SOLICITANTE_ACTO_89 = a.b.RECURSO_SOLICITANTE_ACTO_89,
        //        NombreRECURSO_SOLICITANTE_ACTO_89 = a.i.Nombre,
        //        RECURSO_SOLICITANTE_NUMERO_90 = a.b.RECURSO_SOLICITANTE_NUMERO_90,
        //        RECURSO_SOLICITANTE_FECHA_91 = a.b.RECURSO_SOLICITANTE_FECHA_91,
        //        RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,
        //        NombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.Nombre,
        //        RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93,
        //        RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
        //        RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95,
        //        RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,
        //        RECURSO_MINISTERIO_RECURSO_MINISTERIO_97 = a.b.RECURSO_MINISTERIO_RECURSO_MINISTERIO_97,
        //        RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98 = a.b.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98,
        //        RECURSO_MINISTERIO_RESPUESTA_RECURSO_99 = a.b.RECURSO_MINISTERIO_RESPUESTA_RECURSO_99,
        //        RECURSO_MINISTERIO_FIRMADA_100 = a.b.RECURSO_MINISTERIO_FIRMADA_100,
        //        RECURSO_MINISTERIO_ACTO_101 = a.b.RECURSO_MINISTERIO_ACTO_101,
        //        NombreRECURSO_MINISTERIO_ACTO_101 = a.k.Nombre,
        //        RECURSO_MINISTERIO_NUMERO_102 = a.b.RECURSO_MINISTERIO_NUMERO_102,
        //        RECURSO_MINISTERIO_FECHA_103 = a.b.RECURSO_MINISTERIO_FECHA_103,
        //        RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104,
        //        NombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.l.Nombre,
        //        RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105,
        //        RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106,
        //        RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107,
        //        RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108,
        //        CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.b.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,
        //        CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.b.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,
        //        CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.b.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,
        //        CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.b.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,
        //        REVOCATORIA_REVOCATORIA_113 = a.b.REVOCATORIA_REVOCATORIA_113,
        //        REVOCATORIA_NUMERO_RESOLUCION_114 = a.b.REVOCATORIA_NUMERO_RESOLUCION_114,
        //        REVOCATORIA_FECHA_DE_RESOLUCION_115 = a.b.REVOCATORIA_FECHA_DE_RESOLUCION_115,
        //        REGISTRO_FMI_116 = a.b.REGISTRO_FMI_116,
        //        REGISTRO_FECHA_DE_REGISTRO_117 = a.b.REGISTRO_FECHA_DE_REGISTRO_117,
        //        REGISTRO_NUMERO_DE_RESOLUCION_118 = a.b.REGISTRO_NUMERO_DE_RESOLUCION_118,
        //        REGISTRO_FECHA_DE_RESOLUCION_119 = a.b.REGISTRO_FECHA_DE_RESOLUCION_119,
        //        Estado = true,
        //        IdAspNetUser = a.b.IdAspNetUser,
        //        NombreIdAspNetUser = a.c.Name+" "+ a.c.FirstName + " " +a.c.LastName,
        //        FechaModificacion = a.b.FechaModificacion.ToString()


        //    });

        //    return lista.ToList();
        //}

        public List<BaldiosPersonaNaturalModel> Consulta(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
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
                    NombrePredio = c.b.b.NombrePredio,
                    NombreBeneficiario = c.b.b.NombreBeneficiario,
                    IdTipoIdentificacion = c.b.b.IdTipoIdentificacion,
                    Identificacion = c.b.b.Identificacion,
                    IdGenero = c.b.b.IdGenero,
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
                    NombreIdGenero = c.NombreGenero,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                }).OrderByDescending(d => d.EstadoCaracterizacion);

            #endregion
            return lista.ToList();
        }

        public CaracterizacionJuridicaModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            CaracterizacionJuridicaModel  lista = Ctx.CaracterizacionJuridica.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.INSPECCION_OCULAR_CONCEPTO_57, d => d.Id, (b, d) => new { b.Name, b.b, b.c, d })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61, e => e.Id, (b, e) => new { b.Name, b.b, b.c, b.d, e })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73, f => f.Id, (b, f) => new { b.Name, b.b, b.c, b.d, b.e, f })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RESOLUCION_DECISION_78, g => g.Id, (b, g) => new { b.Name, b.b, b.c, b.d, b.e, b.f, g })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80, h => h.Id, (b, h) => new { b.Name, b.b, b.c, b.d, b.e, b.f, b.g, h })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_SOLICITANTE_ACTO_89, i => i.Id, (b, i) => new { b.Name, b.b, b.c, b.d, b.e, b.f, b.g, b.h, i })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92, j => j.Id, (b, j) => new { b.Name, b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, j })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_MINISTERIO_ACTO_101, k => k.Id, (b, k) => new { b.Name, b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, b.j, k })
                .Join(Ctx.CaracterizacionJuridicaCatalogos, b => b.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104, l => l.Id, (b, l) => new { b.Name, b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, b.j, b.k, l })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new {b.l,ll.NumeroExpediente, b.Name, b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, b.j, b.k, ll })
                .Select(a => new CaracterizacionJuridicaModel
                {
                    Id = a.b.Id,
                    IdExpediente = a.b.IdExpediente,
                    NumeroExpediente = a.NumeroExpediente,
                    INSPECCION_OCULAR_INSPECCION_OCULAR_53 = a.b.INSPECCION_OCULAR_INSPECCION_OCULAR_53.Value,
                    INSPECCION_OCULAR_FECHA_54 = a.b.INSPECCION_OCULAR_FECHA_54.Value,
                    INSPECCION_OCULAR_FIRMA_55 = a.b.INSPECCION_OCULAR_FIRMA_55.Value,
                    INSPECCION_OCULAR_OPOSICIONES_56 = a.b.INSPECCION_OCULAR_OPOSICIONES_56.Value,
                    INSPECCION_OCULAR_CONCEPTO_57 = a.b.INSPECCION_OCULAR_CONCEPTO_57.Value,
                    NombreINSPECCION_OCULAR_CONCEPTO_57 = a.d.Nombre,
                    ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = a.b.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58.Value,
                    ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59.Value,
                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60.Value,
                    ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.b.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61.Value,
                    NombreACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = a.e.Nombre,
                    ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = a.b.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62.Value,
                    ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = a.b.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63.Value,
                    FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = a.b.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64.Value,
                    FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = a.b.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65.Value,
                    FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = a.b.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66.Value,
                    FIJACION_EN_LISTA_FIRMA_67 = a.b.FIJACION_EN_LISTA_FIRMA_67.Value,
                    OPOCISIONES_OPOCISIONES_68 = a.b.OPOCISIONES_OPOCISIONES_68.Value,
                    OPOCISIONES_FECHA_69 = a.b.OPOCISIONES_FECHA_69.Value,
                    FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = a.b.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70.Value,
                    FORMATO_DE_REVISION_JURIDICA_FECHA_71 = a.b.FORMATO_DE_REVISION_JURIDICA_FECHA_71.Value,
                    FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = a.b.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72.Value,
                    FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.b.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73.Value,
                    NombreFORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = a.f.Nombre,
                    RESOLUCION_RESOLUCION_74 = a.b.RESOLUCION_RESOLUCION_74.Value,
                    RESOLUCION_NUMERO_DE_RESOLUCION_75 = a.b.RESOLUCION_NUMERO_DE_RESOLUCION_75.Value,
                    RESOLUCION_FECHA_DE_RESOLUCION_76 = a.b.RESOLUCION_FECHA_DE_RESOLUCION_76.Value,
                    RESOLUCION_FIRMADA_77 = a.b.RESOLUCION_FIRMADA_77.Value,
                    RESOLUCION_DECISION_78 = a.b.RESOLUCION_DECISION_78.Value,
                    NombreRESOLUCION_DECISION_78 = a.g.Nombre,
                    RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = a.b.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79.Value,
                    NombreRESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.h.Nombre,
                    RESOLUCION_CONJUNTA_INDIVIDUAL_80 = a.b.RESOLUCION_CONJUNTA_INDIVIDUAL_80.Value,
                    NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = a.b.NOTIFICACION_NOTIFICACION_SOLICITANTES_81.Value,
                    NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82.Value,
                    NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = a.b.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83.Value,
                    NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = a.b.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84.Value,
                    RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = a.b.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85.Value,
                    RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = a.b.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86.Value,
                    RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = a.b.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87.Value,
                    RECURSO_SOLICITANTE_FIRMADA_88 = a.b.RECURSO_SOLICITANTE_FIRMADA_88.Value,
                    RECURSO_SOLICITANTE_ACTO_89 = a.b.RECURSO_SOLICITANTE_ACTO_89.Value,
                    NombreRECURSO_SOLICITANTE_ACTO_89 = a.i.Nombre,
                    RECURSO_SOLICITANTE_NUMERO_90 = a.b.RECURSO_SOLICITANTE_NUMERO_90.Value,
                    RECURSO_SOLICITANTE_FECHA_91 = a.b.RECURSO_SOLICITANTE_FECHA_91.Value,
                    RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.b.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92.Value,
                    NombreRECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = a.j.Nombre,
                    RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93.Value,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94.Value,
                    RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = a.b.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95.Value,
                    RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = a.b.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96.Value,
                    RECURSO_MINISTERIO_RECURSO_MINISTERIO_97 = a.b.RECURSO_MINISTERIO_RECURSO_MINISTERIO_97.Value,
                    RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98 = a.b.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98.Value,
                    RECURSO_MINISTERIO_RESPUESTA_RECURSO_99 = a.b.RECURSO_MINISTERIO_RESPUESTA_RECURSO_99.Value,
                    RECURSO_MINISTERIO_FIRMADA_100 = a.b.RECURSO_MINISTERIO_FIRMADA_100.Value,
                    RECURSO_MINISTERIO_ACTO_101 = a.b.RECURSO_MINISTERIO_ACTO_101.Value,
                    NombreRECURSO_MINISTERIO_ACTO_101 = a.k.Nombre,
                    RECURSO_MINISTERIO_NUMERO_102 = a.b.RECURSO_MINISTERIO_NUMERO_102.Value,
                    RECURSO_MINISTERIO_FECHA_103 = a.b.RECURSO_MINISTERIO_FECHA_103.Value,
                    RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.b.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104.Value,
                    NombreRECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.l.Nombre,
                    RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105 = a.b.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105.Value,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106.Value,
                    RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107 = a.b.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107.Value,
                    RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108 = a.b.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108.Value,
                    CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.b.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109.Value,
                    CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.b.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110.Value,
                    CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.b.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111.Value,
                    CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.b.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112.Value,
                    REVOCATORIA_REVOCATORIA_113 = a.b.REVOCATORIA_REVOCATORIA_113.Value,
                    REVOCATORIA_NUMERO_RESOLUCION_114 = a.b.REVOCATORIA_NUMERO_RESOLUCIÓN_114.Value,
                    REVOCATORIA_FECHA_DE_RESOLUCION_115 = a.b.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115.Value,
                    REGISTRO_FMI_116 = a.b.REGISTRO_FMI_116,
                    REGISTRO_FECHA_DE_REGISTRO_117 = a.b.REGISTRO_FECHA_DE_REGISTRO_117.Value,
                    REGISTRO_NUMERO_DE_RESOLUCION_118 = a.b.REGISTRO_NUMERO_DE_RESOLUCION_118.Value,
                    REGISTRO_FECHA_DE_RESOLUCION_119 = a.b.REGISTRO_FECHA_DE_RESOLUCION_119.Value,
                    Estado = true,
                    IdAspNetUser = a.b.IdAspNetUser,
                    rol = a.Name,
                    NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName,
                    FechaModificacion = a.b.FechaModificacion.ToString()
                }).FirstOrDefault();
            
            if (lista == null)
            {
                lista = Ctx.CaracterizacionJuridica.Where(x => x.Id == id)
               .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
               .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b,b.c })
               .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new {  b.b, b.c, c.Name })
               .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new { b.b, b.c, b.Name, ll.NumeroExpediente })

               .Select(a => new CaracterizacionJuridicaModel
               {
                   Id = a.b.Id,
                   IdAspNetUser = a.b.IdAspNetUser,
                   IdExpediente = a.b.IdExpediente,
                   NumeroExpediente = a.NumeroExpediente,
                   NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName,
                   rol = a.Name,
                   FechaModificacion = a.b.FechaModificacion.ToString()
               }).FirstOrDefault();
            }

            return lista;
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
                    ResCtx.RECURSO_MINISTERIO_RECURSO_MINISTERIO_97 = a.RECURSO_MINISTERIO_RECURSO_MINISTERIO_97;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98 = a.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_98;
                    ResCtx.RECURSO_MINISTERIO_RESPUESTA_RECURSO_99 = a.RECURSO_MINISTERIO_RESPUESTA_RECURSO_99;
                    ResCtx.RECURSO_MINISTERIO_FIRMADA_100 = a.RECURSO_MINISTERIO_FIRMADA_100;
                    ResCtx.RECURSO_MINISTERIO_ACTO_101 = a.RECURSO_MINISTERIO_ACTO_101;
                    ResCtx.RECURSO_MINISTERIO_NUMERO_102 = a.RECURSO_MINISTERIO_NUMERO_102;
                    ResCtx.RECURSO_MINISTERIO_FECHA_103 = a.RECURSO_MINISTERIO_FECHA_103;
                    ResCtx.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104 = a.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_104;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105 = a.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_105;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_106;
                    ResCtx.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107 = a.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_107;
                    ResCtx.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108 = a.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_108;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = a.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = a.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = a.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111;
                    ResCtx.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = a.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112;
                    ResCtx.REVOCATORIA_REVOCATORIA_113 = a.REVOCATORIA_REVOCATORIA_113;
                    ResCtx.REVOCATORIA_NUMERO_RESOLUCIÓN_114 = a.REVOCATORIA_NUMERO_RESOLUCION_114;
                    ResCtx.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = a.REVOCATORIA_FECHA_DE_RESOLUCION_115;
                    ResCtx.REGISTRO_FMI_116 = a.REGISTRO_FMI_116;
                    ResCtx.REGISTRO_FECHA_DE_REGISTRO_117 = a.REGISTRO_FECHA_DE_REGISTRO_117;
                    ResCtx.REGISTRO_NUMERO_DE_RESOLUCION_118 = a.REGISTRO_NUMERO_DE_RESOLUCION_118;
                    ResCtx.REGISTRO_FECHA_DE_RESOLUCION_119 = a.REGISTRO_FECHA_DE_RESOLUCION_119;
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