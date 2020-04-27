using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CaracterizacionSolicitanteLogic
    {
        CaracterizacionSolicitante ModCtx = new CaracterizacionSolicitante();

        public CaracterizacionSolicitanteModel Crear(CaracterizacionSolicitanteModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CaracterizacionSolicitante Nuevo = new CaracterizacionSolicitante
                {
                    Id = a.Id,
                    IdExpediente = a.IdExpediente,
                    NombreSolicitante = a.NombreSolicitante,
                    TipoDocumento = a.TipoDocumento,
                    NumeroIdentificacion = a.NumeroIdentificacion,
                    NombreConyuge = a.NombreConyuge,
                    TipoDocumentoConyuge = a.TipoDocumentoConyuge,
                    NumeroIdentificacionConyuge = a.NumeroIdentificacionConyuge,
                    FechaExpedicionSolicitante = a.FechaExpedicionSolicitante,
                    FechaExpedicionConyuge = a.FechaExpedicionConyuge,
                    
                    VFechaSolicitante = a.VFechaSolicitante,
                    VArchivoSolicitante = a.VArchivoSolicitante,
                    VFechaConyuge = a.VFechaConyuge,
                    VArchivoConyuge = a.VArchivoConyuge,
                    PFechaSolicitante = a.PFechaSolicitante,
                    PArchivoSolicitante = a.PArchivoSolicitante,
                    PFechaConyuge = a.PFechaConyuge,
                    PArchivoConyuge = a.PArchivoConyuge,
                    CFechaSolicitante = a.CFechaSolicitante,
                    CArchivoSolicitante = a.CArchivoSolicitante,
                    CFechaConyuge = a.CFechaConyuge,
                    CArchivoConyuge = a.CArchivoConyuge,
                    AFechaSolicitante = a.AFechaSolicitante,
                    AArchivoSolicitante = a.AArchivoSolicitante,
                    AFechaConyuge = a.AFechaConyuge,
                    AArchivoConyuge = a.AArchivoConyuge,
                    Gestion = a.Gestion,
                    IdAspNetUser = a.IdAspNetUser,
                    Estado = a.Estado,
                    FechaModificacion = DateTime.Now,

                };

                Ctx.CaracterizacionSolicitante.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionSolicitante
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { b, c })
                .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b = b.b, c = b.c, d = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, e = c })
                .Join(Ctx.Users, b => b.b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.b, b.c, b.d, b.e, f = c })
                .Join(Ctx.AspNetUserRoles, b => b.f.Id_Hash, c => c.UserId, (b, c) => new { b.b, b.c, b.d, b.e, b.f, g = c })
                .Join(Ctx.AspNetRoles, b => b.g.RoleId, c => c.Id, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, h = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, i = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, j = c, })
                .Where(x => x.b.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                {
                    Id = a.b.Id,
                    IdExpediente = a.b.IdExpediente,
                    NombreSolicitanteExpediente = a.c.NombreBeneficiario,
                    DocSolicitanteExpediente = a.c.Identificacion.ToString(),
                    TipoDocSolicitanteExpediente = a.i.NOMBRE,
                    IdTipoDocSolicitanteExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,

                    NombreConyugeExpediente = a.c.NombreConyuge,
                    DocConyugeExpediente = a.c.IdentificacionConyuge.ToString(),
                    TipoDocConyugeExpediente = a.j.NOMBRE,
                    IdTipoDocConyugeExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,

                    FechaExpedicionSolicitante = a.b.FechaExpedicionSolicitante,
                    FechaExpedicionConyuge = a.b.FechaExpedicionConyuge,

                    NumeroExpediente = a.c.NumeroExpediente,
                    NombreSolicitante = a.b.NombreSolicitante,
                    TipoDocumento = a.b.TipoDocumento,
                    NombreTipoDocumento = a.d.NOMBRE,
                    NumeroIdentificacion = a.b.NumeroIdentificacion,
                    NombreConyuge = a.b.NombreConyuge,
                    TipoDocumentoConyuge = a.b.TipoDocumentoConyuge,
                    NombreTipoDocumentoConyuge = a.e.NOMBRE,
                    NumeroIdentificacionConyuge = a.b.NumeroIdentificacionConyuge,
                    FModificacionExp = a.b.FModificacionExp.ToString(),

                    VFechaSolicitante = a.b.VFechaSolicitante,
                    VArchivoSolicitante = a.b.VArchivoSolicitante,
                    VFechaConyuge = a.b.VFechaConyuge,
                    VArchivoConyuge = a.b.VArchivoConyuge,
                    VFModificacion = a.b.VFModificacion.ToString(),
                    VvivoSolicitante = a.b.VVivoSolicitante,
                    VvivoConyuge = a.b.VVivoConyuge,

                    PFechaSolicitante = a.b.PFechaSolicitante,
                    PArchivoSolicitante = a.b.PArchivoSolicitante,
                    PFechaConyuge = a.b.PFechaConyuge,
                    PArchivoConyuge = a.b.PArchivoConyuge,
                    PFModificacion = a.b.PFModificacion.ToString(),

                    CFechaSolicitante = a.b.CFechaSolicitante,
                    CArchivoSolicitante = a.b.CArchivoSolicitante,
                    CFechaConyuge = a.b.CFechaConyuge,
                    CArchivoConyuge = a.b.CArchivoConyuge,
                    CFModificacion = a.b.CFModificacion.ToString(),

                    AFechaSolicitante = a.b.AFechaSolicitante,
                    AArchivoSolicitante = a.b.AArchivoSolicitante,
                    AFechaConyuge = a.b.AFechaConyuge,
                    AArchivoConyuge = a.b.AArchivoConyuge,
                    AFModificacion = a.b.AFModificacion.ToString(),

                    Gestion = a.b.Gestion,
                    IdAspNetUser = a.b.IdAspNetUser,
                    NombretUser = a.f.Name + " " + a.f.FirstName + " " + a.f.LastName,
                    RolUser = a.h.Name,
                    Estado = a.b.Estado,
                    FechaModificacion = a.b.FechaModificacion.ToString(),

                }); ;

            return lista.ToList();
        }

        public CaracterizacionSolicitanteModel ConsultarId(long id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.CaracterizacionSolicitante
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { b, c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b = b.b, c = b.c, d = c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, e = c })
                 .Join(Ctx.Users, b => b.b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.b, b.c, b.d, b.e, f = c })
                 .Join(Ctx.AspNetUserRoles, b => b.f.Id_Hash, c => c.UserId, (b, c) => new { b.b, b.c, b.d, b.e, b.f, g = c })
                 .Join(Ctx.AspNetRoles, b => b.g.RoleId, c => c.Id, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, h = c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, i = c})
                 .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i , j = c,  })
                 .Where(x => x.b.Id == id).Select(a => new CaracterizacionSolicitanteModel
                 {
                     Id = a.b.Id,
                     IdExpediente = a.b.IdExpediente,
                     NombreSolicitanteExpediente = a.c.NombreBeneficiario,
                     DocSolicitanteExpediente = a.c.Identificacion.ToString(),
                     TipoDocSolicitanteExpediente = a.i.NOMBRE,
                     IdTipoDocSolicitanteExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,
                     FModificacionExp = a.b.FModificacionExp.ToString(),

                     NombreConyugeExpediente = a.c.NombreConyuge,
                     DocConyugeExpediente = a.c.IdentificacionConyuge.ToString(),
                     TipoDocConyugeExpediente = a.j.NOMBRE,
                     IdTipoDocConyugeExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,

                     FechaExpedicionSolicitante = a.b.FechaExpedicionSolicitante,
                     FechaExpedicionConyuge = a.b.FechaExpedicionConyuge,

                     NumeroExpediente = a.c.NumeroExpediente,
                     NombreSolicitante = a.b.NombreSolicitante,
                     TipoDocumento = a.b.TipoDocumento,
                     NombreTipoDocumento = a.d.NOMBRE,
                     NumeroIdentificacion = a.b.NumeroIdentificacion,
                     NombreConyuge = a.b.NombreConyuge,
                     TipoDocumentoConyuge = a.b.TipoDocumentoConyuge,
                     NombreTipoDocumentoConyuge = a.e.NOMBRE,
                     NumeroIdentificacionConyuge = a.b.NumeroIdentificacionConyuge,

                     VFechaSolicitante = a.b.VFechaSolicitante,
                     VArchivoSolicitante = a.b.VArchivoSolicitante,
                     VFechaConyuge = a.b.VFechaConyuge,
                     VArchivoConyuge = a.b.VArchivoConyuge,
                     VFModificacion = a.b.VFModificacion.ToString(),
                     VvivoSolicitante = a.b.VVivoSolicitante,
                     VvivoConyuge = a.b.VVivoConyuge,

                     PFechaSolicitante = a.b.PFechaSolicitante,
                     PArchivoSolicitante = a.b.PArchivoSolicitante,
                     PFechaConyuge = a.b.PFechaConyuge,
                     PArchivoConyuge = a.b.PArchivoConyuge,
                     PFModificacion = a.b.PFModificacion.ToString(),

                     CFechaSolicitante = a.b.CFechaSolicitante,
                     CArchivoSolicitante = a.b.CArchivoSolicitante,
                     CFechaConyuge = a.b.CFechaConyuge,
                     CArchivoConyuge = a.b.CArchivoConyuge,
                     CFModificacion = a.b.CFModificacion.ToString(),

                     AFechaSolicitante = a.b.AFechaSolicitante,
                     AArchivoSolicitante = a.b.AArchivoSolicitante,
                     AFechaConyuge = a.b.AFechaConyuge,
                     AArchivoConyuge = a.b.AArchivoConyuge,
                     AFModificacion = a.b.AFModificacion.ToString(),

                     Gestion = a.b.Gestion,
                     IdAspNetUser = a.b.IdAspNetUser,
                     NombretUser = a.f.Name + " " + a.f.FirstName + " " + a.f.LastName,
                     RolUser = a.h.Name,
                     Estado = a.b.Estado,
                     FechaModificacion = a.b.FechaModificacion.ToString(),

                 }).FirstOrDefault();

            return lista;
        }

        public List<CaracterizacionSolicitanteModel> ConsultarIdUser(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.CaracterizacionSolicitante
                 .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { b, c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b = b.b, c = b.c, d = c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.b.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, e = c })
                 .Join(Ctx.Users, b => b.b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.b, b.c, b.d, b.e, f = c })
                 .Join(Ctx.AspNetUserRoles, b => b.f.Id_Hash, c => c.UserId, (b, c) => new { b.b, b.c, b.d, b.e, b.f, g = c })
                 .Join(Ctx.AspNetRoles, b => b.g.RoleId, c => c.Id, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, h = c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, i = c })
                 .Join(Ctx.CtTipoIdentificacion, b => b.c.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.b, b.c, b.d, b.e, b.f, b.g, b.h, b.i, j = c, })
                 .Where(x => x.b.IdAspNetUser == id && x.b.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                 {
                     Id = a.b.Id,
                     IdExpediente = a.b.IdExpediente,
                     NombreSolicitanteExpediente = a.c.NombreBeneficiario,
                     DocSolicitanteExpediente = a.c.Identificacion.ToString(),
                     TipoDocSolicitanteExpediente = a.i.NOMBRE,
                     IdTipoDocSolicitanteExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,

                     NombreConyugeExpediente = a.c.NombreConyuge,
                     DocConyugeExpediente = a.c.IdentificacionConyuge.ToString(),
                     TipoDocConyugeExpediente = a.j.NOMBRE,
                     IdTipoDocConyugeExpediente = a.i.ID_CT_TIPO_IDENTIFICACION,


                     NumeroExpediente = a.c.NumeroExpediente,
                     NombreSolicitante = a.b.NombreSolicitante,
                     TipoDocumento = a.b.TipoDocumento,
                     NombreTipoDocumento = a.d.NOMBRE,
                     NumeroIdentificacion = a.b.NumeroIdentificacion,
                     NombreConyuge = a.b.NombreConyuge,
                     TipoDocumentoConyuge = a.b.TipoDocumentoConyuge,
                     NombreTipoDocumentoConyuge = a.e.NOMBRE,
                     NumeroIdentificacionConyuge = a.b.NumeroIdentificacionConyuge,
                     FModificacionExp = a.b.FModificacionExp.ToString(),

                     VFechaSolicitante = a.b.VFechaSolicitante,
                     VArchivoSolicitante = a.b.VArchivoSolicitante,
                     VFechaConyuge = a.b.VFechaConyuge,
                     VArchivoConyuge = a.b.VArchivoConyuge,
                     VFModificacion = a.b.VFModificacion.ToString(),

                     PFechaSolicitante = a.b.PFechaSolicitante,
                     PArchivoSolicitante = a.b.PArchivoSolicitante,
                     PFechaConyuge = a.b.PFechaConyuge,
                     PArchivoConyuge = a.b.PArchivoConyuge,
                     PFModificacion = a.b.PFModificacion.ToString(),

                     CFechaSolicitante = a.b.CFechaSolicitante,
                     CArchivoSolicitante = a.b.CArchivoSolicitante,
                     CFechaConyuge = a.b.CFechaConyuge,
                     CArchivoConyuge = a.b.CArchivoConyuge,
                     CFModificacion = a.b.CFModificacion.ToString(),

                     AFechaSolicitante = a.b.AFechaSolicitante,
                     AArchivoSolicitante = a.b.AArchivoSolicitante,
                     AFechaConyuge = a.b.AFechaConyuge,
                     AArchivoConyuge = a.b.AArchivoConyuge,
                     AFModificacion = a.b.AFModificacion.ToString(),

                     Gestion = a.b.Gestion,
                     IdAspNetUser = a.b.IdAspNetUser,
                     NombretUser = a.f.Name + " " + a.f.FirstName + " " + a.f.LastName,
                     RolUser = a.h.Name,
                     Estado = a.b.Estado,
                     FechaModificacion = a.b.FechaModificacion.ToString(),

                 }).ToList();

            return lista;
        }

        public CaracterizacionSolicitanteModel Actualizar(CaracterizacionSolicitanteModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var Entity = Ctx.CaracterizacionSolicitante.Where(s => s.Id == a.Id).FirstOrDefault();
                if (Entity != null)
                {
                    if (a.Gestion == 1)
                    {


                        if (a.NombreSolicitante != "N_A")
                        {
                            Entity.NombreSolicitante = a.NombreSolicitante;
                        }

                        if (a.TipoDocumento != 0)
                        {
                            Entity.TipoDocumento = a.TipoDocumento;
                        }

                        if (a.NumeroIdentificacion != 0)
                        {
                            Entity.NumeroIdentificacion = a.NumeroIdentificacion;
                        }

                        if (a.NombreConyuge != "N_A")
                        {
                            Entity.NombreConyuge = a.NombreConyuge;
                        }
                        if (a.TipoDocumentoConyuge != 0)
                        {
                            Entity.TipoDocumentoConyuge = a.TipoDocumentoConyuge;
                        }
                        if (a.NumeroIdentificacionConyuge != 0)
                        {
                            Entity.NumeroIdentificacionConyuge = a.NumeroIdentificacionConyuge;
                        }
                        string DateSol = a.FechaExpedicionSolicitante.ToString();
                        string DateCon = a.FechaExpedicionConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00")
                        {
                            Entity.FechaExpedicionSolicitante = a.FechaExpedicionSolicitante;
                        }

                        if (DateCon != "1/1/1900 00:00:00")
                        {
                            Entity.FechaExpedicionConyuge = a.FechaExpedicionConyuge;
                        }

                        Entity.FModificacionExp = DateTime.Now;

                    } else if (a.Gestion == 2) {

                        string DateSol = a.VFechaSolicitante.ToString();
                        string DateCon = a.VFechaConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00")
                        {
                            Entity.VFechaSolicitante = a.VFechaSolicitante;
                        }
                        if (a.VArchivoSolicitante != "N_A")
                        {
                            Entity.VArchivoSolicitante = a.VArchivoSolicitante;
                        }
                        if (DateCon != "1/1/1900 00:00:00")
                        {
                            Entity.VFechaConyuge = a.VFechaConyuge;
                        }
                        if (a.VArchivoConyuge != "N_A")
                        {
                            Entity.VArchivoConyuge = a.VArchivoConyuge;
                        }

                        Entity.VVivoSolicitante = a.VvivoSolicitante;
                        Entity.VVivoConyuge = a.VvivoConyuge;
                        Entity.VFModificacion = DateTime.Now;

                    } else if (a.Gestion == 3) {

                        string DateSol = a.PFechaSolicitante.ToString();
                        string DateCon = a.PFechaConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00")
                        {
                            Entity.PFechaSolicitante = a.PFechaSolicitante;
                        }
                        if (a.PArchivoSolicitante != "N_A")
                        {
                            Entity.PArchivoSolicitante = a.PArchivoSolicitante;
                        }
                        if (DateCon != "1/1/1900 00:00:00")
                        {
                            Entity.PFechaConyuge = a.PFechaConyuge;
                        }
                        if (a.PArchivoConyuge != "N_A")
                        {
                            Entity.PArchivoConyuge = a.PArchivoConyuge;
                        }

                        Entity.PFModificacion = DateTime.Now;

                    } else if (a.Gestion == 4) {
                        
                        string DateSol = a.CFechaSolicitante.ToString();
                        string DateCon = a.CFechaConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00")
                        {
                            Entity.CFechaSolicitante = a.CFechaSolicitante;
                        }
                        if (a.CArchivoSolicitante != "N_A")
                        {
                            Entity.CArchivoSolicitante = a.CArchivoSolicitante;
                        }
                        if (DateCon != "1/1/1900 00:00:00")
                        {
                            Entity.CFechaConyuge = a.CFechaConyuge;
                        }
                        if (a.CArchivoConyuge != "N_A")
                        {
                            Entity.CArchivoConyuge = a.CArchivoConyuge;
                        }

                        Entity.CFModificacion = DateTime.Now;

                    } else if (a.Gestion == 5) {

                        string DateSol = a.AFechaSolicitante.ToString();
                        string DateCon = a.AFechaConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00")
                        {
                            Entity.AFechaSolicitante = a.AFechaSolicitante;
                        }
                        if (a.AArchivoSolicitante != "N_A")
                        {
                            Entity.AArchivoSolicitante = a.AArchivoSolicitante;
                        }
                        if (DateCon != "1/1/1900 00:00:00")
                        {
                            Entity.AFechaConyuge = a.AFechaConyuge;
                        }
                        if (a.AArchivoConyuge != "N_A")
                        {
                            Entity.AArchivoConyuge = a.AArchivoConyuge;
                        }

                        Entity.AFModificacion = DateTime.Now;
                    }

                    Entity.Gestion = 1;
                    Entity.IdAspNetUser = a.IdAspNetUser;
                    Entity.Estado = a.Estado;
                    Entity.FechaModificacion = DateTime.Now;


                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionSolicitante.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                        ResCtx.Estado = false;
                        ResCtx.FechaModificacion = DateTime.Now;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}