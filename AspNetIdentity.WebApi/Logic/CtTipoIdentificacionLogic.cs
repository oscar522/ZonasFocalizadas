using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CtTipoIdentificacionLogic
    {
       
        CtTipoIdentificacion ModCtx = new CtTipoIdentificacion();

        public CtTipoIdentificacionModel Crear(CtTipoIdentificacionModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CtTipoIdentificacion Nuevo = new CtTipoIdentificacion
                {
                    ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.CtTipoIdentificacion.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CtTipoIdentificacionModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CtTipoIdentificacion.Where(e => e.ESTADO == 1).Select(a => new CtTipoIdentificacionModel
            {
                ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                NOMBRE = a.NOMBRE
            });

            return lista.ToList();
        }

        public CtTipoIdentificacionModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            CtTipoIdentificacion a = Ctx.CtTipoIdentificacion.Where(w => w.ID_CT_TIPO_IDENTIFICACION == id).Select(s => s).FirstOrDefault();
            CtTipoIdentificacionModel b = new CtTipoIdentificacionModel();
            b.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
            b.NOMBRE = a.NOMBRE;
            return b;
        }

        public CtTipoIdentificacionModel Actualizar(CtTipoIdentificacionModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CtTipoIdentificacion.Where(s => s.ID_CT_TIPO_IDENTIFICACION == a.ID_CT_TIPO_IDENTIFICACION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
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
                var ResCtx = Ctx.CtTipoIdentificacion.Where(s => s.ID_CT_TIPO_IDENTIFICACION == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "realizado ";
        }
    }
}