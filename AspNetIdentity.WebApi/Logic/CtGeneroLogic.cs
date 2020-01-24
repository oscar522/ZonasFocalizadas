using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CtGeneroLogic
    {
        CtGenero ModCtx = new CtGenero();

        public CtGeneroModel Crear(CtGeneroModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CtGenero Nuevo = new CtGenero
                {
                    NOMBRE = a.NOMBRE,
                    
                };

                Nuevo.ESTADO = 1;
                Ctx.CtGenero.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtGeneroModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtGenero.Where(x => x.ESTADO == 1).Select(a => new CtGeneroModel
            {
                ID_GENERO = a.ID_GENERO,
                NOMBRE = a.NOMBRE,
                

            });

            return lista.ToList();
        }

        public CtGeneroModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            CtGenero a = Ctx.CtGenero.Where(w => w.ID_GENERO == id).Select(s => s).FirstOrDefault();
            CtGeneroModel b = new CtGeneroModel();
            b.ID_GENERO = a.ID_GENERO;
            b.NOMBRE = a.NOMBRE;
            
            return b;
        }

        public CtGeneroModel Actualizar(CtGeneroModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtGenero.Where(s => s.ID_GENERO == a.ID_GENERO).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ID_GENERO = a.ID_GENERO;
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
                var ResCtx = Ctx.CtGenero.Where(s => s.ID_GENERO == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}