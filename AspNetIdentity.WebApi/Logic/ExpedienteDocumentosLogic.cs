using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class ExpedienteDocumentosLogic
    {
        ExpedienteDocumentos ModCtx = new ExpedienteDocumentos();

        public ExpedienteDocumentosModel Crear(ExpedienteDocumentosModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                ExpedienteDocumentos Nuevo = new ExpedienteDocumentos
                {
                    Id = a.Id,
                    IdRetencionDocumental = a.IdRetencionDocumental,
                    IdExpediente = a.IdExpediente,
                    PagInicial = a.PagInicial,
                    PagFinal = a.PagFinal,
                    FechaInserta = a.FechaInserta,
                    FechaModifica = a.FechaModifica,
                    UsuarioInserta = a.UsuarioInserta,
                    UsuarioModifica = a.UsuarioModifica,
                    Archivo = a.Archivo,
                    ArchivoUrl = a.ArchivoUrl
                };
                var Expediente = Ctx.BaldiosPersonaNatural.Where(x => x.id == a.IdExpediente).FirstOrDefault();
                Expediente.ArchivoVerificado = a.EstadoExp;

                Nuevo.Estado = true;
                Ctx.ExpedienteDocumentos.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<ExpedienteDocumentosModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ExpedienteDocumentos.Where(x => x.Estado == true).Select(a => new ExpedienteDocumentosModel
            {
                Id = a.Id,
                IdRetencionDocumental = a.IdRetencionDocumental,
                IdExpediente = a.IdExpediente,
                PagInicial = a.PagInicial,
                PagFinal = a.PagFinal,
                Estado = a.Estado,
                FechaInserta = a.FechaInserta,
                FechaModifica = a.FechaModifica,
                UsuarioInserta = a.UsuarioInserta,
                UsuarioModifica = a.UsuarioModifica,
                Archivo = a.Archivo,
                ArchivoUrl = a.ArchivoUrl

            });

            return lista.ToList();
        }

        public ExpedienteDocumentosModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
           var a = Ctx.ExpedienteDocumentos
                                    .Join(Ctx.RetencionDocumental, d => d.IdRetencionDocumental, c => c.Id, (d, c) =>
                                     new {
                                         IdExpedienteDocumentos = d.Id,
                                         d.IdRetencionDocumental,
                                         d.IdExpediente,
                                         d.PagInicial,
                                         d.PagFinal,
                                         d.Archivo,
                                         EstadoExpedienteDocumentos = d.Estado,
                                         d.FechaInserta,
                                         d.FechaModifica,
                                         d.UsuarioInserta,
                                         d.UsuarioModifica,
                                         NombreRetencionDocumental = c.Nombre,
                                         EstadoRetencionDocumental = c.Estado,
                                         d.ArchivoUrl
                                     })
                                    .Join(Ctx.BaldiosPersonaNatural, e => e.IdExpediente.Value, f => f.id, (e, f) =>
                                     new
                                     {
                                         e.IdExpedienteDocumentos,
                                         e.IdRetencionDocumental,
                                         e.IdExpediente,
                                         e.PagInicial,
                                         e.PagFinal,
                                         e.Archivo,
                                         e.EstadoExpedienteDocumentos,
                                         e.FechaInserta,
                                         e.FechaModifica,
                                         e.UsuarioInserta,
                                         e.UsuarioModifica,
                                         e.NombreRetencionDocumental ,
                                         e.EstadoRetencionDocumental ,
                                         f.NumeroExpediente,
                                         e.ArchivoUrl
                                     })
                                    .Where(w => w.IdExpedienteDocumentos == id && w.EstadoExpedienteDocumentos == true).Select(s => s).FirstOrDefault();
            ExpedienteDocumentosModel b = new ExpedienteDocumentosModel();
            b.Id = a.IdExpedienteDocumentos;
            b.IdRetencionDocumental = a.IdRetencionDocumental;
            b.IdExpediente = a.IdExpediente;
            b.PagInicial = a.PagInicial;
            b.PagFinal = a.PagFinal;
            b.Estado = a.EstadoExpedienteDocumentos;
            b.FechaInserta = a.FechaInserta;
            b.FechaModifica = a.FechaModifica;
            b.UsuarioInserta = a.UsuarioInserta;
            b.UsuarioModifica = a.UsuarioModifica;
            b.Archivo = a.Archivo;
            b.NombreExpediente = a.NumeroExpediente;
            b.NombreRetencionDocumental = a.NombreRetencionDocumental;
            b.ArchivoUrl = a.ArchivoUrl;
            return b;
        }

        public List<ExpedienteDocumentosModel> ConsultarIdList(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.ExpedienteDocumentos
                     .Join(Ctx.RetencionDocumental, d => d.IdRetencionDocumental, c => c.Id, (d, c) =>
                         new { IdExpedienteDocumentos = d.Id,  IdRetencionDocumental = c.Id, c.Nombre, c.Estado, d.Id, d.IdExpediente, d.PagInicial, d.PagFinal, ExpedienteDocumentosEstado = d.Estado, d.FechaInserta, d.FechaModifica, d.UsuarioInserta, d.UsuarioModifica, d.Archivo, d.ArchivoUrl })
                     .Where(w => w.IdExpediente == id && w.ExpedienteDocumentosEstado == true).Select(x => new ExpedienteDocumentosModel
                     {
                         Id = x.IdExpedienteDocumentos,
                         IdRetencionDocumental = x.IdRetencionDocumental,
                         IdExpediente = x.IdExpediente,
                         PagInicial = x.PagInicial,
                         PagFinal = x.PagFinal,
                         Estado = x.ExpedienteDocumentosEstado,
                         FechaInserta = x.FechaInserta,
                         FechaModifica = x.FechaModifica,
                         UsuarioInserta = x.UsuarioInserta,
                         UsuarioModifica = x.UsuarioModifica,
                         NombreExpediente= "na",
                         NombreRetencionDocumental = x.Nombre,
                         Archivo = x.Archivo,
                         ArchivoUrl = x.ArchivoUrl
                     }).ToList();
            return a;
        }
        public List<ExpedienteDocumentosModel> ConsultarIdExpIdDocList(string id)
        {
            var SplitArray = id.Split(',');
            int IdExp = Convert.ToInt32(SplitArray[0]);
            int IdDoc = Convert.ToInt32(SplitArray[1]);

            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.ExpedienteDocumentos
                     .Join(Ctx.RetencionDocumental, d => d.IdRetencionDocumental, c => c.Id, (d, c) =>
                         new { IdRetencionDocumental = c.Id, c.Nombre, c.Estado, d.Id, d.IdExpediente, d.PagInicial, d.PagFinal, ExpedienteDocumentosEstado = d.Estado, d.FechaInserta, d.FechaModifica, d.UsuarioInserta, d.UsuarioModifica, d.Archivo, d.ArchivoUrl })
                     .Where(w => w.IdExpediente == IdExp &&  w.IdRetencionDocumental == IdDoc && w.ExpedienteDocumentosEstado == true).Select(x => new ExpedienteDocumentosModel
                     {
                         Id = x.Id,
                         IdRetencionDocumental = x.IdRetencionDocumental,
                         IdExpediente = x.IdExpediente,
                         PagInicial = x.PagInicial,
                         PagFinal = x.PagFinal,
                         Estado = x.ExpedienteDocumentosEstado,
                         FechaInserta = x.FechaInserta,
                         FechaModifica = x.FechaModifica,
                         UsuarioInserta = x.UsuarioInserta,
                         UsuarioModifica = x.UsuarioModifica,
                         NombreExpediente = "na",
                         NombreRetencionDocumental = x.Nombre,
                         Archivo = x.Archivo,
                         ArchivoUrl = x.ArchivoUrl
                     }).ToList();
            return a;
        }
        public ExpedienteDocumentosModel Actualizar(ExpedienteDocumentosModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ExpedienteDocumentos.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)

                    ResCtx.Id = a.Id;
                    ResCtx.IdRetencionDocumental = a.IdRetencionDocumental;
                    ResCtx.IdExpediente = a.IdExpediente;
                    ResCtx.PagInicial = a.PagInicial;
                    ResCtx.PagFinal = a.PagFinal;
                    ResCtx.Estado = a.Estado;
                    ResCtx.FechaInserta = a.FechaInserta;
                    ResCtx.FechaModifica = a.FechaModifica;
                    ResCtx.UsuarioInserta = a.UsuarioInserta;
                    ResCtx.UsuarioModifica = a.UsuarioModifica;
                    ResCtx.Archivo = a.Archivo;
                    ResCtx.ArchivoUrl = a.ArchivoUrl;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ExpedienteDocumentos.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}