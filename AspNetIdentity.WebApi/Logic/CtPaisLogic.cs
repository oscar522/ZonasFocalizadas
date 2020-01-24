using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class CtPaisLogic
    {
        CtPais ModCtx = new CtPais();

        public CtPaisModel Crear(CtPaisModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CtPais Nuevo = new CtPais
                {
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                              
                Ctx.CtPais.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtPaisModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtPais.Where(s => s.ESTADO == 1).Select(a => new CtPaisModel
            {
                ID_CT_PAIS = a.ID_CT_PAIS,
                NOMBRE = a.NOMBRE

            });

            return lista.ToList();
        }

        public CtPaisModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            CtPais a = Ctx.CtPais.Where(w => w.ID_CT_PAIS == id).Where(s => s.ESTADO == 1).Select(s => s).FirstOrDefault();
            CtPaisModel b = new CtPaisModel();
            b.ID_CT_PAIS = a.ID_CT_PAIS;
            b.NOMBRE = a.NOMBRE;
            b.ESTADO = a.ESTADO.Value;
            return b;
        }

        public CtPaisModel Actualizar(CtPaisModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtPais.Where(s => s.ESTADO == 1).Where(s => s.ID_CT_PAIS == a.ID_CT_PAIS).FirstOrDefault();
                if (ResCtx != null)
                {
                
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
                var ResCtx = Ctx.CtPais.Where(s => s.ID_CT_PAIS == id).Where(s => s.ESTADO == 1).FirstOrDefault();
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