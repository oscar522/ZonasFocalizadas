using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class ConceptoLogic
    {
        Concepto ModCtx = new Concepto();
        public ConceptoModel Crear(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                Concepto Nuevo = new Concepto
                {
                    Id = a.Id,
                    IdAspNetUsers = a.IdAspNetUsers,
                    IdCausa = a.IdCausa,
                    IdExpediente = a.IdExpediente,
                    Soporte = a.Soporte,
                    Anexo = a.Anexo,
                    IdOrfeo = a.IdOrfeo,
                    Estado = a.Estado,
                };
                Ctx.Concepto.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }
        public List<ConceptoModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.Concepto
                 .Join(Ctx.AspNetUsers, b => b.IdAspNetUsers, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, IdUser = c.Id })

                .Join(Ctx.Users, b => b.IdUser, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, c.Name, c.FirstName, c.LastName })

                .Join(Ctx.CtCausas, b => b.IdCausa, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, causa = c.Nombre })

                .Join(Ctx.ConceptoAsociado, b => b.Id, c => c.IdConcepto, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, UserAsociado = c.IdAspNetUser })

                .Join(Ctx.Users, b => b.UserAsociado, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, UserAsociadoName = c.Name + " " + c.FirstName + " " + c.LastName })

                .Join(Ctx.AspNetUserRoles, b => b.UserAsociado, c => c.UserId, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, c.RoleId })

                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdExpediente, b.Soporte, b.Anexo, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, NombreRol = c.Name })


                .Where(c => c.Estado.Value == true).Select(a => new ConceptoModel
                {
                    Id = a.Id,
                    IdAspNetUsers = a.IdAspNetUsers,
                    NombreAspNetUsers = a.Name + " " + a.FirstName + " " + a.LastName,
                    IdCausa = a.IdCausa,
                    NombreCausa = a.causa,
                    IdExpediente = a.IdExpediente,
                    UserAsociado = a.UserAsociadoName,
                    Rol = a.NombreRol,
                    RutaExpediente = Ctx.BaldiosPersonaNatural.Where(x => x.id == a.IdExpediente).Select(x => x.NumeroExpediente).FirstOrDefault(),
                    Soporte = a.Soporte,
                    Anexo = a.Anexo,
                    IdOrfeo = a.IdOrfeo,
                    Estado = a.Estado,
                    FechaCreacion = a.FechaCreacion
                });

            return lista.ToList();
        }
        public List<ConceptoModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Concepto.Where(w => w.Id == Idpa).Select(a => new ConceptoModel //
            {
                Id = a.Id,
                IdAspNetUsers = a.IdAspNetUsers,
                IdCausa = a.IdCausa,
                IdExpediente = a.IdExpediente,
                Soporte = a.Soporte,
                Anexo = a.Anexo,
                IdOrfeo = a.IdOrfeo,
                Estado = a.Estado,
            });

            return lista.ToList();
        }
        public ConceptoModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.Concepto.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
            ConceptoModel b = new ConceptoModel();
            b.Id = a.Id;
            b.IdAspNetUsers = a.IdAspNetUsers;
            b.IdCausa = a.IdCausa;
            b.IdExpediente = a.IdExpediente;
            b.Soporte = a.Soporte;
            b.Anexo = a.Anexo;
            b.IdOrfeo = a.IdOrfeo;
            b.Estado = a.Estado;
            return b;
        }
        public ConceptoModel Actualizar(ConceptoModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.Concepto.Where(s => s.Id == a.Id).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.Id = a.Id;
                    ResCtx.IdAspNetUsers = a.IdAspNetUsers;
                    ResCtx.IdCausa = a.IdCausa;
                    ResCtx.IdExpediente = a.IdExpediente;
                    ResCtx.Soporte = a.Soporte;
                    ResCtx.Anexo = a.Anexo;
                    ResCtx.IdOrfeo = a.IdOrfeo;
                    ResCtx.Estado = a.Estado;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }
        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.Concepto.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
        public List<CtDeptoModel> ConsultaTipoUsuario()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.AspNetRoles.Select(a => new CtDeptoModel
            {
                ID_CT_DEPTO =0,
                NOMBRE = a.Name,
                ID_CT_PAIS = 0,
                NOMBRE_PAIS = a.Id
            });
            return lista.ToList();
        }
        public List<CtDeptoModel> ConsultaUsuario(string rol)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.AspNetRoles
                .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId })
                .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { c.Id, c.FirstName, c.LastName, b.RoleId })
                .Where(c => c.RoleId == rol)
                .Select(a => new CtDeptoModel
                {
                    ID_CT_DEPTO = 0,
                    NOMBRE = a.FirstName +" " + a.LastName,
                    ID_CT_PAIS = 0,
                    NOMBRE_PAIS = a.Id
                });
            return lista.ToList();
        }

        public List<CtDeptoModel> ConsultaTipoCausa()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.CtCausas.Select(a => new CtDeptoModel
            {
                ID_CT_DEPTO = a.Id,
                NOMBRE = a.Nombre,
                ID_CT_PAIS = 0,
                NOMBRE_PAIS = "0"
            });
            return lista.ToList();
        }

    }
}