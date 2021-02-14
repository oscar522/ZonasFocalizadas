using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class Ba_Memorando_newLogic
    {
        Ba_Memorando_new ModCtx = new Ba_Memorando_new();


        public Ba_Memorando_newModel Crear(Ba_Memorando_newModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                Ba_Memorando_new Nuevo = new Ba_Memorando_new
                {

                    Id = a.Id,
                    radicado = a.radicado,
                    cargaorfeo = a.cargaorfeo,
                    asignado = a.asignado,
                    Fechasignado = a.Fechasignado,
                    feacharadicado = a.feacharadicado,
                    fiso = a.fiso,
                    municipio = a.municipio,
                    departamento = a.departamento,
                    expediente = a.expediente,
                    fechafiso = a.fechafiso,
                    tiposolicitud = a.tiposolicitud,
                    solicitante = a.solicitante,
                    docidentificacionsol = a.docidentificacionsol,
                    copiadoc = a.copiadoc,
                    copiacertificadocurso = a.copiacertificadocurso,
                    declararentasol = a.declararentasol,
                    beneficiariosol = a.beneficiariosol,
                    propietariosol = a.propietariosol,
                    penjudicialessol = a.penjudicialessol,
                    ocupanteindebidosol = a.ocupanteindebidosol,
                    victimadsol = a.victimadsol,
                    conyuge = a.conyuge,
                    docidentificacioncony = a.docidentificacioncony,
                    declararentacony = a.declararentacony,
                    beneficiariocony = a.beneficiariocony,
                    propietariocony = a.propietariocony,
                    penjudicialescony = a.penjudicialescony,
                    ocupanteindevidocony = a.ocupanteindevidocony,
                    victimadcony = a.victimadcony,
                    inclusionreso = a.inclusionreso,
                    respojuridico = a.respojuridico,
                    respoagronomo = a.respoagronomo,
                    respocatastral = a.respocatastral,
                    responsable = a.responsable,
                    fechaediccion = DateTime.Now.ToString(),
                    FechaInsercion = DateTime.Now,
                    FechaModificacion =DateTime.Now,
                    Gestion = a.Gestion,
                    IdAspNetUser = a.IdAspNetUser,
                    IdAspNetUserModifica = a.IdAspNetUserModifica,
                    Estado = a.Estado,
                };

                Ctx.Ba_Memorando_new.Add(Nuevo);
                Ctx.SaveChanges();
                a.Id = Nuevo.Id;
                return a;
            }
        }

        public List<Ba_Memorando_newModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

           
            #region Sql
            var lista = Ctx.Ba_Memorando_new
                .Where(w => w.Estado == 1)
                .Select(c => new Ba_Memorando_newModel
                {
                    asignado = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.asignado).Select(y => y.Nombre).FirstOrDefault(),
                    copiadoc = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.copiadoc).Select(y => y.Nombre).FirstOrDefault(),
                    copiacertificadocurso = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.copiacertificadocurso).Select(y => y.Nombre).FirstOrDefault(),
                    declararentasol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.declararentasol).Select(y => y.Nombre).FirstOrDefault(),
                    beneficiariosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.beneficiariosol).Select(y => y.Nombre).FirstOrDefault(),
                    propietariosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.propietariosol).Select(y => y.Nombre).FirstOrDefault(),
                    penjudicialessol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.penjudicialessol).Select(y => y.Nombre).FirstOrDefault(),
                    ocupanteindebidosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.ocupanteindebidosol).Select(y => y.Nombre).FirstOrDefault(),
                    victimadsol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.victimadsol).Select(y => y.Nombre).FirstOrDefault(),
                    declararentacony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.declararentacony).Select(y => y.Nombre).FirstOrDefault(),
                    beneficiariocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.beneficiariocony).Select(y => y.Nombre).FirstOrDefault(),
                    propietariocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.propietariocony).Select(y => y.Nombre).FirstOrDefault(),
                    penjudicialescony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.penjudicialescony).Select(y => y.Nombre).FirstOrDefault(),
                    ocupanteindevidocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.ocupanteindevidocony).Select(y => y.Nombre).FirstOrDefault(),
                    victimadcony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.victimadcony).Select(y => y.Nombre).FirstOrDefault(),
                    inclusionreso = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.inclusionreso).Select(y => y.Nombre).FirstOrDefault(),

                    cargaorfeo = c.cargaorfeo,

                    departamento = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO.ToString() == c.departamento).Select(y => y.NOMBRE).FirstOrDefault(),
                    municipio = Ctx.CtCiudad.Where(x => x.IdCtMuncipio.ToString() == c.municipio && x.IdCtDepto.ToString() == c.departamento).Select(y => y.Nombre).FirstOrDefault(),


                    tiposolicitud = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.tiposolicitud).Select(y => y.Nombre).FirstOrDefault(),

                    respojuridico = Ctx.Users.Where(x => x.Id_Hash == c.respojuridico).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                    respoagronomo = Ctx.Users.Where(x => x.Id_Hash == c.respoagronomo).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                    respocatastral = Ctx.Users.Where(x => x.Id_Hash == c.respocatastral).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                    responsable = Ctx.Users.Where(x => x.Id_Hash == c.responsable).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),

                }).ToList();
            #endregion
            return lista;
        }

        public List<Ba_Memorando_newModel> Consulta(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var userLogin = Ctx.Users.Where(x => x.Id_Hash == id)
                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) => new { b, c })
                .Join(Ctx.AspNetRoles, b => b.c.RoleId, c => c.Id, (b, c) => new { b, c })
                .FirstOrDefault();

            List<Ba_Memorando_new> listBa_Memorando_newModel = new List<Ba_Memorando_new>();

            if (userLogin.c.Name == "Abogados") {

                listBa_Memorando_newModel = Ctx.Ba_Memorando_new
                .Where(w => w.respojuridico == id && w.Estado == 1).ToList();

            } else if (userLogin.c.Name == "Agronomo") { 

                listBa_Memorando_newModel = Ctx.Ba_Memorando_new
                .Where(w => w.respoagronomo == id && w.Estado == 1).ToList();

            } else if (userLogin.c.Name == "Catastral") {

                listBa_Memorando_newModel = Ctx.Ba_Memorando_new
                .Where(w => w.respocatastral == id && w.Estado == 1).ToList();

            } else if (userLogin.c.Name == "Lider")
            {

                listBa_Memorando_newModel = Ctx.Ba_Memorando_new
                .Where(w => w.Estado == 1).ToList();

            }

            List<Ba_Memorando_newModel> lista = new List<Ba_Memorando_newModel>();

            try {
                #region Sql
                lista = listBa_Memorando_newModel

                    .Select(c => new Ba_Memorando_newModel
                    {

                        asignado = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.asignado).Select(y => y.Nombre).FirstOrDefault(),
                        copiadoc = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.copiadoc).Select(y => y.Nombre).FirstOrDefault(),
                        copiacertificadocurso = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.copiacertificadocurso).Select(y => y.Nombre).FirstOrDefault(),
                        declararentasol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.declararentasol).Select(y => y.Nombre).FirstOrDefault(),
                        beneficiariosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.beneficiariosol).Select(y => y.Nombre).FirstOrDefault(),
                        propietariosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.propietariosol).Select(y => y.Nombre).FirstOrDefault(),
                        penjudicialessol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.penjudicialessol).Select(y => y.Nombre).FirstOrDefault(),
                        ocupanteindebidosol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.ocupanteindebidosol).Select(y => y.Nombre).FirstOrDefault(),
                        victimadsol = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.victimadsol).Select(y => y.Nombre).FirstOrDefault(),
                        declararentacony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.declararentacony).Select(y => y.Nombre).FirstOrDefault(),
                        beneficiariocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.beneficiariocony).Select(y => y.Nombre).FirstOrDefault(),
                        propietariocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.propietariocony).Select(y => y.Nombre).FirstOrDefault(),
                        penjudicialescony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.penjudicialescony).Select(y => y.Nombre).FirstOrDefault(),
                        ocupanteindevidocony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.ocupanteindevidocony).Select(y => y.Nombre).FirstOrDefault(),
                        victimadcony = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.victimadcony).Select(y => y.Nombre).FirstOrDefault(),
                        inclusionreso = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.inclusionreso).Select(y => y.Nombre).FirstOrDefault(),

                        Id = c.Id,
                        radicado = c.radicado,
                        cargaorfeo = c.cargaorfeo,
                        Fechasignado = c.Fechasignado.Value,
                        feacharadicado = c.feacharadicado.Value,
                        fiso = c.fiso.Value,

                        departamento = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO.ToString() == c.departamento).Select(y => y.NOMBRE).FirstOrDefault(),
                        municipio = Ctx.CtCiudad.Where(x => x.IdCtMuncipio.ToString() == c.municipio && x.IdCtDepto.ToString() == c.departamento).Select(y => y.Nombre).FirstOrDefault(),

                        expediente = c.expediente,
                        fechafiso = c.fechafiso.Value,
                        tiposolicitud = c.tiposolicitud,


                        solicitante = c.solicitante,
                        docidentificacionsol = c.docidentificacionsol,
                        conyuge = c.conyuge,
                        docidentificacioncony = c.docidentificacioncony,

                        
                        respojuridico = Ctx.Users.Where(x => x.Id_Hash == c.respojuridico).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                        respoagronomo = Ctx.Users.Where(x => x.Id_Hash == c.respoagronomo).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                        respocatastral = Ctx.Users.Where(x => x.Id_Hash == c.respocatastral).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                        responsable = Ctx.Users.Where(x => x.Id_Hash == c.responsable).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),

                        fechaediccion = c.fechaediccion,
                        FechaInsercion = c.FechaInsercion,
                        FechaModificacion = c.FechaModificacion,
                        Gestion = c.Gestion,
                        IdAspNetUser = c.IdAspNetUser,
                        IdAspNetUserModifica = c.IdAspNetUserModifica,
                        Estado = c.Estado.Value,

                    }).OrderByDescending(d => d.FechaInsercion).ToList();

                #endregion
            }
            catch (Exception e ) {

                var error = e;
            }
            
            return lista;
        }

        public Ba_Memorando_newModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.Ba_Memorando_new.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .FirstOrDefault();

            Ba_Memorando_newModel Ba_Memorando_newModel_ = new Ba_Memorando_newModel();

           
                Ba_Memorando_newModel_.asignado = a.b.asignado;
                Ba_Memorando_newModel_.copiadoc = a.b.copiadoc;
                Ba_Memorando_newModel_.copiacertificadocurso = a.b.copiacertificadocurso;
                Ba_Memorando_newModel_.declararentasol = a.b.declararentasol;
                Ba_Memorando_newModel_.beneficiariosol = a.b.beneficiariosol;
                Ba_Memorando_newModel_.propietariosol = a.b.propietariosol;
                Ba_Memorando_newModel_.penjudicialessol = a.b.penjudicialessol;
                Ba_Memorando_newModel_.ocupanteindebidosol = a.b.ocupanteindebidosol;
                Ba_Memorando_newModel_.victimadsol = a.b.victimadsol;
                Ba_Memorando_newModel_.declararentacony = a.b.declararentacony;
                Ba_Memorando_newModel_.beneficiariocony = a.b.beneficiariocony;
                Ba_Memorando_newModel_.propietariocony = a.b.propietariocony;
                Ba_Memorando_newModel_.penjudicialescony = a.b.penjudicialescony;
                Ba_Memorando_newModel_.ocupanteindevidocony = a.b.ocupanteindevidocony;
                Ba_Memorando_newModel_.victimadcony = a.b.victimadcony;
                Ba_Memorando_newModel_.inclusionreso = a.b.inclusionreso;

                Ba_Memorando_newModel_.Id = a.b.Id;
                Ba_Memorando_newModel_.radicado = a.b.radicado;
                Ba_Memorando_newModel_.cargaorfeo = a.b.cargaorfeo;
                Ba_Memorando_newModel_.Fechasignado = a.b.Fechasignado.Value;
                Ba_Memorando_newModel_.feacharadicado = a.b.feacharadicado.Value;
                Ba_Memorando_newModel_.fiso = a.b.fiso.Value;
                Ba_Memorando_newModel_.municipio = a.b.municipio;
                Ba_Memorando_newModel_.departamento = a.b.departamento;
                Ba_Memorando_newModel_.expediente = a.b.expediente;
                Ba_Memorando_newModel_.fechafiso = a.b.fechafiso.Value;
                Ba_Memorando_newModel_.tiposolicitud = a.b.tiposolicitud;
                Ba_Memorando_newModel_.solicitante = a.b.solicitante;
                Ba_Memorando_newModel_.docidentificacionsol = a.b.docidentificacionsol;
                Ba_Memorando_newModel_.conyuge = a.b.conyuge;
                Ba_Memorando_newModel_.docidentificacioncony = a.b.docidentificacioncony;
                Ba_Memorando_newModel_.respojuridico = a.b.respojuridico;
                Ba_Memorando_newModel_.respoagronomo = a.b.respoagronomo;
                Ba_Memorando_newModel_.respocatastral = a.b.respocatastral;
                Ba_Memorando_newModel_.responsable = a.b.responsable;
                Ba_Memorando_newModel_.fechaediccion = a.b.fechaediccion;

                Ba_Memorando_newModel_.FechaInsercion = a.b.FechaInsercion;
                Ba_Memorando_newModel_.FechaModificacion =a.b.FechaModificacion;
                Ba_Memorando_newModel_.Gestion = a.b.Gestion;
                Ba_Memorando_newModel_.IdAspNetUser = a.b.IdAspNetUser;
                Ba_Memorando_newModel_.IdAspNetUserModifica = a.b.IdAspNetUserModifica;
                Ba_Memorando_newModel_.Estado = a.b.Estado.Value;

                Ba_Memorando_newModel_.rol = a.Name;
                Ba_Memorando_newModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;


            return Ba_Memorando_newModel_;
        }

        public Ba_Memorando_newModel Actualizar(Ba_Memorando_newModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var Ba_Memorando_newModel_ = Ctx.Ba_Memorando_new.Where(s => s.Id == a.Id).FirstOrDefault();
                if (Ba_Memorando_newModel_ != null)
                {
                    Ba_Memorando_newModel_.asignado = a.asignado;
                    Ba_Memorando_newModel_.copiadoc = a.copiadoc;
                    Ba_Memorando_newModel_.copiacertificadocurso = a.copiacertificadocurso;
                    Ba_Memorando_newModel_.declararentasol = a.declararentasol;
                    Ba_Memorando_newModel_.beneficiariosol = a.beneficiariosol;
                    Ba_Memorando_newModel_.propietariosol = a.propietariosol;
                    Ba_Memorando_newModel_.penjudicialessol = a.penjudicialessol;
                    Ba_Memorando_newModel_.ocupanteindebidosol = a.ocupanteindebidosol;
                    Ba_Memorando_newModel_.victimadsol = a.victimadsol;
                    Ba_Memorando_newModel_.declararentacony = a.declararentacony;
                    Ba_Memorando_newModel_.beneficiariocony = a.beneficiariocony;
                    Ba_Memorando_newModel_.propietariocony = a.propietariocony;
                    Ba_Memorando_newModel_.penjudicialescony = a.penjudicialescony;
                    Ba_Memorando_newModel_.ocupanteindevidocony = a.ocupanteindevidocony;
                    Ba_Memorando_newModel_.victimadcony = a.victimadcony;
                    Ba_Memorando_newModel_.inclusionreso = a.inclusionreso;

                    Ba_Memorando_newModel_.Id = a.Id;
                    Ba_Memorando_newModel_.radicado = a.radicado;
                    Ba_Memorando_newModel_.cargaorfeo = a.cargaorfeo;
                    Ba_Memorando_newModel_.Fechasignado = a.Fechasignado;
                    Ba_Memorando_newModel_.feacharadicado = a.feacharadicado;
                    Ba_Memorando_newModel_.fiso = a.fiso;
                    Ba_Memorando_newModel_.municipio = a.municipio;
                    Ba_Memorando_newModel_.departamento = a.departamento;
                    Ba_Memorando_newModel_.expediente = a.expediente;
                    Ba_Memorando_newModel_.fechafiso = a.fechafiso;
                    Ba_Memorando_newModel_.tiposolicitud = a.tiposolicitud;
                    Ba_Memorando_newModel_.solicitante = a.solicitante;
                    Ba_Memorando_newModel_.docidentificacionsol = a.docidentificacionsol;
                    Ba_Memorando_newModel_.conyuge = a.conyuge;
                    Ba_Memorando_newModel_.docidentificacioncony = a.docidentificacioncony;
                    Ba_Memorando_newModel_.respojuridico = a.respojuridico;
                    Ba_Memorando_newModel_.respoagronomo = a.respoagronomo;
                    Ba_Memorando_newModel_.respocatastral = a.respocatastral;
                    Ba_Memorando_newModel_.responsable = a.responsable;
                    Ba_Memorando_newModel_.fechaediccion = a.fechaediccion;

                    Ba_Memorando_newModel_.FechaInsercion = a.FechaInsercion.Value;
                    Ba_Memorando_newModel_.FechaModificacion = a.FechaModificacion;
                    Ba_Memorando_newModel_.Gestion = a.Gestion;
                    Ba_Memorando_newModel_.IdAspNetUser = a.IdAspNetUser;
                    Ba_Memorando_newModel_.IdAspNetUserModifica = a.IdAspNetUserModifica;
                    Ba_Memorando_newModel_.Estado = a.Estado;

                    Ba_Memorando_newModel_.FechaModificacion = DateTime.Now;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.Ba_Memorando_new.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        public List<Ba_MemorandoCatalogosModel> ConsultarCatalogo(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Ba_MemorandoCatalogos.Where(x => x.Tipo.Equals(id))
                .Select(a => new Ba_MemorandoCatalogosModel
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Tipo = a.Tipo,
                    Estado = a.Estado
                }).ToList();

            return lista;
        }
    }
}