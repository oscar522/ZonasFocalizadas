using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class AdministratorLogic
    {
        BaldiosPersonaNatural ModCtx = new BaldiosPersonaNatural();

        public List<CtCiudadModel> ConsultarIdPCountDepto()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            //var Expedientes = Ctx.BaldiosPersonaNatural.ToList();

            var MunicipiosFocalidas = Ctx.BaldiosPersonaNatural
                .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new { c.ID_CT_DEPTO, NOMBRE_DEPTO = c.NOMBRE, MuniExp = b.IdCiudad, DeptoExp = b.IdDepto, b.RutaVerificado })
                .Join(Ctx.CtCiudad, b => b.MuniExp, c => c.IdCtMuncipio, (b, c) =>
                 new
                 {
                     Muni_id = c.Id,
                     Muni_IdCtMuncipio = c.IdCtMuncipio,
                     Muni_IdCtDepto = c.IdCtDepto,
                     Muni_NOMBRE_DEPTO = b.NOMBRE_DEPTO,
                     Muni_Nombre = c.Nombre,
                     Muni_ZonaFocalizada = c.ZonaFocalizada,
                     b.MuniExp,
                     b.DeptoExp,
                     b.RutaVerificado
                 })
                .Where(x => x.Muni_ZonaFocalizada == true && x.Muni_IdCtDepto == x.DeptoExp)
                .GroupBy(x => x.Muni_id)
                .Select(c => new CtCiudadModel
                {
                    id = c.Select(v => v.Muni_id).FirstOrDefault(),
                    IdCtMuncipio = c.Select(v => v.Muni_IdCtMuncipio).FirstOrDefault(),
                    Nombre = c.Select(v => v.Muni_Nombre).FirstOrDefault(),
                    IdCtDepto = c.Select(v => v.Muni_IdCtDepto).FirstOrDefault(),
                    NOMBRE_DEPTO = c.Select(v => v.Muni_NOMBRE_DEPTO).FirstOrDefault(),
                    IdCtPais = c.Count(),
                    NOMBRE_PAIS = "",
                })
                .ToList();

            List<CtCiudadModel> listaModel = new List<CtCiudadModel>();

            foreach (var Model in MunicipiosFocalidas)
            {

                var NumeroPdf = Ctx.BaldiosPersonaNatural
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && x.IdDepto == Model.IdCtDepto
                                    && x.RutaVerificado == 1).Count().ToString();

                var NumeroTipificacion = Ctx.BaldiosPersonaNatural
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                   && Model.IdCtDepto == Model.IdCtDepto
                                   && x.EstadoCaracterizacion == true && x.RutaVerificado == 1).Count().ToString();

                var NumeroAsociados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado })
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && Model.IdCtDepto == Model.IdCtDepto && x.RutaVerificado == 1).Count().ToString();

                var Malnombrados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.ArchivoVerificado })
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && Model.IdCtDepto == Model.IdCtDepto && x.RutaVerificado == 1 && x.ArchivoVerificado == 2).Count().ToString();


                Model.NOMBRE_PAIS = NumeroPdf + "-" + NumeroTipificacion + "-" + NumeroAsociados + "-" + Malnombrados;

                listaModel.Add(Model);
            }
            return listaModel;
        }
        public List<BaldiosPersonaNaturalModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.BaldiosPersonaNatural
                .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     NombrDepto = c.NOMBRE
                 })
                .Join(Ctx.CtCiudad, b => b.IdCiudad, c => c.IdCtMuncipio, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     b.NombrDepto,
                     NombreMunicipio = c.Nombre
                 })
                .Join(Ctx.CtTipoIdentificacion, b => b.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     b.NombrDepto,
                     b.NombreMunicipio,
                     NombreTipoIdentificacion = c.NOMBRE
                 })
                .Join(Ctx.CtGenero, b => b.IdGenero, c => c.ID_GENERO, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     b.NombrDepto,
                     b.NombreMunicipio,
                     b.NombreTipoIdentificacion,
                     NombreGenero = c.NOMBRE
                 })
                .Join(Ctx.CtTipoIdentificacion, b => b.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     b.NombrDepto,
                     b.NombreMunicipio,
                     b.NombreTipoIdentificacion,
                     b.NombreGenero,
                     NombreTipoIdentificacionConyuge = c.NOMBRE
                 })
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.id,
                    NumeroExpediente = c.NumeroExpediente,
                    IdDepto = c.IdDepto,
                    IdCiudad = c.IdCiudad,
                    Vereda = c.Vereda,
                    NombrePredio = c.NombrePredio,
                    NombreBeneficiario = c.NombreBeneficiario,
                    IdTipoIdentificacion = c.IdTipoIdentificacion,
                    Identificacion = c.Identificacion,
                    IdGenero = c.IdGenero,
                    IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.IdentificacionConyuge,
                    NombreConyuge = c.NombreConyuge,
                    EstadoInicialMigracion = c.EstadoInicialMigracion,
                    IdAspNetUser = c.IdAspNetUser,
                    EstadoCaracterizacion = c.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdGenero = c.NombreGenero,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                });

            return lista.ToList();
        }

        public List<BaldiosPersonaNaturalModel> ConsultarIdP(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Where(w => w.IdAspNetUser == IdP).ToList();
            #region Sql
            var lista = listaBaldios
                //.Where(w => w.IdAspNetUser == IdP)
                .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     NombrDepto = c.NOMBRE
                 })
                .Join(Ctx.CtCiudad, d => d.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                 new
                 {
                     d.id,
                     d.NumeroExpediente,
                     d.IdDepto,
                     d.IdCiudad,
                     d.Vereda,
                     d.NombrePredio,
                     d.NombreBeneficiario,
                     d.IdTipoIdentificacion,
                     d.Identificacion,
                     d.IdGenero,
                     d.IdTipoIdentificacionConyuge,
                     d.IdentificacionConyuge,
                     d.NombreConyuge,
                     d.EstadoInicialMigracion,
                     d.IdAspNetUser,
                     d.EstadoCaracterizacion,
                     d.RutaArchivoOriginal,
                     d.NombrDepto,
                     NombreMunicipio = e.Nombre,
                     MunicipioIdDepto = e.IdCtDepto
                 })
                .Join(Ctx.CtTipoIdentificacion, f => f.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                 new
                 {
                     f.id,
                     f.NumeroExpediente,
                     f.IdDepto,
                     f.IdCiudad,
                     f.Vereda,
                     f.NombrePredio,
                     f.NombreBeneficiario,
                     f.IdTipoIdentificacion,
                     f.Identificacion,
                     f.IdGenero,
                     f.IdTipoIdentificacionConyuge,
                     f.IdentificacionConyuge,
                     f.NombreConyuge,
                     f.EstadoInicialMigracion,
                     f.IdAspNetUser,
                     f.EstadoCaracterizacion,
                     f.RutaArchivoOriginal,
                     f.NombrDepto,
                     f.NombreMunicipio,
                     NombreTipoIdentificacion = g.NOMBRE,
                     f.MunicipioIdDepto
                 })
                .Join(Ctx.CtGenero, h => h.IdGenero, i => i.ID_GENERO, (h, i) =>
                 new
                 {
                     h.id,
                     h.NumeroExpediente,
                     h.IdDepto,
                     h.IdCiudad,
                     h.Vereda,
                     h.NombrePredio,
                     h.NombreBeneficiario,
                     h.IdTipoIdentificacion,
                     h.Identificacion,
                     h.IdGenero,
                     h.IdTipoIdentificacionConyuge,
                     h.IdentificacionConyuge,
                     h.NombreConyuge,
                     h.EstadoInicialMigracion,
                     h.IdAspNetUser,
                     h.EstadoCaracterizacion,
                     h.RutaArchivoOriginal,
                     h.NombrDepto,
                     h.NombreMunicipio,
                     h.NombreTipoIdentificacion,
                     h.MunicipioIdDepto,
                     NombreGenero = i.NOMBRE
                 })
                .Join(Ctx.CtTipoIdentificacion, j => j.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new
                 {
                     j.id,
                     j.NumeroExpediente,
                     j.IdDepto,
                     j.IdCiudad,
                     j.Vereda,
                     j.NombrePredio,
                     j.NombreBeneficiario,
                     j.IdTipoIdentificacion,
                     j.Identificacion,
                     j.IdGenero,
                     j.IdTipoIdentificacionConyuge,
                     j.IdentificacionConyuge,
                     j.NombreConyuge,
                     j.EstadoInicialMigracion,
                     j.IdAspNetUser,
                     j.EstadoCaracterizacion,
                     j.RutaArchivoOriginal,
                     j.NombrDepto,
                     j.NombreMunicipio,
                     j.NombreTipoIdentificacion,
                     j.MunicipioIdDepto,
                     j.NombreGenero,
                     NombreTipoIdentificacionConyuge = k.NOMBRE
                 })
                 .Where(w => w.MunicipioIdDepto == w.IdDepto)
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.id,
                    NumeroExpediente = c.NumeroExpediente,
                    IdDepto = c.IdDepto,
                    IdCiudad = c.IdCiudad,
                    Vereda = c.Vereda,
                    NombrePredio = c.NombrePredio,
                    NombreBeneficiario = c.NombreBeneficiario,
                    IdTipoIdentificacion = c.IdTipoIdentificacion,
                    Identificacion = c.Identificacion,
                    IdGenero = c.IdGenero,
                    IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.IdentificacionConyuge,
                    NombreConyuge = c.NombreConyuge,
                    EstadoInicialMigracion = c.EstadoInicialMigracion,
                    IdAspNetUser = c.IdAspNetUser,
                    EstadoCaracterizacion = c.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdGenero = c.NombreGenero,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                });

            #endregion
            return lista.ToList();
        }

        public List<ResumenTipificacionModel> ConsultarResumen(string IdP)
        {
            var Resumen = new List<ResumenTipificacionModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                var Ubicacion = context.CtCiudad.Join(context.CtDepto, l => l.IdCtDepto, m => m.ID_CT_DEPTO, (l, m) => new
                { Ciudad = l.Nombre, Depto = m.NOMBRE, l.IdCtDepto, l.IdCtMuncipio })
                    .Where(x => x.IdCtDepto == IdDepto && x.IdCtMuncipio == IdCiudad).FirstOrDefault();

                Resumen = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser)
                            .Select(c => new ResumenTipificacionModel
                            {
                                Id = c.Id,
                                IdExpediente = c.IdExpediente,
                                IdAspNetUser = c.IdAspNetUser,
                                Grupo = c.Grupo,
                                Plano = context.ExpedienteDocumentos.Where(x => x.IdExpediente == c.IdExpediente && x.IdRetencionDocumental == 21).Select(y => y.IdRetencionDocumental).FirstOrDefault(),
                                Orden = c.Orden,
                                Depto = Ubicacion.Depto,
                                IdDepto = Ubicacion.IdCtDepto,
                                Municipio = Ubicacion.Ciudad,
                                IdMunicipio = Ubicacion.IdCtMuncipio
                            }).ToList();

                var PlanoAgrupado = Resumen.GroupBy(z => z.Grupo);

                var Plano = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser)
                           .Join(context.ExpedienteDocumentos, l => l.IdExpediente, m => m.IdExpediente, (l, m) => new { m, m.Estado, l.Grupo, l.IdExpediente, m.IdRetencionDocumental })
                           .Where(x => x.IdExpediente == x.IdExpediente && x.IdRetencionDocumental == 21 && x.Estado == true && x.Grupo.Equals("Decide Adjudica")).ToList();


            }
            return Resumen;
        }

        public List<BaldiosPersonaNaturalModel> ConsultarResumenLista(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                var InforPl = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser).Where(x => x.Grupo == Grupo).ToList();

                var Baldios = InforPl
                    .Join(context.BaldiosPersonaNatural, l => l.IdExpediente, m => m.id, (l, m) => new
                    {
                        m.id,
                        m.NumeroExpediente,
                        m.IdDepto,
                        m.IdCiudad,
                        m.Vereda,
                        m.NombrePredio,
                        m.NombreBeneficiario,
                        m.IdTipoIdentificacion,
                        m.Identificacion,
                        m.IdGenero,
                        m.IdTipoIdentificacionConyuge,
                        m.IdentificacionConyuge,
                        m.NombreConyuge,
                        m.EstadoInicialMigracion,
                        m.IdAspNetUser,
                        m.EstadoCaracterizacion,
                        m.RutaArchivoOriginal
                    }).ToList();

                var DeptoBal = Baldios
                    .Join(context.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        NombrDepto = c.NOMBRE
                    }).Where(v => v.IdDepto == IdDepto).ToList();

                var CiudadBal = DeptoBal
                    .Join(context.CtCiudad, b => b.IdCiudad, c => c.IdCtMuncipio, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        NombreMunicipio = c.Nombre,
                        IdMunicipioCiudad = c.IdCtMuncipio,
                        IdDeptoCiudad = c.IdCtDepto
                    }).Where(v => v.IdCiudad == IdCiudad && v.IdDeptoCiudad == IdDepto).ToList();

                var TipoIdBal = CiudadBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        NombreTipoIdentificacion = c.NOMBRE
                    }).ToList();

                var GeneroBal = TipoIdBal
                    .Join(context.CtGenero, b => b.IdGenero, c => c.ID_GENERO, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        NombreGenero = c.NOMBRE
                    }).ToList();

                var TipoIdConyugeBal = GeneroBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        b.NombreGenero,
                        NombreTipoIdentificacionConyuge = c.NOMBRE
                    }).ToList();

                Resumen = TipoIdConyugeBal
                    .Select(c => new BaldiosPersonaNaturalModel
                    {
                        id = c.id,
                        NumeroExpediente = c.NumeroExpediente,
                        IdDepto = c.IdDepto,
                        IdCiudad = c.IdCiudad,
                        Vereda = c.Vereda,
                        NombrePredio = c.NombrePredio,
                        NombreBeneficiario = c.NombreBeneficiario,
                        IdTipoIdentificacion = c.IdTipoIdentificacion,
                        Identificacion = c.Identificacion,
                        IdGenero = c.IdGenero,
                        IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = c.IdentificacionConyuge,
                        NombreConyuge = c.NombreConyuge,
                        EstadoInicialMigracion = c.EstadoInicialMigracion,
                        IdAspNetUser = c.IdAspNetUser,
                        EstadoCaracterizacion = c.EstadoCaracterizacion,
                        RutaArchivoOriginal = c.RutaArchivoOriginal,
                        NombreIdDepto = c.NombrDepto,
                        NombreIdCiudad = c.NombreMunicipio,
                        NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                        NombreIdGenero = c.NombreGenero,
                        NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                    }).ToList();
            }
            return Resumen;
        }

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaPlano(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                var InforPl = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser).Where(x => x.Grupo == Grupo).ToList();

                var Plano = InforPl
                            .Join(context.ExpedienteDocumentos, l => l.IdExpediente, m => m.IdExpediente, (l, m) => new { m.Estado, l.IdExpediente, m.IdRetencionDocumental })
                            .Where(x => x.IdExpediente == x.IdExpediente && x.IdRetencionDocumental == 21 && x.Estado == true).ToList();

                var Baldios = Plano
                    .Join(context.BaldiosPersonaNatural, l => l.IdExpediente, m => m.id, (l, m) => new
                    {
                        m.id,
                        m.NumeroExpediente,
                        m.IdDepto,
                        m.IdCiudad,
                        m.Vereda,
                        m.NombrePredio,
                        m.NombreBeneficiario,
                        m.IdTipoIdentificacion,
                        m.Identificacion,
                        m.IdGenero,
                        m.IdTipoIdentificacionConyuge,
                        m.IdentificacionConyuge,
                        m.NombreConyuge,
                        m.EstadoInicialMigracion,
                        m.IdAspNetUser,
                        m.EstadoCaracterizacion,
                        m.RutaArchivoOriginal
                    }).ToList();

                var DeptoBal = Baldios
                    .Join(context.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        NombrDepto = c.NOMBRE
                    }).Where(v => v.IdDepto == IdDepto).ToList();

                var CiudadBal = DeptoBal
                    .Join(context.CtCiudad, b => b.IdCiudad, c => c.IdCtMuncipio, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        NombreMunicipio = c.Nombre,
                        IdMunicipioCiudad = c.IdCtMuncipio,
                        IdDeptoCiudad = c.IdCtDepto
                    }).Where(v => v.IdCiudad == IdCiudad && v.IdDeptoCiudad == IdDepto).ToList();

                var TipoIdBal = CiudadBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        NombreTipoIdentificacion = c.NOMBRE
                    }).ToList();

                var GeneroBal = TipoIdBal
                    .Join(context.CtGenero, b => b.IdGenero, c => c.ID_GENERO, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        NombreGenero = c.NOMBRE
                    }).ToList();

                var TipoIdConyugeBal = GeneroBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        b.NombreGenero,
                        NombreTipoIdentificacionConyuge = c.NOMBRE
                    }).ToList();

                Resumen = TipoIdConyugeBal
                    .Select(c => new BaldiosPersonaNaturalModel
                    {
                        id = c.id,
                        NumeroExpediente = c.NumeroExpediente,
                        IdDepto = c.IdDepto,
                        IdCiudad = c.IdCiudad,
                        Vereda = c.Vereda,
                        NombrePredio = c.NombrePredio,
                        NombreBeneficiario = c.NombreBeneficiario,
                        IdTipoIdentificacion = c.IdTipoIdentificacion,
                        Identificacion = c.Identificacion,
                        IdGenero = c.IdGenero,
                        IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = c.IdentificacionConyuge,
                        NombreConyuge = c.NombreConyuge,
                        EstadoInicialMigracion = c.EstadoInicialMigracion,
                        IdAspNetUser = c.IdAspNetUser,
                        EstadoCaracterizacion = c.EstadoCaracterizacion,
                        RutaArchivoOriginal = c.RutaArchivoOriginal,
                        NombreIdDepto = c.NombrDepto,
                        NombreIdCiudad = c.NombreMunicipio,
                        NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                        NombreIdGenero = c.NombreGenero,
                        NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                    }).ToList();
            }
            return Resumen;
        }

        public List<ResumenTipificacionModel> ConsultarResumenRegistro(string IdP)
        {
            var Resumen = new List<ResumenTipificacionModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                Resumen = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser)
                            .Where(x => x.Grupo.Equals("Decide Adjudica") | x.Grupo.Equals("Registro"))
                            .Join(context.Registro, b => b.IdExpediente, c => c.IdExpediente, (b, c) =>
                             new { c.Estado, c.IdExpediente, c.Id })
                            .Join(context.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                             new { b.Estado, b.IdExpediente, b.Id, c.IdCiudad, c.IdDepto })
                            .Join(context.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                             new { b.IdDepto, b.Estado, b.IdExpediente, b.Id, b.IdCiudad, NombreDepto = c.NOMBRE, c.ID_CT_DEPTO, })
                            .Join(context.CtCiudad, b => b.IdCiudad, c => c.IdCtMuncipio, (b, c) =>
                             new { b.IdDepto, b.Estado, b.IdExpediente, b.Id, b.NombreDepto, NombreCiudad = c.Nombre, DeptoCiudad = c.IdCtDepto, c.IdCtMuncipio, })
                            .Where(r => r.IdDepto == r.DeptoCiudad)
                            .Select(c => new ResumenTipificacionModel
                            {
                                Id = Convert.ToInt32(c.Id),
                                IdExpediente = Convert.ToInt32(c.IdExpediente),
                                IdAspNetUser = c.NombreCiudad + "-" + c.NombreDepto,
                                Grupo = c.Estado.ToString() + "-" + c.NombreCiudad + "-" + c.NombreDepto,
                                Plano = context.ExpedienteDocumentos.Where(x => x.IdExpediente == c.IdExpediente && x.IdRetencionDocumental == 21).Select(y => y.IdRetencionDocumental).FirstOrDefault(),
                                Orden = 1,
                                IdDepto = Convert.ToInt32(c.IdDepto),
                                IdMunicipio = c.IdCtMuncipio
                            }).ToList();
            }
            return Resumen;
        }

        public List<BaldiosPersonaNaturalModel> ConsultarResumenRegistroLista(string IdP)
        {
            var Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                Nullable<bool> WhereEstado = null ;

                if (Grupo.Equals("1"))
                {
                    WhereEstado = true;
                }
                else if (Grupo.Equals("0"))
                {
                    WhereEstado = false;
                }
                else if (Grupo.Equals("null"))
                {
                    WhereEstado = null;
                }

                var Registro = context.PlResumenTipificacion(IdDepto, IdCiudad, IdAspNetUser)
                       .Where(x => x.Grupo.Equals("Decide Adjudica") | x.Grupo.Equals("Registro"))
                       .Join(context.Registro, b => b.IdExpediente, c => c.IdExpediente, (b, c) => new { c.Estado, c.IdExpediente, c.Id })
                       .Where(c => c.Estado.Value == WhereEstado.Value).ToList();

                var Baldios = Registro.Join(context.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                             new
                             {
                                 c.id,
                                 c.NumeroExpediente,
                                 c.IdDepto,
                                 c.IdCiudad,
                                 c.Vereda,
                                 c.NombrePredio,
                                 c.NombreBeneficiario,
                                 c.IdTipoIdentificacion,
                                 c.Identificacion,
                                 c.IdGenero,
                                 c.IdTipoIdentificacionConyuge,
                                 c.IdentificacionConyuge,
                                 c.NombreConyuge,
                                 c.EstadoInicialMigracion,
                                 c.IdAspNetUser,
                                 c.EstadoCaracterizacion,
                                 c.RutaArchivoOriginal
                             }).ToList();

                var DeptoBal = Baldios
                   .Join(context.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new
                   {
                       b.id,
                       b.NumeroExpediente,
                       b.IdDepto,
                       b.IdCiudad,
                       b.Vereda,
                       b.NombrePredio,
                       b.NombreBeneficiario,
                       b.IdTipoIdentificacion,
                       b.Identificacion,
                       b.IdGenero,
                       b.IdTipoIdentificacionConyuge,
                       b.IdentificacionConyuge,
                       b.NombreConyuge,
                       b.EstadoInicialMigracion,
                       b.IdAspNetUser,
                       b.EstadoCaracterizacion,
                       b.RutaArchivoOriginal,
                       NombrDepto = c.NOMBRE
                   }).Where(v => v.IdDepto == IdDepto).ToList();

                var CiudadBal = DeptoBal
                   .Join(context.CtCiudad, b => b.IdCiudad, c => c.IdCtMuncipio, (b, c) => new
                   {
                       b.id,
                       b.NumeroExpediente,
                       b.IdDepto,
                       b.IdCiudad,
                       b.Vereda,
                       b.NombrePredio,
                       b.NombreBeneficiario,
                       b.IdTipoIdentificacion,
                       b.Identificacion,
                       b.IdGenero,
                       b.IdTipoIdentificacionConyuge,
                       b.IdentificacionConyuge,
                       b.NombreConyuge,
                       b.EstadoInicialMigracion,
                       b.IdAspNetUser,
                       b.EstadoCaracterizacion,
                       b.RutaArchivoOriginal,
                       b.NombrDepto,
                       NombreMunicipio = c.Nombre,
                       IdMunicipioCiudad = c.IdCtMuncipio,
                       IdDeptoCiudad = c.IdCtDepto
                   }).Where(v => v.IdCiudad == IdCiudad && v.IdDeptoCiudad == IdDepto).ToList();

                var TipoIdBal = CiudadBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        NombreTipoIdentificacion = c.NOMBRE
                    }).ToList();

                var GeneroBal = TipoIdBal
                    .Join(context.CtGenero, b => b.IdGenero, c => c.ID_GENERO, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        NombreGenero = c.NOMBRE
                    }).ToList();

                var TipoIdConyugeBal = GeneroBal
                    .Join(context.CtTipoIdentificacion, b => b.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new
                    {
                        b.id,
                        b.NumeroExpediente,
                        b.IdDepto,
                        b.IdCiudad,
                        b.Vereda,
                        b.NombrePredio,
                        b.NombreBeneficiario,
                        b.IdTipoIdentificacion,
                        b.Identificacion,
                        b.IdGenero,
                        b.IdTipoIdentificacionConyuge,
                        b.IdentificacionConyuge,
                        b.NombreConyuge,
                        b.EstadoInicialMigracion,
                        b.IdAspNetUser,
                        b.EstadoCaracterizacion,
                        b.RutaArchivoOriginal,
                        b.NombrDepto,
                        b.NombreMunicipio,
                        b.NombreTipoIdentificacion,
                        b.NombreGenero,
                        NombreTipoIdentificacionConyuge = c.NOMBRE
                    }).ToList();

                Resumen = TipoIdConyugeBal
                    .Select(c => new BaldiosPersonaNaturalModel
                    {
                        id = c.id,
                        NumeroExpediente = c.NumeroExpediente,
                        IdDepto = c.IdDepto,
                        IdCiudad = c.IdCiudad,
                        Vereda = c.Vereda,
                        NombrePredio = c.NombrePredio,
                        NombreBeneficiario = c.NombreBeneficiario,
                        IdTipoIdentificacion = c.IdTipoIdentificacion,
                        Identificacion = c.Identificacion,
                        IdGenero = c.IdGenero,
                        IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = c.IdentificacionConyuge,
                        NombreConyuge = c.NombreConyuge,
                        EstadoInicialMigracion = c.EstadoInicialMigracion,
                        IdAspNetUser = c.IdAspNetUser,
                        EstadoCaracterizacion = c.EstadoCaracterizacion,
                        RutaArchivoOriginal = c.RutaArchivoOriginal,
                        NombreIdDepto = c.NombrDepto,
                        NombreIdCiudad = c.NombreMunicipio,
                        NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                        NombreIdGenero = c.NombreGenero,
                        NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                    }).ToList();

            }
            return Resumen;
        }

        public List<BaldiosPersonaNaturalModel> ConsultarIdPUser(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Where(w => w.IdAspNetUser == IdP).ToList();

            var listaBaldiosExpedientes = listaBaldios
                .Join(Ctx.ExpedienteDocumentos, l => l.id, m => m.IdExpediente.Value, (l, m) => new
                {
                    l.id,
                    l.NumeroExpediente,
                    l.IdDepto,
                    l.IdCiudad,
                    l.Vereda,
                    l.NombrePredio,
                    l.NombreBeneficiario,
                    l.IdTipoIdentificacion,
                    l.Identificacion,
                    l.IdGenero,
                    l.IdTipoIdentificacionConyuge,
                    l.IdentificacionConyuge,
                    l.NombreConyuge,
                    l.EstadoInicialMigracion,
                    l.IdAspNetUser,
                    l.EstadoCaracterizacion,
                    l.RutaArchivoOriginal,
                }).Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.id,
                    NumeroExpediente = c.NumeroExpediente,
                    IdDepto = c.IdDepto,
                    IdCiudad = c.IdCiudad,
                    Vereda = c.Vereda,
                    NombrePredio = c.NombrePredio,
                    NombreBeneficiario = c.NombreBeneficiario,
                    IdTipoIdentificacion = c.IdTipoIdentificacion,
                    Identificacion = c.Identificacion,
                    IdGenero = c.IdGenero,
                    IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.IdentificacionConyuge,
                    NombreConyuge = c.NombreConyuge,
                    EstadoInicialMigracion = c.EstadoInicialMigracion,
                    IdAspNetUser = c.IdAspNetUser,
                    EstadoCaracterizacion = c.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.RutaArchivoOriginal,
                }).GroupBy(x => x.id).ToList();

            var xxx = listaBaldiosExpedientes.Select(group => group.Select(s => s).FirstOrDefault()).ToList();

            #region Sql
            var lista = xxx
                .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     NombrDepto = c.NOMBRE
                 })
                .Join(Ctx.CtCiudad, d => d.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                 new
                 {
                     d.id,
                     d.NumeroExpediente,
                     d.IdDepto,
                     d.IdCiudad,
                     d.Vereda,
                     d.NombrePredio,
                     d.NombreBeneficiario,
                     d.IdTipoIdentificacion,
                     d.Identificacion,
                     d.IdGenero,
                     d.IdTipoIdentificacionConyuge,
                     d.IdentificacionConyuge,
                     d.NombreConyuge,
                     d.EstadoInicialMigracion,
                     d.IdAspNetUser,
                     d.EstadoCaracterizacion,
                     d.RutaArchivoOriginal,
                     d.NombrDepto,
                     NombreMunicipio = e.Nombre,
                     MunicipioIdDepto = e.IdCtDepto
                 })
                .Join(Ctx.CtTipoIdentificacion, f => f.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                 new
                 {
                     f.id,
                     f.NumeroExpediente,
                     f.IdDepto,
                     f.IdCiudad,
                     f.Vereda,
                     f.NombrePredio,
                     f.NombreBeneficiario,
                     f.IdTipoIdentificacion,
                     f.Identificacion,
                     f.IdGenero,
                     f.IdTipoIdentificacionConyuge,
                     f.IdentificacionConyuge,
                     f.NombreConyuge,
                     f.EstadoInicialMigracion,
                     f.IdAspNetUser,
                     f.EstadoCaracterizacion,
                     f.RutaArchivoOriginal,
                     f.NombrDepto,
                     f.NombreMunicipio,
                     NombreTipoIdentificacion = g.NOMBRE,
                     f.MunicipioIdDepto
                 })
                .Join(Ctx.CtGenero, h => h.IdGenero, i => i.ID_GENERO, (h, i) =>
                 new
                 {
                     h.id,
                     h.NumeroExpediente,
                     h.IdDepto,
                     h.IdCiudad,
                     h.Vereda,
                     h.NombrePredio,
                     h.NombreBeneficiario,
                     h.IdTipoIdentificacion,
                     h.Identificacion,
                     h.IdGenero,
                     h.IdTipoIdentificacionConyuge,
                     h.IdentificacionConyuge,
                     h.NombreConyuge,
                     h.EstadoInicialMigracion,
                     h.IdAspNetUser,
                     h.EstadoCaracterizacion,
                     h.RutaArchivoOriginal,
                     h.NombrDepto,
                     h.NombreMunicipio,
                     h.NombreTipoIdentificacion,
                     h.MunicipioIdDepto,
                     NombreGenero = i.NOMBRE
                 })
                .Join(Ctx.CtTipoIdentificacion, j => j.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new
                 {
                     j.id,
                     j.NumeroExpediente,
                     j.IdDepto,
                     j.IdCiudad,
                     j.Vereda,
                     j.NombrePredio,
                     j.NombreBeneficiario,
                     j.IdTipoIdentificacion,
                     j.Identificacion,
                     j.IdGenero,
                     j.IdTipoIdentificacionConyuge,
                     j.IdentificacionConyuge,
                     j.NombreConyuge,
                     j.EstadoInicialMigracion,
                     j.IdAspNetUser,
                     j.EstadoCaracterizacion,
                     j.RutaArchivoOriginal,
                     j.NombrDepto,
                     j.NombreMunicipio,
                     j.NombreTipoIdentificacion,
                     j.MunicipioIdDepto,
                     j.NombreGenero,
                     NombreTipoIdentificacionConyuge = k.NOMBRE
                 })
                 .Where(w => w.MunicipioIdDepto == w.IdDepto)
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.id,
                    NumeroExpediente = c.NumeroExpediente,
                    IdDepto = c.IdDepto,
                    IdCiudad = c.IdCiudad,
                    Vereda = c.Vereda,
                    NombrePredio = c.NombrePredio,
                    NombreBeneficiario = c.NombreBeneficiario,
                    IdTipoIdentificacion = c.IdTipoIdentificacion,
                    Identificacion = c.Identificacion,
                    IdGenero = c.IdGenero,
                    IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.IdentificacionConyuge,
                    NombreConyuge = c.NombreConyuge,
                    EstadoInicialMigracion = c.EstadoInicialMigracion,
                    IdAspNetUser = c.IdAspNetUser,
                    EstadoCaracterizacion = c.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdGenero = c.NombreGenero,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                });

            #endregion
            return lista.ToList();
        }

        public int ConsultarIdPCount(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var Baldios = Ctx.BaldiosPersonaNatural.Where(w => w.IdAspNetUser == IdP).Count();
            return Baldios;
        }

        public int ConsultarIdPCountEdit(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Where(w => w.IdAspNetUser == IdP).ToList();
            #region Sql
            var lista = listaBaldios
                .Join(Ctx.ExpedienteDocumentos, b => b.id, c => c.IdExpediente.Value, (b, c) => new { b.id, b.IdCiudad })
                .GroupBy(x => x.id).Count();

            #endregion
            return lista;
        }

        public BaldiosPersonaNaturalModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.BaldiosPersonaNatural
                 .Where(w => w.id == id)
                 .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new
                 {
                     b.id,
                     b.NumeroExpediente,
                     b.IdDepto,
                     b.IdCiudad,
                     b.Vereda,
                     b.NombrePredio,
                     b.NombreBeneficiario,
                     b.IdTipoIdentificacion,
                     b.Identificacion,
                     b.IdGenero,
                     b.IdTipoIdentificacionConyuge,
                     b.IdentificacionConyuge,
                     b.NombreConyuge,
                     b.EstadoInicialMigracion,
                     b.IdAspNetUser,
                     b.EstadoCaracterizacion,
                     b.RutaArchivoOriginal,
                     NombrDepto = c.NOMBRE,
                     b.ArchivoVerificado,
                     b.NombreArchivo
                 })
                .Join(Ctx.CtCiudad, d => d.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                 new
                 {
                     d.id,
                     d.NumeroExpediente,
                     d.IdDepto,
                     d.IdCiudad,
                     d.Vereda,
                     d.NombrePredio,
                     d.NombreBeneficiario,
                     d.IdTipoIdentificacion,
                     d.Identificacion,
                     d.IdGenero,
                     d.IdTipoIdentificacionConyuge,
                     d.IdentificacionConyuge,
                     d.NombreConyuge,
                     d.EstadoInicialMigracion,
                     d.IdAspNetUser,
                     d.EstadoCaracterizacion,
                     d.RutaArchivoOriginal,
                     d.NombrDepto,
                     NombreMunicipio = e.Nombre,
                     MunicipioIdDepto = e.IdCtDepto,
                     d.ArchivoVerificado,
                     d.NombreArchivo
                 })
                .Join(Ctx.CtTipoIdentificacion, f => f.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                 new
                 {
                     f.id,
                     f.NumeroExpediente,
                     f.IdDepto,
                     f.IdCiudad,
                     f.Vereda,
                     f.NombrePredio,
                     f.NombreBeneficiario,
                     f.IdTipoIdentificacion,
                     f.Identificacion,
                     f.IdGenero,
                     f.IdTipoIdentificacionConyuge,
                     f.IdentificacionConyuge,
                     f.NombreConyuge,
                     f.EstadoInicialMigracion,
                     f.IdAspNetUser,
                     f.EstadoCaracterizacion,
                     f.RutaArchivoOriginal,
                     f.NombrDepto,
                     f.NombreMunicipio,
                     NombreTipoIdentificacion = g.NOMBRE,
                     f.MunicipioIdDepto,
                     f.ArchivoVerificado,
                     f.NombreArchivo
                 })
                .Join(Ctx.CtGenero, h => h.IdGenero, i => i.ID_GENERO, (h, i) =>
                 new
                 {
                     h.id,
                     h.NumeroExpediente,
                     h.IdDepto,
                     h.IdCiudad,
                     h.Vereda,
                     h.NombrePredio,
                     h.NombreBeneficiario,
                     h.IdTipoIdentificacion,
                     h.Identificacion,
                     h.IdGenero,
                     h.IdTipoIdentificacionConyuge,
                     h.IdentificacionConyuge,
                     h.NombreConyuge,
                     h.EstadoInicialMigracion,
                     h.IdAspNetUser,
                     h.EstadoCaracterizacion,
                     h.RutaArchivoOriginal,
                     h.NombrDepto,
                     h.NombreMunicipio,
                     h.NombreTipoIdentificacion,
                     h.MunicipioIdDepto,
                     NombreGenero = i.NOMBRE,
                     h.ArchivoVerificado,
                     h.NombreArchivo
                 })
                .Join(Ctx.CtTipoIdentificacion, j => j.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new
                 {
                     j.id,
                     j.NumeroExpediente,
                     j.IdDepto,
                     j.IdCiudad,
                     j.Vereda,
                     j.NombrePredio,
                     j.NombreBeneficiario,
                     j.IdTipoIdentificacion,
                     j.Identificacion,
                     j.IdGenero,
                     j.IdTipoIdentificacionConyuge,
                     j.IdentificacionConyuge,
                     j.NombreConyuge,
                     j.EstadoInicialMigracion,
                     j.IdAspNetUser,
                     j.EstadoCaracterizacion,
                     j.RutaArchivoOriginal,
                     j.NombrDepto,
                     j.NombreMunicipio,
                     j.NombreTipoIdentificacion,
                     j.MunicipioIdDepto,
                     j.NombreGenero,
                     NombreTipoIdentificacionConyuge = k.NOMBRE,
                     j.ArchivoVerificado,
                     j.NombreArchivo
                 })
                 .Where(w => w.MunicipioIdDepto == w.IdDepto)
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.id,
                    NumeroExpediente = c.NumeroExpediente,
                    IdDepto = c.IdDepto,
                    IdCiudad = c.IdCiudad,
                    Vereda = c.Vereda,
                    NombrePredio = c.NombrePredio,
                    NombreBeneficiario = c.NombreBeneficiario,
                    IdTipoIdentificacion = c.IdTipoIdentificacion,
                    Identificacion = c.Identificacion,
                    IdGenero = c.IdGenero,
                    IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.IdentificacionConyuge,
                    NombreConyuge = c.NombreConyuge,
                    EstadoInicialMigracion = c.EstadoInicialMigracion,
                    IdAspNetUser = c.IdAspNetUser,
                    EstadoCaracterizacion = c.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdGenero = c.NombreGenero,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                    NombreArchivo = c.NombreArchivo,
                    TipoArchivo = c.ArchivoVerificado.ToString()
                });


            return a.FirstOrDefault();
        }


    }
}