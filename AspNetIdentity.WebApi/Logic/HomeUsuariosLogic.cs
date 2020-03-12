using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HomeUsuariosLogic
    {
        BaldiosPersonaNatural ModCtx = new BaldiosPersonaNatural();

        public int ConsultaCountRegistroUser(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var Baldios = Ctx.Registro.Where(w => w.IdAspNetUser == IdP && w.EstadoRegistro == true).Count();
            return Baldios;
        }

        public int ConsultaCountRegistroUserRevisados(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var Baldios = Ctx.Registro.Where(w => w.IdAspNetUser == IdP && w.Estado != null && w.EstadoRegistro == true ).Count();
            return Baldios;
        }

        public List<BaldiosPersonaNaturalModel> BuscaExpedientes(string IdP)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Where(w => w.NumeroExpediente.Contains(IdP)).ToList();
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
                }).OrderByDescending(d => d.EstadoCaracterizacion);

            #endregion
            return lista.ToList();
        }

        public List<RegistroModel> RegistroIdExpediente(long Id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Registro
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                 new {b.UsuarioActualiza, b.UsuarioModifica, c.NumeroExpediente, b.Id, b.IdExpediente, b.IdAspNetUser, b.FVerificacion, b.Estado, b.Matricula, b.Fapertura, b.TipoDocumento, b.NumDocumento, b.FDocumento, b.IdDepto, b.IdMunicipio, b.Area, b.CcSolicitante, b.CcConyugue, b.Conyuge, b.EstadoRegistro })
                 .Where(xa => xa.EstadoRegistro.Value == true && xa.IdExpediente == Id)
                .Select(a => new RegistroModel
                {
                    Id = a.Id,
                    IdExpediente = a.IdExpediente,
                    NumeroExpediente = a.NumeroExpediente,
                    IdAspNetUser = a.IdAspNetUser,
                    FVerificacion = a.FVerificacion,
                    Estado = a.Estado,
                    Matricula = a.Matricula,
                    Fapertura = a.Fapertura,
                    TipoDocumento = a.TipoDocumento,
                    NumDocumento = a.NumDocumento,
                    FDocumento = a.FDocumento,
                    IdDepto = a.IdDepto,
                    NombreIdDepto = Ctx.CtDepto.Where(w => w.ID_CT_DEPTO == a.IdDepto).Select(xq => xq.NOMBRE).FirstOrDefault(),
                    IdMunicipio = a.IdMunicipio,
                    NombreIdMunicipio = Ctx.CtCiudad.Where(w => w.Id == a.IdMunicipio && w.IdCtDepto == a.IdDepto).Select(xq => xq.Nombre).FirstOrDefault(),
                    Area = a.Area,
                    CcSolicitante = a.CcSolicitante,
                    CcConyugue = a.CcConyugue,
                    Conyuge = a.Conyuge,
                    EstadoRegistro = a.EstadoRegistro,
                    UsuarioActualiza = a.UsuarioActualiza,
                    UsuarioModifica = a.UsuarioModifica

                });

            return lista.ToList();
        }

    }
}