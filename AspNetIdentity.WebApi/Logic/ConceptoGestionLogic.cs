using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class ConceptoGestionLogic
    {
        #region Gestion

        ConceptoGestion ModCtx = new ConceptoGestion();

        public ConceptoGestionModel Crear(ConceptoGestionModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                ConceptoGestion Nuevo = new ConceptoGestion
                {
                    Id = a.Id,
                    IdConcepto = a.IdConcepto,
                    IdEstado = a.IdEstado,
                    IdSoporte = a.IdSoporte,
                    Observacion = a.Observacion,
                    FCreacion = DateTime.Now,
                    Estado = true,
                    Archivo = a.Archivo,
                    IdAspNetUser = a.IdAspNetUserGestion
                };
                Ctx.ConceptoGestion.Add(Nuevo);
                Ctx.SaveChanges();
                a.FCreacion = null;
                a.Id = Nuevo.Id;
                return a;
            }
        }

        public List<ConceptoGestionModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.ConceptoGestion
                .Join(Ctx.ConceptoEstado, b => b.IdConcepto, c => c.Id, (b, c) =>
                 new { ConceptoEstado = c, ConceptoGestion = b })
                .Join(Ctx.ConceptoTipoSoporte, b => b.ConceptoGestion.IdSoporte, c => c.Id, (c, d) =>
                 new { c.ConceptoEstado, c.ConceptoGestion, ConceptoTipoSoporte = d })
                .Where(c => c.ConceptoGestion.Estado == true)
                .Select(a => new ConceptoGestionModel
                {
                    Id = a.ConceptoGestion.Id,
                    IdConcepto = a.ConceptoGestion.IdConcepto,
                    IdEstado = a.ConceptoGestion.IdEstado,
                    NombreIdEstado = a.ConceptoEstado.Nombre,
                    IdSoporte = a.ConceptoGestion.IdSoporte,
                    NombreIdSoporte = a.ConceptoTipoSoporte.Nombre,
                    Observacion = a.ConceptoGestion.Observacion,
                    FCreacion = a.ConceptoGestion.FCreacion.ToString(),
                    Estado = a.ConceptoGestion.Estado,
                    Archivo = a.ConceptoGestion.Archivo,
                    IdAspNetUserGestion = a.ConceptoGestion.IdAspNetUser
                }) ;

            return lista.ToList();
        }

        public List<ConceptoGestionModel> ConsultaIdConcepto( int Id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();


           
            var lista = Ctx.ConceptoGestion

                .Join(Ctx.ConceptoEstado, b => b.IdEstado, c => c.Id, (b, c) =>
                 new { ConceptoEstado = c, ConceptoGestion = b })

                .Join(Ctx.ConceptoTipoSoporte, b => b.ConceptoGestion.IdSoporte, c => c.Id, (c, d) =>
                 new { c.ConceptoEstado,  c.ConceptoGestion, ConceptoTipoSoporte = d })

                 .Join(Ctx.Users, b => b.ConceptoGestion.IdAspNetUser, c => c.Id_Hash, (b, c) =>
                 new {  b.ConceptoEstado,   b.ConceptoGestion, b.ConceptoTipoSoporte, Users = c })

                .Join(Ctx.AspNetUserRoles, b => b.Users.Id_Hash, c => c.UserId, (b, c) =>
                 new {b.ConceptoEstado, b.ConceptoGestion, b.ConceptoTipoSoporte, b.Users, AspNetUserRoles = c })

                .Join(Ctx.AspNetRoles, b => b.AspNetUserRoles.RoleId, c => c.Id, (b, c) =>
                 new { b.ConceptoEstado, b.ConceptoGestion, b.ConceptoTipoSoporte, b.Users,  b.AspNetUserRoles, AspNetRoles= c })

                .Where(c => c.ConceptoGestion.Estado == true && c.ConceptoGestion.IdConcepto == Id )
                .Select(a => new ConceptoGestionModel
                {
                    Id = a.ConceptoGestion.Id,
                    IdConcepto = a.ConceptoGestion.IdConcepto,
                    IdEstado = a.ConceptoGestion.IdEstado,
                    NombreIdEstado = a.ConceptoEstado.Nombre,
                    IdSoporte = a.ConceptoGestion.IdSoporte,
                    NombreIdSoporte = a.ConceptoTipoSoporte.Nombre,
                    Observacion = a.ConceptoGestion.Observacion,
                    FCreacion = a.ConceptoGestion.FCreacion.ToString(),
                    Estado = a.ConceptoGestion.Estado,
                    Archivo = a.ConceptoGestion.Archivo,
                    IdAspNetUserGestion = a.ConceptoGestion.IdAspNetUser,
                    NombreUser = a.Users.Name + " "+ a.Users.FirstName+ " "+ a.Users.LastName,
                    IdRolUser = a.AspNetRoles.Id,
                    RolUser = a.AspNetRoles.Name,
                }).OrderByDescending(x => x.FCreacion);

            return lista.ToList();
        }

        public ConceptoGestionModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.ConceptoGestion
                .Join(Ctx.ConceptoEstado, b => b.IdConcepto, c => c.Id, (b, c) =>
                 new { ConceptoEstado = c, ConceptoGestion = b })
                .Join(Ctx.ConceptoTipoSoporte, b => b.ConceptoGestion.IdSoporte, c => c.Id, (c, d) =>
                 new { c.ConceptoEstado, c.ConceptoGestion, ConceptoTipoSoporte = d })
                .Where(w => w.ConceptoGestion.Id == id).Select(s => s)
                .Select(a => new ConceptoGestionModel
                 {
                    Id = a.ConceptoGestion.Id,
                    IdConcepto = a.ConceptoGestion.IdConcepto,
                    IdEstado = a.ConceptoGestion.IdEstado,
                    NombreIdEstado = a.ConceptoEstado.Nombre,
                    IdSoporte = a.ConceptoGestion.IdSoporte,
                    NombreIdSoporte = a.ConceptoTipoSoporte.Nombre,
                    Observacion = a.ConceptoGestion.Observacion,
                    FCreacion = a.ConceptoGestion.FCreacion.ToString(),
                    Estado = a.ConceptoGestion.Estado,
                    Archivo = a.ConceptoGestion.Archivo

                });
            return lista.FirstOrDefault();
        }

        public ConceptoGestionModel Actualizar(ConceptoGestionModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ConceptoGestion.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.Id = a.Id;
                    ResCtx.IdConcepto = a.IdConcepto;
                    ResCtx.IdEstado = a.IdEstado;
                    ResCtx.IdSoporte = a.IdSoporte;
                    ResCtx.Observacion = a.Observacion;
                    ResCtx.Estado = a.Estado;
                    ResCtx.Archivo = a.Archivo;
                    ResCtx.IdAspNetUser = a.IdAspNetUserGestion;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ConceptoGestion.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        #endregion

        public List<ConceptoEstadoModel> ConsultaEstados()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.ConceptoEstado
                .Join(Ctx.AspNetRoles, b => b.IdRol, c => c.Id, (b, c) =>
                 new {c.Name,b })
                 .Where(c => c.b.Estado == true).Select(x=> new ConceptoEstadoModel {
                Id = x.b.Id,
                Nombre = x.b.Nombre,
                IdRol = x.Name,
                Estado = x.b.Estado
            }).ToList();

            return lista;
        }

        public List<ConceptoTipoSoporteModel> ConsultaSoportes()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.ConceptoTipoSoporte.Where(c => c.Estado == true).Select(x => new ConceptoTipoSoporteModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Estado = x.Estado
            }).ToList();

            return lista;
        }

    }
}