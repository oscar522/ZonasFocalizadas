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

        public List<PlGestionUsersModel> ConsultarGestion(string TypeTable, string Fi, string Ff , string Mes, int Dia, string users  )
        {
            List<PlGestionUsersModel> list = new List<PlGestionUsersModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                 list = context.PlGestionUsers(TypeTable, Fi, Ff, Mes, Dia, users)
                    .Select(b => new PlGestionUsersModel {
                        UserName = b.UserName,
                        dia01 = b.dia01,
                        dia02 = b.dia02,
                        dia03 = b.dia03,
                        dia04 = b.dia04,
                        dia05 = b.dia05,
                        dia06 = b.dia06,
                        dia07 = b.dia07,
                        dia08 = b.dia08,
                        dia09 = b.dia09,
                        dia10 = b.dia10,
                        dia11 = b.dia11,
                        dia12 = b.dia12,
                        dia13 = b.dia13,
                        dia14 = b.dia14,
                        dia15 = b.dia15,
                        dia16 = b.dia16,
                        dia17 = b.dia17,
                        dia18 = b.dia18,
                        dia19 = b.dia19,
                        dia20 = b.dia20,
                        dia21 = b.dia21,
                        dia22 = b.dia22,
                        dia23 = b.dia23,
                        dia24 = b.dia24,
                        dia25 = b.dia25,
                        dia26 = b.dia26,
                        dia27 = b.dia27,
                        dia28 = b.dia28,
                        dia29 = b.dia29,
                        dia30 = b.dia30,
                        dia31 = b.dia31,
                    }).ToList();
            }
            return list;
        }
        public List<CtCiudadModel> ConsultarIdPCountDeptoMuni()
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
                     b.RutaVerificado,
                     c.FlagFocalizado

                 })
                //.Where(x => x.Muni_ZonaFocalizada == true && x.Muni_IdCtDepto == x.DeptoExp)
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
                    FlagFocalizado = c.Select(v => v.FlagFocalizado.Value).FirstOrDefault(),
                })
                .ToList();

            List<CtCiudadModel> listaModel = new List<CtCiudadModel>();

            foreach (var Model in MunicipiosFocalidas)
            {

                var NumeroPdf = Ctx.BaldiosPersonaNatural
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && x.IdDepto == Model.IdCtDepto
                                    && x.RutaVerificado == 1).Count().ToString();

                var NumeroTipificacion = Ctx.BaldiosPersonaNatural.Join(Ctx.ExpedienteDocumentos, b => b.id, c => c.IdExpediente.Value, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.IdDepto , c.IdExpediente })
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && x.IdDepto == Model.IdCtDepto).GroupBy(y =>y.IdExpediente).Count().ToString();

                var NumeroAsociados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.IdDepto })
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && x.IdDepto == Model.IdCtDepto && x.RutaVerificado == 1).Count().ToString();

                var Malnombrados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.ArchivoVerificado, b.IdDepto })
                                    .Where(x => x.IdCiudad == Model.IdCtMuncipio
                                    && x.IdDepto == Model.IdCtDepto && x.RutaVerificado == 1 && (x.ArchivoVerificado == 2 )).Count().ToString();


                Model.NOMBRE_PAIS = NumeroPdf + "-" + NumeroTipificacion + "-" + NumeroAsociados + "-" + Malnombrados +"-" + Model.FlagFocalizado;

                listaModel.Add(Model);
            }
            return listaModel;
        }

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
                .GroupBy(x => x.Muni_IdCtDepto)
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
                                    .Where(x =>  x.IdDepto == Model.IdCtDepto
                                    && x.RutaVerificado == 1).Count().ToString();

                var NumeroTipificacion = Ctx.BaldiosPersonaNatural.Join(Ctx.ExpedienteDocumentos, b => b.id, c => c.IdExpediente.Value, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.IdDepto, c.IdExpediente })
                                    .Where(x => x.IdDepto == Model.IdCtDepto).GroupBy(y => y.IdExpediente).Count().ToString();

                var NumeroAsociados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.IdDepto })
                                    .Where(x =>  x.IdDepto == Model.IdCtDepto && x.RutaVerificado == 1).Count().ToString();

                var Malnombrados = Ctx.BaldiosPersonaNatural.Join(Ctx.AspNetUsers, b => b.IdAspNetUser, c => c.Id, (b, c) =>
                                    new { b.IdAspNetUser, b.IdCiudad, b.RutaVerificado, b.ArchivoVerificado, b.IdDepto })
                                    .Where(x => x.IdDepto == Model.IdCtDepto && x.RutaVerificado == 1 && (x.ArchivoVerificado == 2)).Count().ToString();


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

        public List<ResumenTipificacionAllModel> ConsultarResumenAll(string IdP)
        {
            var Resumen = new List<ResumenTipificacionAllModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];

                Resumen = context.PlResumenTipificacionAll(IdDepto, IdCiudad, IdAspNetUser)
                            .Select(c => new ResumenTipificacionAllModel
                            {
                                Id = c.Id,
                                IdExpediente = c.IdExpediente,
                                IdAspNetUser = c.IdAspNetUser,
                                Grupo = c.Grupo,
                                Plano = c.Plano,
                                Orden = c.Orden,
                                DeptoNombre = c.DeptoNombre,
                                DeptoId = c.DeptoId,
                                MunicId = c.MunicId,
                                MunicNombre = c.MunicNombre,
                            }).ToList();
            }
            return Resumen;
        }

        public List<CaracterizacionJuridicaResumenModel> ConsultarResumenCaracterizacionJuridicaAll(string IdP)
        {
            var Resumen = new List<CaracterizacionJuridicaResumenModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];

                try
                {
                    Resumen = context.ResumenCaracterizacionJuridica(IdP)
                           .Select(c => new CaracterizacionJuridicaResumenModel
                           {

                               Id = c.Id,
                               IdExpediente = c.IdExpediente,
                               INSPECCION_OCULAR_INSPECCION_OCULAR_53 = c.INSPECCION_OCULAR_INSPECCION_OCULAR_53,
                               INSPECCION_OCULAR_FECHA_54 = c.INSPECCION_OCULAR_FECHA_54,
                               INSPECCION_OCULAR_FIRMA_55 = c.INSPECCION_OCULAR_FIRMA_55,
                               INSPECCION_OCULAR_OPOSICIONES_56 = c.INSPECCION_OCULAR_OPOSICIONES_56,
                               INSPECCION_OCULAR_CONCEPTO_57 = c.INSPECCION_OCULAR_CONCEPTO_57,
                               INSPECCION_OCULAR_VISIBLE = c.INSPECCION_OCULAR_VISIBLE,
                               ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58 = c.ACLARACION_DE_INSPECCION_OCULAR_ACLARACION_DE_INSPECCION_OCULAR_58,
                               ACLARACION_DE_INSPECCION_OCULAR_FECHA_59 = c.ACLARACION_DE_INSPECCION_OCULAR_FECHA_59,
                               ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60 = c.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_60,
                               ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61 = c.ACLARACION_DE_INSPECCION_OCULAR_CONCEPTO_61,
                               ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62 = c.ACLARACION_DE_INSPECCION_OCULAR_PUBLICACION_EN_EMISORA_62,
                               ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63 = c.ACLARACION_DE_INSPECCION_OCULAR_FIRMA_DE_PUBLICACION_63,
                               ACLARACION_DE_INSPECCION_VISIBLE = c.ACLARACION_DE_INSPECCION_VISIBLE,
                               FIJACION_EN_LISTA_FIJACION_EN_LISTA_64 = c.FIJACION_EN_LISTA_FIJACION_EN_LISTA_64,
                               FIJACION_EN_LISTA_FECHA_DE_FIJACION_65 = c.FIJACION_EN_LISTA_FECHA_DE_FIJACION_65,
                               FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66 = c.FIJACION_EN_LISTA_FECHA_DE_DESFIJACION_66,
                               FIJACION_EN_LISTA_FIRMA_67 = c.FIJACION_EN_LISTA_FIRMA_67,
                               FIJACION_EN_LISTA_VISIBLE = c.FIJACION_EN_LISTA_VISIBLE,
                               OPOCISIONES_OPOCISIONES_68 = c.OPOCISIONES_OPOCISIONES_68,
                               OPOCISIONES_FECHA_69 = c.OPOCISIONES_FECHA_69,
                               OPOCISIONES_EN_LISTA_VISIBLE = c.OPOCISIONES_EN_LISTA_VISIBLE,
                               FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70 = c.FORMATO_DE_REVISION_JURIDICA_FORMATO_DE_REVISION_JURIDICA_70,
                               FORMATO_DE_REVISION_JURIDICA_FECHA_71 = c.FORMATO_DE_REVISION_JURIDICA_FECHA_71,
                               FORMATO_DE_REVISION_JURIDICA_FIRMADA_72 = c.FORMATO_DE_REVISION_JURIDICA_FIRMADA_72,
                               FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73 = c.FORMATO_DE_REVISION_JURIDICA_CONCEPTO_73,
                               FORMATO_DE_REVISION_JURIDICA_VISIBLE = c.FORMATO_DE_REVISION_JURIDICA_VISIBLE,
                               RESOLUCION_RESOLUCION_74 = c.RESOLUCION_RESOLUCION_74,
                               RESOLUCION_NUMERO_DE_RESOLUCION_75 = c.RESOLUCION_NUMERO_DE_RESOLUCION_75,
                               RESOLUCION_FECHA_DE_RESOLUCION_76 = c.RESOLUCION_FECHA_DE_RESOLUCION_76,
                               RESOLUCION_FIRMADA_77 = c.RESOLUCION_FIRMADA_77,
                               RESOLUCION_DECISION_78 = c.RESOLUCION_DECISION_78,
                               RESOLUCION_DATOS_SOLICITANTE_BIEN = c.RESOLUCION_DATOS_SOLICITANTE_BIEN,
                               RESOLUCION_DATOS_SOLICITANTE_EN = c.RESOLUCION_DATOS_SOLICITANTE_EN,
                               RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79 = c.RESOLUCION_AREA_ADJUDICADA_metros_cuadrados_79,
                               RESOLUCION_CONJUNTA_INDIVIDUAL_80 = c.RESOLUCION_CONJUNTA_INDIVIDUAL_80,
                               RESOLUCION_VISIBLE = c.RESOLUCION_VISIBLE,
                               RESOLUCION_RAZON_NEGACION = c.RESOLUCION_RAZON_NEGACION,
                               NOTIFICACION_NOTIFICACION_SOLICITANTES_81 = c.NOTIFICACION_NOTIFICACION_SOLICITANTES_81,
                               NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82 = c.NOTIFICACION_FECHA_DE_NOTIFICACION_SOLICITANTES_82,
                               NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83 = c.NOTIFICACION_NOTIFICACION_MINISTERIO_PUBLICO_83,
                               NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84 = c.NOTIFICACION_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_84,
                               NOTIFICACION_VISIBLE = c.NOTIFICACION_VISIBLE,
                               RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85 = c.RECURSO_SOLICITANTE_RECURSO_SOLICITANTE_85,
                               RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86 = c.RECURSO_SOLICITANTE_FECHA_DE_SOLICITUD_86,
                               RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87 = c.RECURSO_SOLICITANTE_RESPUESTA_RECURSO_87,
                               RECURSO_SOLICITANTE_DECISION_N_1 = c.RECURSO_SOLICITANTE_DECISION_N_1,
                               RECURSO_SOLICITANTE_FIRMADA_88 = c.RECURSO_SOLICITANTE_FIRMADA_88,
                               RECURSO_SOLICITANTE_ACTO_89 = c.RECURSO_SOLICITANTE_ACTO_89,
                               RECURSO_SOLICITANTE_NUMERO_90 = c.RECURSO_SOLICITANTE_NUMERO_90,
                               RECURSO_SOLICITANTE_FECHA_91 = c.RECURSO_SOLICITANTE_FECHA_91,
                               RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92 = c.RECURSO_SOLICITANTE_DECISION_SOBRE_LA_ADJUDICAICON_92,
                               RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93 = c.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_93,
                               RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = c.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
                               RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95 = c.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_95,
                               RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = c.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,
                               RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2 = c.RECURSO_SOLICITANTE_RESOLUCION_DESPUES_PRUEBA_N_2,
                               RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = c.RECURSO_SOLICITANTE_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
                               RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4 = c.RECURSO_SOLICITANTE_FECHA_RESOLUCION_PRUEBAS_N_4,
                               RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5 = c.RECURSO_SOLICITANTE_FIRMA_RESOLUCION_PRUEBAS_N_5,
                               RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6 = c.RECURSO_SOLICITANTE_DECISION_RESOLUCION_PRUEBAS_N_6,
                               RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6 = c.RECURSO_SOLICITANTE_AREA_ADJUDICADA_N_6,
                               RECURSO_SOLICITANTE_CONJUNA_IND_N_7 = c.RECURSO_SOLICITANTE_CONJUNA_IND_N_7,
                               RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8 = c.RECURSO_SOLICITANTE_NOTIFICACION_SOLICITANTES_N_8,
                               RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = c.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
                               RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = c.RECURSO_SOLICITANTE_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
                               RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = c.RECURSO_SOLICITANTE_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
                               RECURSO_SOLICITANTE_VISIBLE = c.RECURSO_SOLICITANTE_VISIBLE,
                               RECURSO_MINISTERIO_RECURSO_MINISTERIO_85 = c.RECURSO_MINISTERIO_RECURSO_MINISTERIO_85,
                               RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86 = c.RECURSO_MINISTERIO_FECHA_DE_SOLICITUD_86,
                               RECURSO_MINISTERIO_RESPUESTA_RECURSO_87 = c.RECURSO_MINISTERIO_RESPUESTA_RECURSO_87,
                               RECURSO_MINISTERIO_DECISION_N_1 = c.RECURSO_MINISTERIO_DECISION_N_1,
                               RECURSO_MINISTERIO_FIRMADA_88 = c.RECURSO_MINISTERIO_FIRMADA_88,
                               RECURSO_MINISTERIO_ACTO_89 = c.RECURSO_MINISTERIO_ACTO_89,
                               RECURSO_MINISTERIO_NUMERO_90 = c.RECURSO_MINISTERIO_NUMERO_90,
                               RECURSO_MINISTERIO_FECHA_91 = c.RECURSO_MINISTERIO_FECHA_91,
                               RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92 = c.RECURSO_MINISTERIO_DECISION_SOBRE_LA_ADJUDICAICON_92,
                               RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93 = c.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_93,
                               RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94 = c.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_94,
                               RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95 = c.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_95,
                               RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96 = c.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_96,
                               RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2 = c.RECURSO_MINISTERIO_RESOLUCION_DESPUES_PRUEBA_N_2,
                               RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3 = c.RECURSO_MINISTERIO_NUMERO_RESOLUCION_DESPUES_PRUEBA_N_3,
                               RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4 = c.RECURSO_MINISTERIO_FECHA_RESOLUCION_PRUEBAS_N_4,
                               RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5 = c.RECURSO_MINISTERIO_FIRMA_RESOLUCION_PRUEBAS_N_5,
                               RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6 = c.RECURSO_MINISTERIO_DECISION_RESOLUCION_PRUEBAS_N_6,
                               RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6 = c.RECURSO_MINISTERIO_AREA_ADJUDICADA_N_6,
                               RECURSO_MINISTERIO_CONJUNA_IND_N_7 = c.RECURSO_MINISTERIO_CONJUNA_IND_N_7,
                               RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8 = c.RECURSO_MINISTERIO_NOTIFICACION_SOLICITANTES_N_8,
                               RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9 = c.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_SOLICITANTES_N_9,
                               RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10 = c.RECURSO_MINISTERIO_NOTIFICACION_MINISTERIO_PUBLICO_N_10,
                               RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11 = c.RECURSO_MINISTERIO_FECHA_DE_NOTIFICACION_MINISTERIO_PUBLICO_N_11,
                               RECURSO_MINISTERIO_VISIBLE = c.RECURSO_MINISTERIO_VISIBLE,
                               CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109 = c.CONSTANCIA_DE_EJECUTORIA_CONSTANCIA_DE_EJECUTOIA_109,
                               CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110 = c.CONSTANCIA_DE_EJECUTORIA_FECHA_CONSTANCIA_EJECUTORIA_110,
                               CONSTANCIA_DE_EJECUTORIA_FIRMADA_111 = c.CONSTANCIA_DE_EJECUTORIA_FIRMADA_111,
                               CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112 = c.CONSTANCIA_DE_EJECUTORIA_LA_FECHA_ES_CORRECTA_112,
                               CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION = c.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION,
                               CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA = c.CONSTANCIA_DE_EJECUTORIA_NUMERO_RESOLUCION_FECHA,
                               CONSTANCIA_DE_EJECUTORIA_VISIBLE = c.CONSTANCIA_DE_EJECUTORIA_VISIBLE,
                               REVOCATORIA_REVOCATORIA_113 = c.REVOCATORIA_REVOCATORIA_113,
                               REVOCATORIA_NUMERO_RESOLUCIÓN_114 = c.REVOCATORIA_NUMERO_RESOLUCIÓN_114,
                               REVOCATORIA_FECHA_DE_RESOLUCIÓN_115 = c.REVOCATORIA_FECHA_DE_RESOLUCIÓN_115,
                               REVOCATORIA_VISIBLE = c.REVOCATORIA_VISIBLE,
                               REGISTRO_FMI_ = c.REGISTRO_FMI_,
                               REGISTRO_FMI = c.REGISTRO_FMI,
                               REGISTRO_FECHA_DE_REGISTRO_117 = c.REGISTRO_FECHA_DE_REGISTRO_117,
                               REGISTRO_NUMERO_DE_RESOLUCION_118 = c.REGISTRO_NUMERO_DE_RESOLUCION_118,
                               REGISTRO_FECHA_DE_RESOLUCION_119 = c.REGISTRO_FECHA_DE_RESOLUCION_119,
                               REGISTRO_VISIBLE = c.REGISTRO_VISIBLE,
                               SOLICITUD_SOLICITUD = c.SOLICITUD_SOLICITUD,
                               SOLICITUD_FECHA = c.SOLICITUD_FECHA,
                               SOLICITUD_FIRMA = c.SOLICITUD_FIRMA,
                               SOLICITUD_TIPO_SOLICITUD = c.SOLICITUD_TIPO_SOLICITUD,
                               SOLICITUD_CEDULA_SOLICITANTE = c.SOLICITUD_CEDULA_SOLICITANTE,
                               SOLICITUD_CEDULA_CONYUGE = c.SOLICITUD_CEDULA_CONYUGE,
                               SOLICITUD_CEDULA_PARIENTE = c.SOLICITUD_CEDULA_PARIENTE,
                               SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA = c.SOLICITUD_FECHADESDELACUALOCUPAEXPLOTA,
                               SOLICITUD_VISIBLE = c.SOLICITUD_VISIBLE,
                               AUTODEACEPTACION_AUTODEACEPTACION = c.AUTODEACEPTACION_AUTODEACEPTACION,
                               AUTODEACEPTACION_FECHA = c.AUTODEACEPTACION_FECHA,
                               AUTODEACEPTACION_FIRMA = c.AUTODEACEPTACION_FIRMA,
                               AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO = c.AUTODEACEPTACION_ELNUMEROFECHADESOLICITUDCORRECTO,
                               AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO = c.AUTODEACEPTACION_NOMBRESOLICITANTECONYUGECORRECTO,
                               AUTODEACEPTACION_DATOSPREDIOSCORRECTO = c.AUTODEACEPTACION_DATOSPREDIOSCORRECTO,
                               AUTODEACEPTACION_COLINDANTE_CORRECTO = c.AUTODEACEPTACION_COLINDANTE_CORRECTO,
                               AUTODEACEPTACION_VISIBLE = c.AUTODEACEPTACION_VISIBLE,
                               COMUNICACIONES_SOLICITANTE = c.COMUNICACIONES_SOLICITANTE,
                               COMUNICACIONES_SOLICITANTEFECHA = c.COMUNICACIONES_SOLICITANTEFECHA,
                               COMUNICACIONES_SOLICITANTEFIRMA = c.COMUNICACIONES_SOLICITANTEFIRMA,
                               COMUNICACIONES_FECHAINSPECCIONOCULAR = c.COMUNICACIONES_FECHAINSPECCIONOCULAR,
                               COMUNICACIONES_VISIBLE = c.COMUNICACIONES_VISIBLE,
                               COMUNICACIONES_PROCURADOR = c.COMUNICACIONES_PROCURADOR,
                               COMUNICACIONES_PROCURADORFECHA = c.COMUNICACIONES_PROCURADORFECHA,
                               COMUNICACIONES_PROCURADORFIRMA = c.COMUNICACIONES_PROCURADORFIRMA,
                               COMUNICACIONES_VISIBLE_PROCURADOR = c.COMUNICACIONES_VISIBLE_PROCURADOR,
                               COMUNICACIONES_AUTORIDADAMBIENTAL = c.COMUNICACIONES_AUTORIDADAMBIENTAL,
                               COMUNICACIONES_AUTORIDADAMBIENTALFECHA = c.COMUNICACIONES_AUTORIDADAMBIENTALFECHA,
                               COMUNICACIONES_AUTORIDADAMBIENTALFIRMA = c.COMUNICACIONES_AUTORIDADAMBIENTALFIRMA,
                               COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL = c.COMUNICACIONES_VISIBLE_AUTORIDADAMBIENTAL,
                               COMUNICACIONES_COLINDATES = c.COMUNICACIONES_COLINDATES,
                               COMUNICACIONES_COLINDATES_INCOMPLETOS = c.COMUNICACIONES_COLINDATES_INCOMPLETOS,
                               COMUNICACIONES_COLINDATESFECHA = c.COMUNICACIONES_COLINDATESFECHA,
                               COMUNICACIONES_COLINDATESFIRMA = c.COMUNICACIONES_COLINDATESFIRMA,
                               COMUNICACIONES_VISIBLE_COLINDATES = c.COMUNICACIONES_VISIBLE_COLINDATES,
                               PUBLICACIONES_ALCALDIA = c.PUBLICACIONES_ALCALDIA,
                               PUBLICACIONES_ALCALDIAFECHAFIJACION = c.PUBLICACIONES_ALCALDIAFECHAFIJACION,
                               PUBLICACIONES_ALCALDIADESFIJACION = c.PUBLICACIONES_ALCALDIADESFIJACION,
                               PUBLICACIONES_ALCALDIAFIRMA = c.PUBLICACIONES_ALCALDIAFIRMA,
                               PUBLICACIONES_VISIBLE = c.PUBLICACIONES_VISIBLE,
                               PUBLICACIONES_INCODER = c.PUBLICACIONES_INCODER,
                               PUBLICACIONES_INCODERFECHAFIJACION = c.PUBLICACIONES_INCODERFECHAFIJACION,
                               PUBLICACIONES_INCODERDESFIJACION = c.PUBLICACIONES_INCODERDESFIJACION,
                               PUBLICACIONES_INCODERFIRMA = c.PUBLICACIONES_INCODERFIRMA,
                               PUBLICACIONES_VISIBLE_INCODER = c.PUBLICACIONES_VISIBLE_INCODER,
                               PUBLICACIONES_EMISORA = c.PUBLICACIONES_EMISORA,
                               PUBLICACIONES_EMISORAFECHA1 = c.PUBLICACIONES_EMISORAFECHA1,
                               PUBLICACIONES_EMISORAFECHA2 = c.PUBLICACIONES_EMISORAFECHA2,
                               PUBLICACIONES_EMISORAFIRMA = c.PUBLICACIONES_EMISORAFIRMA,
                               PUBLICACIONES_VISIBLE_EMISORA = c.PUBLICACIONES_VISIBLE_EMISORA,
                               SUBSIDIODEAPELACION = c.SUBSIDIODEAPELACION,
                               SUBSIDIODEAPELACION_VISIBLE = c.SUBSIDIODEAPELACION_VISIBLE,
                               SUBSIDIODEAPELACION_FECHA = c.SUBSIDIODEAPELACION_FECHA,
                               SUBSIDIODEAPELACION_RESPUESTA = c.SUBSIDIODEAPELACION_RESPUESTA,
                               SUBSIDIODEAPELACION_DECISION = c.SUBSIDIODEAPELACION_DECISION,
                               Estado = c.Estado,
                               IdAspNetUser = c.IdAspNetUser,
                               FechaModificacion = c.FechaModificacion,
                               Gestion = c.Gestion,
                               Tipo = c.Tipo,
                               SubTipo = c.SubTipo,
                               IdMunicipio = c.IdMunicipio,
                               NombreMuni = c.NombreMuni,
                               IdDepto = c.IdDepto,
                               NombreDepto = c.NombreDepto,
                               Orden = c.Orden,

                           }).ToList();
                }
                catch (Exception w)
                {
                    var error = w;
                    throw;
                }

               
            }
            return Resumen;
        }

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaResumenCaracterizacionJuridica(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                var InforPl = context.ResumenCaracterizacionJuridica(IdAspNetUser).Where(x => x.Tipo == Grupo &&  x.IdDepto == IdDepto.ToString() && x.IdMunicipio == IdCiudad).ToList();

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
                    }).ToList();

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
                    }).ToList();

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

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaAll(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                var InforPl = context.PlResumenTipificacionAll(IdDepto, IdCiudad, IdAspNetUser).Where(x => x.Grupo == Grupo).ToList();

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
                    }).ToList();

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
                    }).Where(v => v.IdDeptoCiudad == v.IdDepto).ToList();

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

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaPlanoAll(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                var InforPl = context.PlResumenTipificacionAll(IdDepto, IdCiudad, IdAspNetUser).Where(x => x.Grupo == Grupo).ToList();

                var Plano = InforPl
                            .Join(context.ExpedienteDocumentos, l => l.Plano, m => m.Id, (l, m) => new { m.Estado, l.IdExpediente, m.IdRetencionDocumental })
                            .ToList();

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
                    }).ToList();

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
                    }).Where(v =>  v.IdDeptoCiudad == v.IdDepto).ToList();

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
                                Plano = context.ExpedienteDocumentos.Where(x => x.IdExpediente == c.IdExpediente && x.IdRetencionDocumental == 21 && x.Estado == true).Select(y => y.IdRetencionDocumental).FirstOrDefault(),
                                Orden = 1,
                                IdDepto = Convert.ToInt32(c.IdDepto),
                                IdMunicipio = c.IdCtMuncipio
                            }).ToList();
            }
            return Resumen;
        }

        public List<ResumenTipificacionAllModel> ConsultarResumenRegistroAll(string IdP)
        {
            var Resumen = new List<ResumenTipificacionAllModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];

                //Resumen = context.PlResumenTipificacionAll(IdDepto, IdCiudad, IdAspNetUser)
                //            .Join(context.Registro, b => b.IdExpediente, c => c.IdExpediente, (b, c) =>
                //             new { c.Estado, b.Id, b.IdExpediente, b.IdAspNetUser, b.Grupo, b.Plano, b.Orden, b.DeptoNombre, b.DeptoId, b.MunicNombre, b.MunicId })
                //            .Select(c => new ResumenTipificacionAllModel
                //            {
                //                Id = Convert.ToInt32(c.Id),
                //                IdExpediente = Convert.ToInt32(c.IdExpediente),
                //                IdAspNetUser = c.IdAspNetUser,
                //                Grupo = c.Estado.ToString(),
                //                Plano = c.Plano,
                //                Orden = 1,
                //                DeptoId = Convert.ToInt32(c.DeptoId),
                //                DeptoNombre = c.DeptoNombre,
                //                MunicId = c.MunicId,
                //                MunicNombre = c.MunicNombre
                //            }).ToList();
                Resumen = context.BaldiosPersonaNatural
                           .Join(context.Registro, b => b.id, c => c.IdExpediente, (b, c) =>
                            new {activo = c.EstadoRegistro, EstadoRegistro = c.Estado.Value, b.IdDepto,  b.id, b.IdAspNetUser, c.IdExpediente}).Where(c=>c.activo == true)
                           .Select(c => new ResumenTipificacionAllModel
                           {
                               Id = c.id,
                               IdExpediente = c.IdExpediente.Value,
                               IdAspNetUser = c.IdAspNetUser,
                               Grupo = c.EstadoRegistro.ToString(),
                               Plano = context.ExpedienteDocumentos.Where(x => x.IdExpediente == c.id & x.Estado == true & x.IdRetencionDocumental == 21).Select(f => f.IdExpediente.Value).FirstOrDefault(),
                               Orden = 1,
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

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaSinPlano(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];

                List<BaldiosPersonaNaturalModel> baldios_ = new List<BaldiosPersonaNaturalModel>();
                List<BaldiosPersonaNaturalModel> baldios_Estado = new List<BaldiosPersonaNaturalModel>();

                var baldios__ = context.BaldiosPersonaNatural.Where(v => v.IdDepto == IdDepto && v.IdCiudad == IdCiudad)
                           .Join(context.Registro, l => l.id, m => m.IdExpediente, (l, m) => new
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
                               l.NombreArchivo,
                               l.ArchivoVerificado,
                               l.RutaVerificado,
                               l.FiltroJairo,
                               l.IdAsignacion,
                               m.Estado
                           })
                           .ToList();

                if (Grupo == "True")
                {
                    baldios_Estado = baldios__.Where(v => v.Estado == true).Select(x => new BaldiosPersonaNaturalModel
                    {
                        id = x.id,
                        NumeroExpediente = x.NumeroExpediente,
                        IdDepto = x.IdDepto,
                        IdCiudad = x.IdCiudad,
                        Vereda = x.Vereda,
                        NombrePredio = x.NombrePredio,
                        NombreBeneficiario = x.NombreBeneficiario,
                        IdTipoIdentificacion = x.IdTipoIdentificacion,
                        Identificacion = x.Identificacion,
                        IdGenero = x.IdGenero,
                        IdTipoIdentificacionConyuge = x.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = x.IdentificacionConyuge,
                        NombreConyuge = x.NombreConyuge,
                        EstadoInicialMigracion = x.EstadoInicialMigracion,
                        IdAspNetUser = x.IdAspNetUser,
                        EstadoCaracterizacion = x.EstadoCaracterizacion,
                        RutaArchivoOriginal = x.RutaArchivoOriginal,
                        NombreArchivo = x.NombreArchivo,
                    }).ToList();
                }
                else if (Grupo == "False")
                {
                    baldios_Estado = baldios__.Where(v => v.Estado == false).Select(x => new BaldiosPersonaNaturalModel
                    {
                        id = x.id,
                        NumeroExpediente = x.NumeroExpediente,
                        IdDepto = x.IdDepto,
                        IdCiudad = x.IdCiudad,
                        Vereda = x.Vereda,
                        NombrePredio = x.NombrePredio,
                        NombreBeneficiario = x.NombreBeneficiario,
                        IdTipoIdentificacion = x.IdTipoIdentificacion,
                        Identificacion = x.Identificacion,
                        IdGenero = x.IdGenero,
                        IdTipoIdentificacionConyuge = x.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = x.IdentificacionConyuge,
                        NombreConyuge = x.NombreConyuge,
                        EstadoInicialMigracion = x.EstadoInicialMigracion,
                        IdAspNetUser = x.IdAspNetUser,
                        EstadoCaracterizacion = x.EstadoCaracterizacion,
                        RutaArchivoOriginal = x.RutaArchivoOriginal,
                        NombreArchivo = x.NombreArchivo,
                    }).ToList();
                }
                else
                {

                    baldios_Estado = baldios__.Where(v => v.Estado == null).Select(x => new BaldiosPersonaNaturalModel
                    {
                        id = x.id,
                        NumeroExpediente = x.NumeroExpediente,
                        IdDepto = x.IdDepto,
                        IdCiudad = x.IdCiudad,
                        Vereda = x.Vereda,
                        NombrePredio = x.NombrePredio,
                        NombreBeneficiario = x.NombreBeneficiario,
                        IdTipoIdentificacion = x.IdTipoIdentificacion,
                        Identificacion = x.Identificacion,
                        IdGenero = x.IdGenero,
                        IdTipoIdentificacionConyuge = x.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = x.IdentificacionConyuge,
                        NombreConyuge = x.NombreConyuge,
                        EstadoInicialMigracion = x.EstadoInicialMigracion,
                        IdAspNetUser = x.IdAspNetUser,
                        EstadoCaracterizacion = x.EstadoCaracterizacion,
                        RutaArchivoOriginal = x.RutaArchivoOriginal,
                        NombreArchivo = x.NombreArchivo,
                    }).ToList();

                }
                
                var Plano = baldios_Estado
                          .Join(context.Registro, l => l.id, m => m.IdExpediente, (l, m) => new
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
                              m.Estado
                          }).ToList();

                var DeptoBal = Plano
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

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaSinPlanoAll(string IdP)
        {
            string[] Parametros = IdP.Split('_');
            int IdDepto = Convert.ToInt32(Parametros[0]);
            int IdCiudad = Convert.ToInt32(Parametros[1]);
            string IdAspNetUser = Parametros[2];
            string Grupo = Parametros[3];
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();

            using (ZonasFEntities context = new ZonasFEntities())
            {
                List<RegistroModel> RegistroQ = new List<RegistroModel>();

                var Plano = context.BaldiosPersonaNatural
                            .Join(context.Registro, l => l.id, m => m.IdExpediente, (l, m) => new
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
                                EstadoRegistro = m.Estado,
                                EstadoRegistroActuve = m.EstadoRegistro
                            }).Where(x=>x.EstadoRegistroActuve == true).ToList();

                var DeptoBal = Plano
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
                        NombrDepto = c.NOMBRE,
                        b.EstadoRegistro
                    }).ToList();

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
                        IdDeptoCiudad = c.IdCtDepto,
                        b.EstadoRegistro
                    }).Where(v => v.IdDepto == v.IdDeptoCiudad).ToList();

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
                        NombreTipoIdentificacion = c.NOMBRE,
                        b.EstadoRegistro
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
                        NombreGenero = c.NOMBRE,
                        b.EstadoRegistro
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
                        NombreTipoIdentificacionConyuge = c.NOMBRE,
                        b.EstadoRegistro
                    }).ToList();

                if (Grupo == "True")
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.EstadoRegistro == true).Select(c => new BaldiosPersonaNaturalModel
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
                else if (Grupo == "False")
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.EstadoRegistro == false).Select(c => new BaldiosPersonaNaturalModel
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
                else
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.EstadoRegistro == null).Select(c => new BaldiosPersonaNaturalModel
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

            }

            
            return Resumen;
        }
        
        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaConPlano(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();
            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];
                bool GrupoIn = default;
                if (Grupo == "True")
                {
                    GrupoIn = true;
                }
                else if (Grupo == "False")
                {
                    GrupoIn = false;
                }

                var Baldios = context.BaldiosPersonaNatural
                            .Join(context.Registro, l => l.id, m => m.IdExpediente, (l, m) => new
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
                                estadoResgistro = m.Estado
                            }).Where(x => x.estadoResgistro == GrupoIn && x.IdDepto == IdDepto && x.IdCiudad == IdCiudad).ToList();

                var plano = Baldios.Join(context.ExpedienteDocumentos, l => l.id, m => m.IdExpediente.Value, (l, m) => new
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
                    m.Estado,
                    m.IdRetencionDocumental,
                    EstadoRetencion = m.Estado
                })
                       .Where(x => x.IdRetencionDocumental == 21 && x.Estado == true)
                       .GroupBy(x => x.id)
                       .Select(c => new BaldiosPersonaNaturalModel
                       {
                           id = c.Select(x => x.id).FirstOrDefault(),
                           NumeroExpediente = c.Select(x => x.NumeroExpediente).FirstOrDefault(),
                           IdDepto = c.Select(x => x.IdDepto).FirstOrDefault(),
                           IdCiudad = c.Select(x => x.IdCiudad).FirstOrDefault(),
                           Vereda = c.Select(x => x.Vereda).FirstOrDefault(),
                           NombrePredio = c.Select(x => x.NombrePredio).FirstOrDefault(),
                           NombreBeneficiario = c.Select(x => x.NombreBeneficiario).FirstOrDefault(),
                           IdTipoIdentificacion = c.Select(x => x.IdTipoIdentificacion).FirstOrDefault(),
                           Identificacion = c.Select(x => x.Identificacion).FirstOrDefault(),
                           IdGenero = c.Select(x => x.IdGenero).FirstOrDefault(),
                           IdTipoIdentificacionConyuge = c.Select(x => x.IdTipoIdentificacionConyuge).FirstOrDefault(),
                           IdentificacionConyuge = c.Select(x => x.IdentificacionConyuge).FirstOrDefault(),
                           NombreConyuge = c.Select(x => x.NombreConyuge).FirstOrDefault(),
                           EstadoInicialMigracion = c.Select(x => x.EstadoInicialMigracion).FirstOrDefault(),
                           IdAspNetUser = c.Select(x => x.IdAspNetUser).FirstOrDefault(),
                           EstadoCaracterizacion = c.Select(x => x.EstadoCaracterizacion).FirstOrDefault(),
                           RutaArchivoOriginal = c.Select(x => x.RutaArchivoOriginal).FirstOrDefault(),
                       }).ToList();

                var DeptoBal = plano
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

        public List<BaldiosPersonaNaturalModel> ConsultarResumenListaConPlanoAll(string IdP)
        {
            List<BaldiosPersonaNaturalModel> Resumen = new List<BaldiosPersonaNaturalModel>();

            using (ZonasFEntities context = new ZonasFEntities())
            {
                string[] Parametros = IdP.Split('_');
                int IdDepto = Convert.ToInt32(Parametros[0]);
                int IdCiudad = Convert.ToInt32(Parametros[1]);
                string IdAspNetUser = Parametros[2];
                string Grupo = Parametros[3];
            

                var Baldios = context.BaldiosPersonaNatural
                            .Join(context.Registro, l => l.id, m => m.IdExpediente, (l, m) => new
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
                                estadoResgistro = m.Estado,
                                estadoResgistroActive = m.EstadoRegistro
                            }).Where(x => x.estadoResgistroActive == true).ToList();

                var plano = Baldios.Join(context.ExpedienteDocumentos, l => l.id, m => m.IdExpediente.Value, (l, m) => new
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
                    m.Estado,
                    m.IdRetencionDocumental,
                    EstadoRetencion = m.Estado,
                    l.estadoResgistro
                })
                       .Where(x => x.IdRetencionDocumental == 21 && x.Estado == true)
                       .GroupBy(x => x.id)
                       .ToList();

                var DeptoBal = plano
                    .Join(context.CtDepto, b => b.Select(x => x.IdDepto).FirstOrDefault(), c => c.ID_CT_DEPTO, (b, c) => new
                    {
                        NumeroExpediente = b.Select(x => x.NumeroExpediente).FirstOrDefault(),
                        IdDepto = b.Select(x => x.IdDepto).FirstOrDefault(),
                        IdCiudad = b.Select(x => x.IdCiudad).FirstOrDefault(),
                        Vereda = b.Select(x => x.Vereda).FirstOrDefault(),
                        NombrePredio = b.Select(x => x.NombrePredio).FirstOrDefault(),
                        NombreBeneficiario = b.Select(x => x.NombreBeneficiario).FirstOrDefault(),
                        IdTipoIdentificacion = b.Select(x => x.IdTipoIdentificacion).FirstOrDefault(),
                        Identificacion = b.Select(x => x.Identificacion).FirstOrDefault(),
                        IdGenero = b.Select(x => x.IdGenero).FirstOrDefault(),
                        IdTipoIdentificacionConyuge = b.Select(x => x.IdTipoIdentificacionConyuge).FirstOrDefault(),
                        IdentificacionConyuge = b.Select(x => x.IdentificacionConyuge).FirstOrDefault(),
                        NombreConyuge = b.Select(x => x.NombreConyuge).FirstOrDefault(),
                        EstadoInicialMigracion = b.Select(x => x.EstadoInicialMigracion).FirstOrDefault(),
                        IdAspNetUser = b.Select(x => x.IdAspNetUser).FirstOrDefault(),
                        EstadoCaracterizacion = b.Select(x => x.EstadoCaracterizacion).FirstOrDefault(),
                        RutaArchivoOriginal = b.Select(x => x.RutaArchivoOriginal).FirstOrDefault(),
                        NombrDepto = c.NOMBRE,
                        estadoResgistro = b.Select(x => x.estadoResgistro).FirstOrDefault(),
                        id = b.Select(x => x.id).FirstOrDefault(),

                    }).ToList();

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
                        IdDeptoCiudad = c.IdCtDepto,
                        b.estadoResgistro
                    }).Where(t => t.IdDepto == t.IdDeptoCiudad).ToList();

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
                        NombreTipoIdentificacion = c.NOMBRE,
                        b.estadoResgistro
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
                        NombreGenero = c.NOMBRE,
                        b.estadoResgistro
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
                        NombreTipoIdentificacionConyuge = c.NOMBRE,
                        b.estadoResgistro
                    }).ToList();

                //Resumen = TipoIdConyugeBal
                //    .Select(c => new BaldiosPersonaNaturalModel
                //    {
                //        id = c.id,
                //        NumeroExpediente = c.NumeroExpediente,
                //        IdDepto = c.IdDepto,
                //        IdCiudad = c.IdCiudad,
                //        Vereda = c.Vereda,
                //        NombrePredio = c.NombrePredio,
                //        NombreBeneficiario = c.NombreBeneficiario,
                //        IdTipoIdentificacion = c.IdTipoIdentificacion,
                //        Identificacion = c.Identificacion,
                //        IdGenero = c.IdGenero,
                //        IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                //        IdentificacionConyuge = c.IdentificacionConyuge,
                //        NombreConyuge = c.NombreConyuge,
                //        EstadoInicialMigracion = c.EstadoInicialMigracion,
                //        IdAspNetUser = c.IdAspNetUser,
                //        EstadoCaracterizacion = c.EstadoCaracterizacion,
                //        RutaArchivoOriginal = c.RutaArchivoOriginal,
                //        NombreIdDepto = c.NombrDepto,
                //        NombreIdCiudad = c.NombreMunicipio,
                //        NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                //        NombreIdGenero = c.NombreGenero,
                //        NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                //        b.estadoResgistro
                //    }).ToList();

                if (Grupo == "True")
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.estadoResgistro == true).Select(c => new BaldiosPersonaNaturalModel
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
                else if (Grupo == "False")
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.estadoResgistro == false).Select(c => new BaldiosPersonaNaturalModel
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
                else
                {
                    Resumen = TipoIdConyugeBal.Where(x => x.estadoResgistro == null).Select(c => new BaldiosPersonaNaturalModel
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

            }
            return Resumen;
        }
    }
}