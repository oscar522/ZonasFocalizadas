﻿using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class BaldiosPersonaNaturalLogic
    {
        BaldiosPersonaNatural ModCtx = new BaldiosPersonaNatural();

        public BaldiosPersonaNaturalModel Crear(BaldiosPersonaNaturalModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                BaldiosPersonaNatural Nuevo = new BaldiosPersonaNatural
                {
                    id = a.id,
                    NumeroExpediente = a.NumeroExpediente,
                    IdDepto = a.IdDepto,
                    IdCiudad = a.IdCiudad,
                    Vereda = a.Vereda,
                    NombrePredio = a.NombrePredio,
                    NombreBeneficiario = a.NombreBeneficiario,
                    IdTipoIdentificacion = a.IdTipoIdentificacion,
                    Identificacion = a.Identificacion,
                    IdGenero = a.IdGenero,
                    IdTipoIdentificacionConyuge = a.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = a.IdentificacionConyuge,
                    NombreConyuge = a.NombreConyuge,
                    EstadoInicialMigracion = a.EstadoInicialMigracion,
                    IdAspNetUser = a.IdAspNetUser,
                    EstadoCaracterizacion = a.EstadoCaracterizacion,
                    RutaArchivoOriginal = a.RutaArchivoOriginal
                };
                Ctx.BaldiosPersonaNatural.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
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
                }).OrderBy(d => d.EstadoCaracterizacion);

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
                }).OrderByDescending(d =>d.EstadoCaracterizacion );

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

        public BaldiosPersonaNaturalModel Actualizar(BaldiosPersonaNaturalModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.BaldiosPersonaNatural.Where(s => s.id == a.id).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.id = a.id;
                    ResCtx.NumeroExpediente = a.NumeroExpediente;
                    ResCtx.IdDepto = a.IdDepto;
                    ResCtx.IdCiudad = a.IdCiudad;
                    ResCtx.Vereda = a.Vereda;
                    ResCtx.NombrePredio = a.NombrePredio;
                    ResCtx.NombreBeneficiario = a.NombreBeneficiario;
                    ResCtx.IdTipoIdentificacion = a.IdTipoIdentificacion;
                    ResCtx.Identificacion = a.Identificacion;
                    ResCtx.IdGenero = a.IdGenero;
                    ResCtx.IdTipoIdentificacionConyuge = a.IdTipoIdentificacionConyuge;
                    ResCtx.IdentificacionConyuge = a.IdentificacionConyuge;
                    ResCtx.NombreConyuge = a.NombreConyuge;
                    ResCtx.EstadoInicialMigracion = a.EstadoInicialMigracion;
                    ResCtx.IdAspNetUser = a.IdAspNetUser;
                    ResCtx.EstadoCaracterizacion = a.EstadoCaracterizacion;
                    ResCtx.RutaArchivoOriginal = a.RutaArchivoOriginal;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.BaldiosPersonaNatural.Where(s => s.id == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    // ResCtx.Estado = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        public String BuscarArchivos(int id)
        {
            string ruta = @"" + ConfigurationManager.AppSettings["PdfPath"]; // RUTA DE LOS ARCHIVOS

            DirectoryInfo directory = new DirectoryInfo(ruta); // Obtiene la info del directoria

            var Directory_ = directory.GetDirectories().Select(c => new ArchivosModel { NOMBRE = c.ToString(), DIR = c.FullName }).ToList(); // obtiene los directorios

            var files_ = directory.GetFiles("*.pdf", SearchOption.AllDirectories).Select(c => new ArchivosModel { NOMBRE = c.ToString(), DIR = c.FullName }).ToList(); // obtiene los archivos

            ZonasFEntities Ctx = new ZonasFEntities(); // contesto 

            //var lista = Ctx.BaldiosPersonaNatural.Where(xa => xa.NumeroExpediente.Equals("B95000100012009")).Select(x => x.NumeroExpediente).Take(1).ToList(); // lista de expedientes 
            var lista = Ctx.BaldiosPersonaNatural.Where(xa => xa.NumeroExpediente.Contains("B")).Select(x => x.NumeroExpediente).ToList(); // lista de expedientes 

            string ResultConcat = "error";
            int i = 0;
            foreach (string Nombre in lista) // recorre los nombres de la lista de expediente 
            {
                i++;
                string Depto = Nombre.Substring(1, 2); // divide el nombre para obtener el depto
                string Munic = Nombre.Substring(3, 4); // divide el nombre para obtener el minicipio

                var Searchfiles = files_.Where(x => x.NOMBRE.Contains(Nombre)).FirstOrDefault();

                var SearchDirectory = Directory_.Where(x => x.NOMBRE.Contains(Nombre)).FirstOrDefault();

                if (Directory.Exists(ruta + "/Deptos/" + Depto)) // verificamos si el directorio de departamentos existe
                {
                    if (!Directory.Exists(ruta + "/Deptos/" + Depto + "/" + Munic)) // verificamos si el directorio de municipios existe
                    {
                        Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                    }
                }
                else // si no existe se crea un depto y minicipio
                {
                    Directory.CreateDirectory(ruta + "/Deptos/" + Depto);
                    Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);

                }

                if (Searchfiles != null)
                {
                    string Result = GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);
                    if (Result == "")
                    {

                        string ResultActualiza = ActualizarExpediente(Nombre, "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE, 0, Searchfiles.NOMBRE);
                        ResultConcat = ResultConcat + "Ac=" + ResultActualiza;
                    }
                    ResultConcat = ResultConcat + Result + "*";
                }
                else if (SearchDirectory != null)
                {
                    if (!Directory.Exists(ruta + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE)) // verificamos si el directorio de municipios existe
                    {
                        Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE);
                    }

                    DirectoryInfo directoryFile = new DirectoryInfo(SearchDirectory.DIR); // Obtiene la info del directoria

                    var filesFile = directoryFile.GetFiles("*.*", SearchOption.AllDirectories).Select(c => new ArchivosModel { NOMBRE = c.ToString(), DIR = c.FullName }).ToList(); // obtiene los archivos

                    string PathDirectory = "";
                    string PathDirectoryName = "";
                    foreach (ArchivosModel Dir in filesFile) // recorre los nombres de la lista de expediente 
                    {
                        string Result = GuardarArchivo(Dir.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE + "/" + Dir.NOMBRE);
                        if (Result == "")
                        {
                            PathDirectory = PathDirectory + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE + "/" + Dir.NOMBRE + "+";
                            PathDirectoryName = PathDirectoryName + Dir.NOMBRE + "+";

                        }
                        ResultConcat = ResultConcat + Result + "*";
                    }
                    string ResultActualiza = ActualizarExpediente(Nombre, PathDirectory, 1, PathDirectoryName);
                    ResultConcat = ResultConcat + "Ac=" + ResultActualiza;
                }

                #region comentarios
                //if (Searchfiles.NOMBRE != "" ) 
                //{ // busca si el nombre del expediente esta en los archivos

                //    if (Directory.Exists(ruta+"/Deptos/"+Depto)) // verificamos si el directorio de departamentos existe
                //    {
                //        if (Directory.Exists(ruta + "/Deptos/"+Depto+"/"+Munic)) // verificamos si el directorio de municipios existe
                //        {
                //            try
                //            {
                //                GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);
                //            }
                //            catch (IOException copyError)
                //            {
                //                Console.WriteLine(copyError.Message);
                //            }
                //        }
                //        else // si no existe el directorio crea un municipio 
                //        {
                //            Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                //            GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);
                //        }
                //    }
                //    else // si no existe se crea un depto y minicipio
                //    {
                //        Directory.CreateDirectory(ruta + "/Deptos/" + Depto);
                //        Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                //        GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);

                //    }

                //} 
                //else { // si no, verifica si es un directorio


                //    if (SearchDirectory.NOMBRE != "")
                //    { // busca si el nombre del expediente esta en los archivos

                //        if (Directory.Exists(ruta + "/Deptos/" + Depto)) // verificamos si el directorio de departamentos existe
                //        {
                //            if (Directory.Exists(ruta + "/Deptos/" + Depto + "/" + Munic)) // verificamos si el directorio de municipios existe
                //            {
                //                if (!Directory.Exists(ruta + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE)) // verificamos si el directorio de municipios existe
                //                { 
                //                    Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                //                }
                //                GuardarArchivo(SearchDirectory.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + SearchDirectory.NOMBRE);
                //            }
                //            else // si no existe el directorio crea un municipio 
                //            {
                //                Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                //                GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);
                //            }
                //        }
                //        else // si no existe se crea un depto y minicipio
                //        {
                //            Directory.CreateDirectory(ruta + "/Deptos/" + Depto);
                //            Directory.CreateDirectory(ruta + "/Deptos/" + Depto + "/" + Munic);
                //            GuardarArchivo(Searchfiles.DIR, ruta + "/Deptos/" + Depto + "/" + Munic + "/" + Searchfiles.NOMBRE);

                //        }

                //    }




                //}
                #endregion
            }


            return ResultConcat;
        }

        public string GuardarArchivo(string Origen, string Destino)
        {
            string res = "";
            try
            {
                File.Copy(Origen, Destino);
            }
            catch (IOException copyError)
            {
                Console.WriteLine(copyError.Message);
                res = Origen;
            }
            return res;
        }

        public string ActualizarExpediente(string Id, string Path, int Tipo, string Nombre)
        {
            string res = "";
            using (var Ctx = new ZonasFEntities())
            {
                try
                {
                    var ResCtx = Ctx.BaldiosPersonaNatural.Where(s => s.NumeroExpediente == Id).FirstOrDefault();
                    if (ResCtx != null) // --------------------- //
                    {
                        ResCtx.RutaArchivoOriginal = Path;
                        ResCtx.NombreArchivo = Nombre;
                        ResCtx.ArchivoVerificado = Tipo;
                        Ctx.SaveChanges();
                    }
                }
                catch (IOException copyError)
                {
                    Console.WriteLine(copyError.Message);
                    res = Id;
                }
            }
            return res;
        }

        public CtGeneroModel UpdateEstatusArchivoVerificado(CtGeneroModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                var Expediente = Ctx.BaldiosPersonaNatural.Where(x => x.id == a.ID_GENERO).FirstOrDefault();
                Expediente.ArchivoVerificado = Convert.ToInt16(a.NOMBRE);
                Ctx.SaveChanges();
                a.NOMBRE = Expediente.NumeroExpediente;
                return a;
            }
        }

        public CtGeneroModel UpdateEstatusEstadoCaracterizacion(CtGeneroModel a)
        {
            
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                var Expediente = Ctx.BaldiosPersonaNatural.Where(x => x.id == a.ID_GENERO).FirstOrDefault();
                Expediente.EstadoCaracterizacion = a.NOMBRE == "1" ? true : false;
                Ctx.SaveChanges();
                a.NOMBRE = Expediente.NumeroExpediente;
                return a;
            }
        }
    }
}