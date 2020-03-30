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

            string[] words = IdP.Split('-');

            int Depto = Convert.ToInt32(words[0]);
            int Munic = Convert.ToInt32(words[1]);
            string Exped = words[2];
            ZonasFEntities Ctx = new ZonasFEntities();

            List<BaldiosPersonaNatural> listaBaldios = new List<BaldiosPersonaNatural>();

            if (Depto != 0 && Exped != "N_A")
            {
                if (Munic != 0)
                {
                    listaBaldios = Ctx.BaldiosPersonaNatural
                  .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b })
                    .Join(Ctx.CtCiudad, b => b.b.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.b, IdCtDeptoC = c.IdCtDepto })
                    .Where(w => w.b.IdDepto == Depto && w.b.IdCiudad == Munic && w.IdCtDeptoC == Depto && w.b.NumeroExpediente.Contains(Exped))
                    .Select(x => x.b).ToList();
                }
                else
                {
                    listaBaldios = Ctx.BaldiosPersonaNatural
                     .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new BaldiosPersonaNatural())
                     .Where(w => w.IdDepto == Depto && w.NumeroExpediente.Contains(Exped))
                     .ToList();
                }
            }
            if (Depto != 0 && Exped == "N_A")
            {
                if (Munic != 0)
                {
                    listaBaldios = Ctx.BaldiosPersonaNatural
                    .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b })
                    .Join(Ctx.CtCiudad, b => b.b.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.b, IdCtDeptoC = c.IdCtDepto })
                    .Where(w => w.b.IdDepto == Depto && w.b.IdCiudad == Munic && w.IdCtDeptoC == Depto )
                    .Select(x => x.b).ToList();
                }
                else
                {
                    listaBaldios = Ctx.BaldiosPersonaNatural
                     .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b })
                     .Where(w => w.b.IdDepto == Depto )
                     .Select(c => c.b)
                     .ToList();
                }
            }
             if (Depto == 0 && Exped != "N_A") {

                listaBaldios = Ctx.BaldiosPersonaNatural
                .Where(w =>  w.NumeroExpediente.Contains(Exped))
                .ToList();
            }


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
                 .Where(xa => xa.IdExpediente == Id)
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { Registro = b, c.NumeroExpediente, BaldiosPersonaNatural  = c})
                 .Join(Ctx.Users, b => b.Registro.IdAspNetUser, c => c.Id_Hash, (b, c) => new {b.BaldiosPersonaNatural, b.Registro, NombreUsuario = c.Name + " " + c.FirstName + " " + c.LastName, c.Id_Hash })
                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) => new { b.BaldiosPersonaNatural, b.Registro, b.NombreUsuario, AspNetUserRoles = c , b.Id_Hash })
                .Join(Ctx.AspNetRoles, b => b.AspNetUserRoles.RoleId, c => c.Id, (b, c) => new { b.BaldiosPersonaNatural, b.Registro, Rol = c.Name, b.Id_Hash, b.NombreUsuario })
                 .Where(xa => xa.Registro.EstadoRegistro.Value == true && xa.Registro.IdExpediente == Id)
                .Select(a => new RegistroModel
                {
                    Id = a.Registro.Id,
                    IdExpediente = a.Registro.IdExpediente,
                    NumeroExpediente = a.BaldiosPersonaNatural.NumeroExpediente,
                    IdAspNetUser = a.Registro.IdAspNetUser,
                    FVerificacion = a.Registro.FVerificacion,
                    Estado = a.Registro.Estado,
                    Matricula = a.Registro.Matricula,
                    Fapertura = a.Registro.Fapertura,
                    TipoDocumento = a.Registro.TipoDocumento,
                    NumDocumento = a.Registro.NumDocumento,
                    FDocumento = a.Registro.FDocumento,
                    IdDepto = a.Registro.IdDepto,
                    NombreIdDepto = Ctx.CtDepto.Where(w => w.ID_CT_DEPTO == a.Registro.IdDepto).Select(xq => xq.NOMBRE).FirstOrDefault(),
                    IdMunicipio = a.Registro.IdMunicipio,
                    NombreIdMunicipio = Ctx.CtCiudad.Where(w => w.Id == a.Registro.IdMunicipio && w.IdCtDepto == a.Registro.IdDepto).Select(xq => xq.Nombre).FirstOrDefault(),
                    Area = a.Registro.Area,
                    CcSolicitante = a.Registro.CcSolicitante,
                    CcConyugue = a.Registro.CcConyugue,
                    Conyuge = a.Registro.Conyuge,
                    EstadoRegistro = a.Registro.EstadoRegistro,
                    UsuarioActualiza = a.Registro.UsuarioActualiza,
                    UsuarioModifica = a.Registro.UsuarioModifica,
                    NombreUsuario = a.NombreUsuario,
                    RolUsuario = a.Rol,

                });

            return lista.ToList();
        }

    }
}