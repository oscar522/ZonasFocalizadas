using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class CtCiudadLogic
    {
        CtCiudad ModCtx = new CtCiudad();

        public CtCiudadModel Crear(CtCiudadModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                CtCiudad Nuevo = new CtCiudad
                {
                    Id = a.id,
                    IdCtMuncipio = a.IdCtMuncipio,
                    IdCtDepto = a.IdCtDepto,
                    IdCtPais = a.IdCtPais,
                    Nombre = a.Nombre,
                    Estado = 1 // --------------------- //
                };
                Ctx.CtCiudad.Add(Nuevo);
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

        public CtCiudadModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.CtCiudad
                .Join(Ctx.CtPais, x => x.IdCtPais, c => c.ID_CT_PAIS, (x, c) =>
                 new { x.IdCtMuncipio, x.IdCtDepto, x.IdCtPais, x.Nombre, x.Estado, NombrePais = c.NOMBRE })
                .Join(Ctx.CtDepto, x => x.IdCtDepto, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.IdCtMuncipio, c.IdCtDepto, c.IdCtPais, c.Nombre, c.Estado, c.NombrePais, NombreDepto = d.NOMBRE })
                .Where(w => w.IdCtMuncipio == id).Select(s => s).FirstOrDefault();
            CtCiudadModel b = new CtCiudadModel();

            b.IdCtMuncipio = a.IdCtMuncipio;
            b.IdCtDepto = a.IdCtDepto;
            b.NOMBRE_DEPTO = a.NombreDepto;
            b.IdCtPais = a.IdCtPais;
            b.NOMBRE_PAIS = a.NombrePais;
            b.Nombre = a.Nombre;
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