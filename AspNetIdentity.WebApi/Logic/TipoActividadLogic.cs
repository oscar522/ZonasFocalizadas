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

        public TipoActividadModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            TipoActividad a = Ctx.TipoActividad.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
            TipoActividadModel b = new TipoActividadModel();
            b.Id = a.Id;
            b.Actividad = a.Actividad;
               b.Activa = a.Activa.Value;
            
            return b;
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