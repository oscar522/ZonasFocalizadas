using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class RetencionDocumentalGrupoLogic
    {
        RetencionDocumentalGrupo ModCtx = new RetencionDocumentalGrupo();

        public RetencionDocumentalGrupoModel Crear(RetencionDocumentalGrupoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                RetencionDocumentalGrupo Nuevo = new RetencionDocumentalGrupo
                {
                    Id  = a.Id,
                    NombreGrupo  = a.NombreGrupo,
                    Orden = a.Orden,
                };

                Nuevo.Estado = true;
                Ctx.RetencionDocumentalGrupo.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<RetencionDocumentalGrupoModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.RetencionDocumentalGrupo.Where(x => x.Estado == true).Select(a => new RetencionDocumentalGrupoModel
            {
                Id = a.Id,
                NombreGrupo = a.NombreGrupo,
                Orden = a.Orden.Value,
            }).OrderBy(x => x.Orden);

            return lista.ToList();
        }

        public RetencionDocumentalGrupoModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            RetencionDocumentalGrupo a = Ctx.RetencionDocumentalGrupo.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
            RetencionDocumentalGrupoModel b = new RetencionDocumentalGrupoModel();
            b.Id = a.Id;
            b.NombreGrupo = a.NombreGrupo;
            b.Orden = a.Orden.Value;
            return b;
        }

        public RetencionDocumentalGrupoModel Actualizar(RetencionDocumentalGrupoModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.RetencionDocumentalGrupo.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        
                        ResCtx.Id = a.Id;
                        ResCtx.Id = a.Id;
                        ResCtx.NombreGrupo = a.NombreGrupo;
                        ResCtx.Orden = a.Orden;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.RetencionDocumentalGrupo.Where(s => s.Id == id).FirstOrDefault();
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