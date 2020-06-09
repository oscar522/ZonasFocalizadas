using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class RegistroLogic
    {

        Registro ModCtx = new Registro();

        public RegistroModel Crear(RegistroModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                Registro Nuevo = new Registro
                {
                    Id = a.Id,
                    IdExpediente = a.IdExpediente,
                    IdAspNetUser = a.IdAspNetUser,
                    FVerificacion = a.FVerificacion,
                    Estado = a.Estado,
                    Matricula = a.Matricula,
                    Fapertura = a.Fapertura,
                    TipoDocumento = a.TipoDocumento,
                    NumDocumento = a.NumDocumento,
                    FDocumento = a.FDocumento,
                    IdDepto = a.IdDepto,
                    IdMunicipio = a.IdMunicipio,
                    Area = a.Area,
                    CcSolicitante = a.CcSolicitante.Value,
                    CcConyugue = a.CcConyugue,
                    Conyuge = a.Conyuge,
                    EstadoRegistro = a.EstadoRegistro,
                    UsuarioActualiza = a.UsuarioActualiza,
                    UsuarioModifica = a.UsuarioModifica

                };

                Ctx.Registro.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<RegistroModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Registro
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                .Where(x => x.caracte.EstadoRegistro == true).Select(a => new RegistroModel
                {
                    IdExpediente = a.caracte.IdExpediente,
                    IdAspNetUser = a.caracte.IdAspNetUser,
                    FVerificacion = a.caracte.FVerificacion,
                    Estado = a.caracte.Estado,
                    Matricula = a.caracte.Matricula,
                    Fapertura = a.caracte.Fapertura,
                    TipoDocumento = a.caracte.TipoDocumento,
                    NumDocumento = a.caracte.NumDocumento,
                    FDocumento = a.caracte.FDocumento,
                    IdDepto = a.caracte.IdDepto,
                    NombreIdDepto = Ctx.CtDepto.Where(w => w.ID_CT_DEPTO == a.caracte.IdDepto).Select(xq => xq.NOMBRE).FirstOrDefault(),
                    IdMunicipio = a.caracte.IdMunicipio,
                    NombreIdMunicipio = Ctx.CtCiudad.Where(w => w.Id == a.caracte.IdMunicipio && w.IdCtDepto == a.caracte.IdDepto).Select(xq => xq.Nombre).FirstOrDefault(),
                    EstadoRegistro = a.caracte.EstadoRegistro,

                }).ToList();

            return lista;
        }

        public List<RegistroModel> Consulta(string IdUser)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Registro
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                 new {b.UsuarioActualiza,b.UsuarioModifica, c.NumeroExpediente, b.Id, b.IdExpediente, b.IdAspNetUser, b.FVerificacion, b.Estado, b.Matricula, b.Fapertura, b.TipoDocumento, b.NumDocumento, b.FDocumento, b.IdDepto, b.IdMunicipio, b.Area, b.CcSolicitante, b.CcConyugue, b.Conyuge, b.EstadoRegistro })
                 .Where(xa => xa.EstadoRegistro.Value == true  && xa.IdAspNetUser == IdUser)
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
                    IdDepto =  a.IdDepto,
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


        public List<RegistroModel> ConsultaRevisados(string IdUser)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Registro
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                 new { b.UsuarioActualiza, b.UsuarioModifica, c.NumeroExpediente, b.Id, b.IdExpediente, b.IdAspNetUser, b.FVerificacion, b.Estado, b.Matricula, b.Fapertura, b.TipoDocumento, b.NumDocumento, b.FDocumento, b.IdDepto, b.IdMunicipio, b.Area, b.CcSolicitante, b.CcConyugue, b.Conyuge, b.EstadoRegistro })
                 .Where(xa => xa.EstadoRegistro.Value == true && xa.IdAspNetUser == IdUser && xa.Estado != null )
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

        public RegistroModel ConsultaId(long Id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Registro
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) =>
                 new {b.UsuarioActualiza,b.UsuarioModifica, c.NumeroExpediente, b.Id, b.IdExpediente, b.IdAspNetUser, b.FVerificacion, b.Estado, b.Matricula, b.Fapertura, b.TipoDocumento, b.NumDocumento, b.FDocumento, b.IdDepto, b.IdMunicipio, b.Area, b.CcSolicitante, b.CcConyugue, b.Conyuge, b.EstadoRegistro })
                 .Where(xa => xa.EstadoRegistro.Value == true && xa.Id == Id)
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

            return lista.FirstOrDefault();
        }



        //public RegistroModel ConsultarId(int id)
        //{
        //    ZonasFEntities Ctx = new ZonasFEntities();
        //    var a = Ctx.Registro
        //            .Join(Ctx.CtPais, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) => new { b.ESTADO, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })
        //            .Where(g => g.ESTADO == 1)
        //            .Where(w => w.ID_CT_DEPTO == id).Select(s => s).FirstOrDefault();
        //    RegistroModel x = new RegistroModel();
        //    x.ID_CT_DEPTO = a.ID_CT_DEPTO;
        //    x.ID_CT_PAIS = a.ID_CT_PAIS;
        //    x.NOMBRE_PAIS = a.NombrePais;
        //    x.NOMBRE = a.NOMBRE;
        //    return x;
        //}
        //public List<RegistroModel> ConsultarIdP(string IdP)
        //{
        //    int Idpa = Convert.ToInt32(IdP);
        //    ZonasFEntities Ctx = new ZonasFEntities();
        //    var lista = Ctx.Registro.Where(w => w.ID_CT_PAIS == Idpa).Select(a => new RegistroModel //
        //    {
        //        ID_CT_DEPTO = a.ID_CT_DEPTO,
        //        ID_CT_PAIS = a.ID_CT_PAIS,
        //        NOMBRE = a.NOMBRE
        //    });

        //    return lista.ToList();
        //}

        public RegistroModel Actualizar(RegistroModel a)
        {
            try
            {
                using (var Ctx = new ZonasFEntities())
                {
                    var ResCtx = Ctx.Registro.Where(s => s.Id == a.Id).FirstOrDefault();
                    if (ResCtx != null)
                    {
                        ResCtx.IdExpediente = a.IdExpediente;
                        ResCtx.IdAspNetUser = a.IdAspNetUser;
                        ResCtx.FVerificacion = a.FVerificacion;
                        ResCtx.Estado = a.Estado;
                        ResCtx.Matricula = a.Matricula;
                        ResCtx.Fapertura = a.Fapertura;
                        ResCtx.TipoDocumento = a.TipoDocumento;
                        ResCtx.NumDocumento = a.NumDocumento;
                        ResCtx.FDocumento = a.FDocumento;
                        ResCtx.IdDepto = a.IdDepto;
                        ResCtx.IdMunicipio = a.IdMunicipio;
                        ResCtx.Area = a.Area;
                        ResCtx.CcSolicitante = a.CcSolicitante.Value;
                        ResCtx.CcConyugue = a.CcConyugue;
                        ResCtx.Conyuge = a.Conyuge;
                        ResCtx.EstadoRegistro = a.EstadoRegistro;
                        ResCtx.UsuarioActualiza = a.UsuarioActualiza;
                        ResCtx.UsuarioModifica = a.UsuarioModifica;
                        Ctx.SaveChanges();
                    }
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.Registro.Where(s => s.Id == id).Where(s => s.EstadoRegistro == true).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.EstadoRegistro =false;
                    Ctx.SaveChanges();
                }
            }
            return "REALIZADO";
        }
    }
}