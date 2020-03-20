using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class ActividadesDiariasLogic
    {
        ActividadesDiarias ModCtx = new ActividadesDiarias();

        public ActividadesDiariasModel Crear(ActividadesDiariasModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                ActividadesDiarias Nuevo = new ActividadesDiarias
                {
                    IdApsNetUser = a.IdApsNetUser,
                    NombreUsuario = a.NombreUsuario,
                    RolUsuario = a.RolUsuario,
                    FechaActividad = a.FechaActividad,
                    IdActividad = a.IdActividad,
                    IdRol = a.IdRol,
                    Cantidad = a.Cantidad,
                    Observacion = a.Observacion,
                    FInsercion = DateTime.Now,
                    Estado = true,

                };
                Ctx.ActividadesDiarias.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtDeptoModel> ConsultaRol()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.AspNetRoles.Select(x => new CtDeptoModel { ID_CT_PAIS = 1, NOMBRE_PAIS = x.Id, NOMBRE = x.Name }).ToList();
            return lista;
        }

        public List<ActividadesDiariasModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ActividadesDiarias
                 .Join(Ctx.AspNetUsers, b => b.IdApsNetUser, c => c.Id, (b, c) =>
                 new { b, c.Id, b.Estado })
                .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) =>
                 new { b.b, c.Id_Hash, NombreUsuario = c.Name+" "+c.FirstName+" "+c.LastName, b.Estado })
                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, c.RoleId, b.Estado })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, NombreRol = c.Name, b.Estado })
                .Join(Ctx.TipoActividad, b => b.b.IdActividad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, c.Actividad })
                .Where(x => x.Estado == true)
                .Select(a => new ActividadesDiariasModel
                {
                Id = a.b.Id,
                IdApsNetUser = a.Id_Hash,
                NombreUsuario = a.NombreUsuario,
                RolUsuario = a.NombreRol,
                FechaActividad = a.b.FechaActividad.Value,
                FechaActividadS = a.b.FechaActividad.Value.ToString(),
                IdActividad = a.b.IdActividad.Value,
                NombreActividad = a.Actividad,
                IdRol = a.b.IdRol,
                Cantidad = a.b.Cantidad.Value,
                Observacion = a.b.Observacion,
                Estado = a.Estado.Value,
                FInsercion= a.b.FInsercion.Value,
            }).OrderBy(c => c.IdApsNetUser ).OrderBy(c => c.FInsercion);

            return lista.ToList();
        }

        public List<ActividadesDiariasModel> ConsultarId(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ActividadesDiarias
                 .Join(Ctx.AspNetUsers, b => b.IdApsNetUser, c => c.Id, (b, c) =>
                 new { b, c.Id, b.Estado })
                .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) =>
                 new { b.b, c.Id_Hash, NombreUsuario = c.Name + " " + c.FirstName + " " + c.LastName, b.Estado })
                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, c.RoleId, b.Estado })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, NombreRol = c.Name, b.Estado })
                .Join(Ctx.TipoActividad, b => b.b.IdActividad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, c.Actividad })
                .Where(x => x.Estado == true)
                .Select(a => new ActividadesDiariasModel
                {
                    Id = a.b.Id,
                    IdApsNetUser = a.Id_Hash,
                    NombreUsuario = a.NombreUsuario,
                    RolUsuario = a.NombreRol,
                    FechaActividad = a.b.FechaActividad.Value,
                    FechaActividadS = a.b.FechaActividad.Value.ToString(),
                    IdActividad = a.b.IdActividad.Value,
                    NombreActividad = a.Actividad,
                    IdRol = a.b.IdRol,
                    Cantidad = a.b.Cantidad.Value,
                    Observacion = a.b.Observacion,
                    Estado = a.Estado.Value,
                    FInsercion = a.b.FInsercion.Value,
                }).OrderBy(c => c.IdApsNetUser).OrderBy(c => c.FInsercion).ToList();

            return lista;
        }

        public ActividadesDiariasModel Actualizar(ActividadesDiariasModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ActividadesDiarias.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Id = a.Id;
                    ResCtx.IdApsNetUser = a.IdApsNetUser;
                    ResCtx.NombreUsuario = a.NombreUsuario;
                    ResCtx.RolUsuario = a.RolUsuario;
                    ResCtx.FechaActividad = a.FechaActividad;
                    ResCtx.IdActividad = a.IdActividad;
                    ResCtx.IdRol = a.IdRol;
                    ResCtx.Cantidad = a.Cantidad;
                    ResCtx.Observacion = a.Observacion;
                    ResCtx.Estado = a.Estado;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ActividadesDiarias.Where(s => s.Id == id).FirstOrDefault();
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