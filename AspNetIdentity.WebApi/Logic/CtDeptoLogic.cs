using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class CtDeptoLogic
    {

        CtDepto ModCtx = new CtDepto();

        public CtDeptoModel Crear(CtDeptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CtDepto Nuevo = new CtDepto
                {
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    ESTADO = 1,
                    NOMBRE = a.NOMBRE
                };

                Ctx.CtDepto.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtDeptoModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtDepto
                 .Join(Ctx.CtPais, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })
                 .Where(a => a.ESTADO == 1)
                .Select(a => new CtDeptoModel
                {
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    NOMBRE_PAIS = a.NombrePais,
                    NOMBRE = a.NOMBRE

                });

            return lista.ToList();
        }

        public CtDeptoModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.CtDepto
                    .Join(Ctx.CtPais, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) => new { b.ESTADO, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })
                    .Where(g => g.ESTADO == 1)
                    .Where(w => w.ID_CT_DEPTO == id).Select(s => s).FirstOrDefault();
            CtDeptoModel x = new CtDeptoModel();
            x.ID_CT_DEPTO = a.ID_CT_DEPTO;
            x.ID_CT_PAIS = a.ID_CT_PAIS;
            x.NOMBRE_PAIS = a.NombrePais;
            x.NOMBRE = a.NOMBRE;
            return x;
        }
        public List<CtDeptoModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtDepto.Where(w => w.ID_CT_PAIS == Idpa).Select(a => new CtDeptoModel //
            {
                ID_CT_DEPTO = a.ID_CT_DEPTO,
                ID_CT_PAIS = a.ID_CT_PAIS,
                NOMBRE = a.NOMBRE
            });

            return lista.ToList();
        }

        public CtDeptoModel Actualizar(CtDeptoModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtDepto.Where(s => s.ID_CT_DEPTO == a.ID_CT_DEPTO).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;

                    ResCtx.NOMBRE = a.NOMBRE;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtDepto.Where(s => s.ID_CT_DEPTO == id).Where(s => s.ESTADO == 1).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "REALIZADO";
        }
    }
}