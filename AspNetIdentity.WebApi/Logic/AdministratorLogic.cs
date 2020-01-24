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

        public List<CtDeptoModel> ConsultarIdPCountDepto()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var Deptos = Ctx.BaldiosPersonaNatural.Where(f => f.RutaVerificado == 1)
                .ToList();
            var de = Deptos.Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new { c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE }).GroupBy(x => x.ID_CT_DEPTO)
                .Select(c => new CtDeptoModel
                {
                    ID_CT_DEPTO = c.Select(v => v.ID_CT_DEPTO).FirstOrDefault(),
                    ID_CT_PAIS = c.Count(),
                    NOMBRE = c.Select(v => v.NOMBRE).FirstOrDefault(),
                    NOMBRE_PAIS = c.Select(v => v.NOMBRE).FirstOrDefault(),
                }).ToList();
            return de;
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