using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
                IdProceso = a.IdProceso,
                IdModalidad = a.IdModalidad,
                IdRol = a.IdRolActividad,
                FechaActividad = a.FechaActividad,
                IdActividad = a.IdActividad,
                Cantidad = a.Cantidad,
                Observacion = a.Observacion,
                Estado = true,
                FInsercion = DateTime.Now,
                IdMuni = a.IdMuni,
                    IdDepto = a.IdDepto
                };
                Ctx.ActividadesDiarias.Add(Nuevo);
                Ctx.SaveChanges();
                a.Id = Nuevo.Id;

                return a;
            }
        }

        public List<CtDeptoModel> ConsultaRol()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.AspNetRoles.Select(x => new CtDeptoModel { ID_CT_PAIS = 1, NOMBRE_PAIS = x.Id, NOMBRE = x.Name }).ToList();
            return lista;
        }

        public List<CtPaisModel> ConsultaProceso()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ActDiaProceso.Select(x => new CtPaisModel { ID_CT_PAIS = x.Id, NOMBRE = x.Nombre }).ToList();
            return lista;
        }

        public List<CtPaisModel> ConsultaModalidad()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.ActDiaModalidad.Select(x => new CtPaisModel { ID_CT_PAIS = x.Id, NOMBRE = x.Nombre }).ToList();
            return lista;
        }

        public PaginadorCustomersModel Consulta(string pagina_)
        {
            int pagina = Convert.ToInt32(pagina_);
            ZonasFEntities Ctx = new ZonasFEntities();
            int _RegistrosPorPagina = 10;

            int _TotalRegistros = Ctx.ActividadesDiarias
                 .Join(Ctx.AspNetUsers, b => b.IdApsNetUser, c => c.Id, (b, c) =>
                 new { b, c.Id, b.Estado })
                .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) =>
                 new { b.b, c.Id_Hash, NombreUsuario = c.Name + " " + c.FirstName + " " + c.LastName, b.Estado })
                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, c.RoleId, b.Estado })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, NombreRol = c.Name, b.Estado })
                .Join(Ctx.TipoActividad, b => b.b.IdActividad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, c.Actividad, RolActividad = c.rol })
                .Join(Ctx.AspNetRoles, b => b.RolActividad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, NombreRolActividad = c.Name })
                .Join(Ctx.ActDiaProceso, b => b.b.IdProceso, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, IdProceso = c.Id, NombreProceso = c.Nombre })
                .Join(Ctx.ActDiaModalidad, b => b.b.IdModalidad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, b.IdProceso, b.NombreProceso, IdModalidad = c.Id, NombreModalidad = c.Nombre })
                .Where(x => x.Estado == true ).Count();

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
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, c.Actividad,  RolActividad= c.rol })
                .Join(Ctx.AspNetRoles, b => b.RolActividad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad,  NombreRolActividad= c.Name })
                .Join(Ctx.ActDiaProceso, b => b.b.IdProceso, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad , IdProceso = c.Id, NombreProceso = c.Nombre })
                .Join(Ctx.ActDiaModalidad, b => b.b.IdModalidad, c => c.Id, (b, c) =>
                 new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, b.IdProceso, b.NombreProceso, IdModalidad = c.Id , NombreModalidad = c.Nombre })
                .Where(x => x.Estado == true  )
                .Select(a => new ActividadesDiariasModel
                {
                Id = a.b.Id,
                IdApsNetUser = a.Id_Hash,
                NombreUsuario = a.NombreUsuario,
                RolUsuario = a.NombreRol,
                IdProceso = a.IdProceso,
                NombreProceso = a.NombreProceso,
                IdModalidad = a.IdModalidad,
                NombreModalidad = a.NombreModalidad,
                FechaActividad = a.b.FechaActividad.Value,
                FechaActividadS = a.b.FechaActividad.Value.ToString(),
                IdRolActividad = a.b.IdRol,
                NombreRolActividad = a.NombreRolActividad,
                IdActividad = a.b.IdActividad.Value,
                NombreActividad = a.Actividad,
                Cantidad = a.b.Cantidad.Value,
                Observacion = a.b.Observacion,
                Estado = a.Estado.Value,
                FInsercion= a.b.FInsercion.Value,
            })
                .OrderBy(c => c.IdApsNetUser ).OrderBy(c => c.FInsercion)
                .Skip(( pagina - 1) * _RegistrosPorPagina)
                .Take(_RegistrosPorPagina)
                .ToList();
                
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            PaginadorCustomersModel PaginadorCustomers_ = new PaginadorCustomersModel()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = lista
                };
                // Enviamos a la Vista la 'Clase de paginac

            return PaginadorCustomers_;
        }

        public List<ActividadesDiariasModel> ConsultarId(string id)
        {
            List<ActividadesDiariasModel> ActividadesDiariasModel_ = new List<ActividadesDiariasModel>() ;

            try
            {
                ZonasFEntities Ctx = new ZonasFEntities();

                ActividadesDiariasModel_ = Ctx.ActividadesDiarias
                    .Join(Ctx.AspNetUsers, b => b.IdApsNetUser, c => c.Id, (b, c) =>
                    new { b, c.Id, b.Estado })
                   .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) =>
                    new { b.b, c.Id_Hash, NombreUsuario = c.Name + " " + c.FirstName + " " + c.LastName, b.Estado })
                   .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, c.RoleId, b.Estado })
                   .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, NombreRol = c.Name, b.Estado })
                   .Join(Ctx.TipoActividad, b => b.b.IdActividad, c => c.Id, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, c.Actividad, RolActividad = c.rol })
                   .Join(Ctx.AspNetRoles, b => b.RolActividad, c => c.Id, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, NombreRolActividad = c.Name })
                   .Join(Ctx.ActDiaProceso, b => b.b.IdProceso, c => c.Id, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, IdProceso = c.Id, NombreProceso = c.Nombre })
                   .Join(Ctx.ActDiaModalidad, b => b.b.IdModalidad, c => c.Id, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, b.IdProceso, b.NombreProceso, IdModalidad = c.Id, NombreModalidad = c.Nombre })
                   .Join(Ctx.CtDepto, b => b.b.IdDepto.Value, c => c.ID_CT_DEPTO, (b, c) =>
                    new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, b.IdProceso, b.NombreProceso, b.IdModalidad, b.NombreModalidad, NombreDeptoAct = c.NOMBRE.ToString(), IdDeptoAct = c.ID_CT_DEPTO })
                   .Join(Ctx.CtCiudad, b => b.b.IdMuni.Value, c => c.IdCtMuncipio, (b, c) =>
                   new { b.b, b.Id_Hash, b.NombreUsuario, b.RoleId, b.NombreRol, b.Estado, b.Actividad, b.NombreRolActividad, b.IdProceso, b.NombreProceso, b.IdModalidad, b.NombreModalidad, b.NombreDeptoAct, b.IdDeptoAct, NombreCiudadAct = c.Nombre, IdCiudadAct = c.IdCtMuncipio, IdCiudadDeptoAct = c.IdCtDepto })
                   .Where(x => x.Estado == true && x.b.IdApsNetUser == id && x.IdDeptoAct == x.IdCiudadDeptoAct)
                   .Select(a => new ActividadesDiariasModel
                   {
                       Id = a.b.Id,
                       IdApsNetUser = a.Id_Hash,
                       NombreUsuario = a.NombreUsuario,
                       RolUsuario = a.NombreRol,
                       IdProceso = a.IdProceso,
                       NombreProceso = a.NombreProceso ,
                       IdModalidad = a.IdModalidad,
                       NombreModalidad = a.NombreModalidad,
                       FechaActividad = a.b.FechaActividad.Value,
                       FechaActividadS = a.b.FechaActividad.Value.ToString(),
                       IdRolActividad = a.b.IdRol,
                       NombreRolActividad = a.NombreRolActividad + "-" + a.NombreCiudadAct.ToString() +"-" + a.NombreDeptoAct,
                       IdActividad = a.b.IdActividad.Value,
                       NombreActividad = a.Actividad,
                       Cantidad = a.b.Cantidad.Value,
                       Observacion = a.b.Observacion,
                       Estado = a.Estado.Value,
                       FInsercion = a.b.FInsercion.Value,
                   }).OrderBy(c => c.IdApsNetUser).OrderBy(c => c.FInsercion).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ActividadesDiariasModel_;


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
                    ResCtx.FechaActividad = a.FechaActividad;
                    ResCtx.IdActividad = a.IdActividad;
                    ResCtx.IdRol = a.IdRolActividad;
                    ResCtx.Cantidad = a.Cantidad;
                    ResCtx.Observacion = a.Observacion;
                    ResCtx.Estado = a.Estado;
                    ResCtx.FInsercion = a.FInsercion;
                    ResCtx.IdProceso = a.IdProceso;
                    ResCtx.IdModalidad = a.IdModalidad;

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
                    {
                        ResCtx.Estado = false;
                        ResCtx.FInsercion = DateTime.Now;
                    }

                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}