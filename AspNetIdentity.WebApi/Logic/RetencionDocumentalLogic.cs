using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class RetencionDocumentalLogic
    {
        RetencionDocumental ModCtx = new RetencionDocumental();

        public RetencionDocumentalModel Crear(RetencionDocumentalModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                RetencionDocumental Nuevo = new RetencionDocumental
                {
                    Nombre = a.Nombre,
                    
                };

                Nuevo.Estado = true;
                Ctx.RetencionDocumental.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<RetencionDocumentalModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.RetencionDocumental.Where(x => x.Id == 1).Select(a => new RetencionDocumentalModel
            {
                Id = a.Id,
                Nombre = a.Nombre,
            });

            return lista.ToList();
        }

        public RetencionDocumentalModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            RetencionDocumental a = Ctx.RetencionDocumental.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
            RetencionDocumentalModel b = new RetencionDocumentalModel();
            b.Id = a.Id;
            b.Nombre = a.Nombre;
            return b;
        }

        public List<RetencionDocumentalModel> ConsultarGrupoId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.RetencionDocumental
                .Join(Ctx.RetencionDocumentalGrupo, b => b.IdGrupo, c => c.Id, (b, c) =>
                 new {b.Orden, b.Id, b.Nombre, b.IdGrupo, NombreGrupo = c.NombreGrupo, EstadoDocumento =  b.Estado, EstadoGrupo = c.Estado })
                .Where(w => w.IdGrupo == id).Select(Result => new RetencionDocumentalModel
                {
                    Id = Result.Id,
                    Nombre = Result.Nombre,
                    IdGrupo = Result.IdGrupo.Value,
                    NombreGrupo = Result.NombreGrupo,
                    Estado = Result.EstadoDocumento.Value,
                    Orden = Result.Orden.Value
                }).OrderBy(x => x.Orden);
          
            return a.ToList();
        }

        public RetencionDocumentalModel Actualizar(RetencionDocumentalModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.RetencionDocumental.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        
                        ResCtx.Id = a.Id;
                        ResCtx.Nombre = a.Nombre;
                   
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.RetencionDocumental.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = true;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}