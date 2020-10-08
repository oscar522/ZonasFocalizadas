using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class CtCiudadPaolaLogic
    {
        CtCiudad ModCtx = new CtCiudad();

        public CtCiudadPaolaModel Crear(CtCiudadPaolaModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                CiudadPaola Nuevo = new CiudadPaola
                {
                    Id = a.Id,
                    IdCtDepto = a.IdCtDepto,
                    IdCtPais = a.IdCtPais,
                    Nombre = a.Nombre,
                    Estado = true // --------------------- //
                };
                Ctx.CiudadPaola.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtCiudadModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            
            var lista = Ctx.CtCiudad
                .Join(Ctx.CtPais, b => b.IdCtPais, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.IdCtMuncipio, b.IdCtDepto, b.IdCtPais, b.Nombre, b.Estado, NombrePais = c.NOMBRE})
                .Join(Ctx.CtDepto, b => b.IdCtDepto, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.IdCtMuncipio, c.IdCtDepto, c.IdCtPais, c.Nombre, c.Estado, c.NombrePais, NombreDepto = d.NOMBRE })
                .Where(c => c.Estado == 1 ).Select(c => new CtCiudadModel
                {
                    IdCtMuncipio = c.IdCtMuncipio,
                    IdCtDepto = c.IdCtDepto,
                    NOMBRE_DEPTO = c.NombreDepto,
                    IdCtPais = c.IdCtPais,
                    NOMBRE_PAIS = c.NombrePais,
                    Nombre = c.Nombre,
                });

            return lista.ToList();
        }

        public List<CtCiudadModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtCiudad.Where(w => w.IdCtDepto == Idpa).Select(a => new CtCiudadModel //
            {
                IdCtMuncipio = a.IdCtMuncipio,
                Nombre = a.Nombre
            });

            return lista.ToList();
        }

        public List<CtCiudadPaolaModel> ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var b = Ctx.CiudadPaola
                .Join(
                 Ctx.CtPais, x => x.IdCtPais, c => c.ID_CT_PAIS, (x, c) =>
                 new { x.Id, x.IdCtDepto, x.IdCtPais, x.Nombre, x.Estado, NombrePais = c.NOMBRE })
                .Join(Ctx.CtDepto, x => x.IdCtDepto, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.Id, c.IdCtDepto, c.IdCtPais, c.Nombre, c.Estado, c.NombrePais, NombreDepto = d.NOMBRE })
                //.Where(w => w.Id == id)
                .Select(a =>  new CtCiudadPaolaModel
                {
                    Id = a.Id,
                    IdCtDepto = a.IdCtDepto,
                    NombreIdCtDepto = a.NombreDepto,
                    IdCtPais = a.IdCtPais,
                    NombreIdCtPais = a.NombrePais,
                    Nombre = a.Nombre,
                }
                ).ToList();


           
            return b;
        }

        public CtCiudadModel Actualizar(CtCiudadModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtCiudad.Where(s => s.IdCtMuncipio == a.IdCtMuncipio).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.IdCtMuncipio = a.IdCtMuncipio;
                    ResCtx.IdCtDepto = a.IdCtDepto;
                    ResCtx.IdCtPais = a.IdCtPais;
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
                var ResCtx = Ctx.CtCiudad.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}