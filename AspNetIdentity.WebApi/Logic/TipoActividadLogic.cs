using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class TipoActividadLogic
    {
        TipoActividad ModCtx = new TipoActividad();

        public TipoActividadModel Crear(TipoActividadModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                TipoActividad Nuevo = new TipoActividad
                {
                    Id = a.Id,
                    Actividad = a.Actividad,
                    Activa = true,
                    
                };

                Ctx.TipoActividad.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<TipoActividadModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.TipoActividad.Where(x => x.Activa == true).Select(a => new TipoActividadModel
            {
                Id = a.Id,
                Actividad = a.Actividad,
                Activa = a.Activa.Value,
            });

            return lista.ToList();
        }

        public List<TipoActividadModel> ConsultarRolId(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.TipoActividad
                .Join(Ctx.AspNetRoles, d => d.rol, c => c.Id, (d, c) => new { d.Id,d.Activa,d.Actividad,d.rol })
                .Where(w => w.rol == id).Select(r => new TipoActividadModel {
                    Id = r.Id,
                    Actividad = r.Actividad,
                    Activa = r.Activa.Value}).ToList();
            return a;
        }

        public TipoActividadModel Actualizar(TipoActividadModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.TipoActividad.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Id = a.Id;
                    ResCtx.Actividad = a.Actividad;
                    ResCtx.Activa = a.Activa;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.TipoActividad.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Activa = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}