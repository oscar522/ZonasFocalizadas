using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class ConceptoLogic
    {
        Concepto ModCtx = new Concepto();
        Concepto Concepto_ = new Concepto();

        public ConceptoModel Crear(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                int id = 0;
                if (a.Id <= 0)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Concepto_.Observacion = a.Observacion;
                    Concepto_.TerminoDias = a.TerminoDias;
                    Ctx.Concepto.Add(Concepto_);
                    Ctx.SaveChanges();
                    id = Concepto_.Id;
                }
                else {
                    id = a.Id;
                    Concepto_ = Ctx.Concepto.Where(x => x.Id == id).FirstOrDefault();
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Concepto_.Observacion = a.Observacion;
                    Concepto_.TerminoDias = a.TerminoDias;
                    Ctx.SaveChanges();
                }
                a.Id = id;
                return a;
            }
        }

        #region soportes

        public ConceptoModel CrearDocumentoSoporte(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                Concepto Concepto_ = new Concepto();
                int id = 0;

                if (a.Id <= 0)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Ctx.Concepto.Add(Concepto_);
                    Ctx.SaveChanges();
                    id = Concepto_.Id;
                    a.Id = Concepto_.Id;
                    List<string> listaAdmin =
                   Ctx.AspNetRoles
                  .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                  .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                  .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                  .Where(c => c.rol == "Administrator")
                  .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente + id, listaAdmin);
                }
                else
                {
                    id = a.Id;
                }
                ConceptosDocumentos ConceptosDocumentos_ = new ConceptosDocumentos
                {
                    Nombre = a.Soporte,
                    Tipo = 1,
                    IdConcepto = id,
                    Estado = true
                };
                Ctx.ConceptosDocumentos.Add(ConceptosDocumentos_);
                Ctx.SaveChanges();
                return a;
            }
        }
        public List<CtPaisModel> ConsultaDocumentoSoporte(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var Data = Ctx.ConceptosDocumentos.Where(x => x.IdConcepto == Id && x.Estado == true && x.Tipo == 1)
                    .Select(x => new CtPaisModel
                    {
                        ID_CT_PAIS = x.Id,
                        NOMBRE = x.Nombre
                    }).ToList();
                return Data;
            }
        }
        public string DeleteDocumentoSoporte(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var ResCtx = Ctx.ConceptosDocumentos.Where(x => x.Id == Id ).FirstOrDefault();

                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        #endregion

        #region Anexo

        public ConceptoModel CrearDocumentoAnexo(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                Concepto Concepto_ = new Concepto();
                int id = 0;

                if (a.Id <= 0)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Ctx.Concepto.Add(Concepto_);
                    Ctx.SaveChanges();
                    id = Concepto_.Id;
                    a.Id = Concepto_.Id;

                    List<string> listaAdmin =
                   Ctx.AspNetRoles
                  .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                  .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                  .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                  .Where(c => c.rol == "Administrator")
                  .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente + id, listaAdmin);
                }
                else
                {
                    id = a.Id;
                }
                ConceptosDocumentos ConceptosDocumentos_ = new ConceptosDocumentos
                {
                    Nombre = a.Anexo,
                    Tipo = 2,
                    IdConcepto = id,
                    Estado = true
                };
                Ctx.ConceptosDocumentos.Add(ConceptosDocumentos_);
                Ctx.SaveChanges();
                return a;
            }
        }
        public List<CtPaisModel> ConsultaDocumentoAnexo(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var Data = Ctx.ConceptosDocumentos.Where(x => x.IdConcepto == Id && x.Estado == true && x.Tipo == 2)
                    .Select(x => new CtPaisModel
                    {
                        ID_CT_PAIS = x.Id,
                        NOMBRE = x.Nombre
                    }).ToList();
                return Data;
            }
        }
        public string DeleteDocumentoAnexo(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var ResCtx = Ctx.ConceptosDocumentos.Where(x => x.Id == Id).FirstOrDefault();

                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        #endregion

        #region Expediente

        public ConceptoModel CrearExpediente(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                Concepto Concepto_ = new Concepto();
                int id = 0;

                if (a.Id <= 0)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Ctx.Concepto.Add(Concepto_);
                    Ctx.SaveChanges();
                    id = Concepto_.Id;
                    a.Id = Concepto_.Id;

                    List<string> listaAdmin =
                   Ctx.AspNetRoles
                  .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                  .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                  .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                  .Where(c => c.rol == "Administrator")
                  .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente + id, listaAdmin);

                }
                else
                {
                    id = a.Id;
                }
                CoceptosExpediente ConceptosDocumentos_ = new CoceptosExpediente
                {
                    IdExpediente = a.IdExpediente,
                    IdConcepto = id,
                    Estado = true
                };
                Ctx.CoceptosExpediente.Add(ConceptosDocumentos_);
                Ctx.SaveChanges();
                return a;
            }
        }
        public BaldiosPersonaNaturalModel ConsultaExpediente(string Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var listaBaldios = Ctx.BaldiosPersonaNatural
                     .Where(w => w.NumeroExpediente == Id).ToList();
                #region Sql
                var lista = listaBaldios
                    //.Where(w => w.IdAspNetUser == IdP)
                    .Join(Ctx.CtDepto, b => b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                     new
                     {
                         b.id,
                         b.NumeroExpediente,
                         b.IdDepto,
                         b.IdCiudad,
                         b.Vereda,
                         b.NombrePredio,
                         b.NombreBeneficiario,
                         b.IdTipoIdentificacion,
                         b.Identificacion,
                         b.IdGenero,
                         b.IdTipoIdentificacionConyuge,
                         b.IdentificacionConyuge,
                         b.NombreConyuge,
                         b.EstadoInicialMigracion,
                         b.IdAspNetUser,
                         b.EstadoCaracterizacion,
                         b.RutaArchivoOriginal,
                         NombrDepto = c.NOMBRE
                     })
                    .Join(Ctx.CtCiudad, d => d.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                     new
                     {
                         d.id,
                         d.NumeroExpediente,
                         d.IdDepto,
                         d.IdCiudad,
                         d.Vereda,
                         d.NombrePredio,
                         d.NombreBeneficiario,
                         d.IdTipoIdentificacion,
                         d.Identificacion,
                         d.IdGenero,
                         d.IdTipoIdentificacionConyuge,
                         d.IdentificacionConyuge,
                         d.NombreConyuge,
                         d.EstadoInicialMigracion,
                         d.IdAspNetUser,
                         d.EstadoCaracterizacion,
                         d.RutaArchivoOriginal,
                         d.NombrDepto,
                         NombreMunicipio = e.Nombre,
                         MunicipioIdDepto = e.IdCtDepto
                     })
                    .Join(Ctx.CtTipoIdentificacion, f => f.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                     new
                     {
                         f.id,
                         f.NumeroExpediente,
                         f.IdDepto,
                         f.IdCiudad,
                         f.Vereda,
                         f.NombrePredio,
                         f.NombreBeneficiario,
                         f.IdTipoIdentificacion,
                         f.Identificacion,
                         f.IdGenero,
                         f.IdTipoIdentificacionConyuge,
                         f.IdentificacionConyuge,
                         f.NombreConyuge,
                         f.EstadoInicialMigracion,
                         f.IdAspNetUser,
                         f.EstadoCaracterizacion,
                         f.RutaArchivoOriginal,
                         f.NombrDepto,
                         f.NombreMunicipio,
                         NombreTipoIdentificacion = g.NOMBRE,
                         f.MunicipioIdDepto
                     })
                    .Join(Ctx.CtGenero, h => h.IdGenero, i => i.ID_GENERO, (h, i) =>
                     new
                     {
                         h.id,
                         h.NumeroExpediente,
                         h.IdDepto,
                         h.IdCiudad,
                         h.Vereda,
                         h.NombrePredio,
                         h.NombreBeneficiario,
                         h.IdTipoIdentificacion,
                         h.Identificacion,
                         h.IdGenero,
                         h.IdTipoIdentificacionConyuge,
                         h.IdentificacionConyuge,
                         h.NombreConyuge,
                         h.EstadoInicialMigracion,
                         h.IdAspNetUser,
                         h.EstadoCaracterizacion,
                         h.RutaArchivoOriginal,
                         h.NombrDepto,
                         h.NombreMunicipio,
                         h.NombreTipoIdentificacion,
                         h.MunicipioIdDepto,
                         NombreGenero = i.NOMBRE
                     })
                    .Join(Ctx.CtTipoIdentificacion, j => j.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                     new
                     {
                         j.id,
                         j.NumeroExpediente,
                         j.IdDepto,
                         j.IdCiudad,
                         j.Vereda,
                         j.NombrePredio,
                         j.NombreBeneficiario,
                         j.IdTipoIdentificacion,
                         j.Identificacion,
                         j.IdGenero,
                         j.IdTipoIdentificacionConyuge,
                         j.IdentificacionConyuge,
                         j.NombreConyuge,
                         j.EstadoInicialMigracion,
                         j.IdAspNetUser,
                         j.EstadoCaracterizacion,
                         j.RutaArchivoOriginal,
                         j.NombrDepto,
                         j.NombreMunicipio,
                         j.NombreTipoIdentificacion,
                         j.MunicipioIdDepto,
                         j.NombreGenero,
                         NombreTipoIdentificacionConyuge = k.NOMBRE
                     })
                     .Where(w => w.MunicipioIdDepto == w.IdDepto)
                    .Select(c => new BaldiosPersonaNaturalModel
                    {
                        id = c.id,
                        NumeroExpediente = c.NumeroExpediente,
                        IdDepto = c.IdDepto,
                        IdCiudad = c.IdCiudad,
                        Vereda = c.Vereda,
                        NombrePredio = c.NombrePredio,
                        NombreBeneficiario = c.NombreBeneficiario,
                        IdTipoIdentificacion = c.IdTipoIdentificacion,
                        Identificacion = c.Identificacion,
                        IdGenero = c.IdGenero,
                        IdTipoIdentificacionConyuge = c.IdTipoIdentificacionConyuge,
                        IdentificacionConyuge = c.IdentificacionConyuge,
                        NombreConyuge = c.NombreConyuge,
                        EstadoInicialMigracion = c.EstadoInicialMigracion,
                        IdAspNetUser = c.IdAspNetUser,
                        EstadoCaracterizacion = c.EstadoCaracterizacion,
                        RutaArchivoOriginal = c.RutaArchivoOriginal,
                        NombreIdDepto = c.NombrDepto,
                        NombreIdCiudad = c.NombreMunicipio,
                        NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                        NombreIdGenero = c.NombreGenero,
                        NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                    }).OrderByDescending(d => d.EstadoCaracterizacion).FirstOrDefault();

                #endregion
                return lista;
            }
        }

        public List<CtPaisModel> ConsultaExpedientesAsociados(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var Data = Ctx.CoceptosExpediente.Where(x => x.IdConcepto == Id && x.Estado == true)
                    .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new {b.Id,c.NumeroExpediente,c.RutaArchivoOriginal })

                   .Select(x => new CtPaisModel
                    {
                        ID_CT_PAIS = x.Id,
                        NOMBRE = x.NumeroExpediente+"||"+x.RutaArchivoOriginal
                   }).ToList();
                return Data;
            }
        }

        public string DeleteExpediente(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var ResCtx = Ctx.CoceptosExpediente.Where(x => x.Id == Id).FirstOrDefault();

                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        #endregion

        #region UsuariosAsociados

        public ConceptoModel CrearUsuariosAsociados(ConceptoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                Concepto Concepto_ = new Concepto();
                int id = 0;

                if (a.Id <= 0)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Ctx.Concepto.Add(Concepto_);
                    Ctx.SaveChanges();
                    
                    id = Concepto_.Id;
                    
                    a.Id = Concepto_.Id;

                    List<string> listaAdmin =
                    Ctx.AspNetRoles
                   .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                   .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                   .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                   .Where(c => c.rol == "Administrator")
                   .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente + id, listaAdmin);

                }
                else
                {
                    List<string> listaAdmin = Ctx.AspNetRoles
                      .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                      .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                      .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                      .Where(c => c.Id_Hash == a.UserAsociado)
                      .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente, listaAdmin);
                    id = a.Id;
                }
                ConceptoAsociado ConceptoAsociado_ = new ConceptoAsociado
                {
                    IdAspNetUser = a.UserAsociado,
                    FechaInsercion = DateTime.Now,
                    IdConcepto = id,
                    Estado = true
                };
                Ctx.ConceptoAsociado.Add(ConceptoAsociado_);
                Ctx.SaveChanges();
                return a;
            }
        }
        
        public List<ConceptoModel> ConsultaUsuariosAsociados(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var lista =
                Ctx.AspNetRoles
               .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
               .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
               .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash })
               .Join(Ctx.ConceptoAsociado, b => b.Id_Hash, c => c.IdAspNetUser, (b, c) => new { b.rol, b.Name, b.FirstName, b.LastName, b.Id_Hash, c.IdAsociacion, c.IdConcepto, c.IdAspNetUser, c.FechaInsercion, c.Estado })
               .Where(c => c.Estado == true && c.IdConcepto == Id)
               .Select(a => new ConceptoModel
               {
                   Id = a.IdAsociacion,
                   IdExpediente = a.IdConcepto,
                   NombreAspNetUsers = a.Name + " " + a.FirstName + " " + a.LastName,
                   Rol = a.rol,
                   FechaCreacion = a.FechaInsercion,
                   Estado = a.Estado
               }).ToList();
                return lista;
            }
        }

        public string DeleteUsuariosAsociados(int Id)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                var ResCtx = Ctx.ConceptoAsociado.Where(x => x.IdAsociacion == Id).FirstOrDefault();

                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        #endregion

        public List<ConceptoModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.Concepto
                 .Join(Ctx.AspNetUsers, b => b.IdAspNetUsers, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,b.IdOrfeo, b.Estado, IdUser = c.Id })

                .Join(Ctx.Users, b => b.IdUser, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdOrfeo, b.Estado, c.Name, c.FirstName, c.LastName })

                .Join(Ctx.CtCausas, b => b.IdCausa, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, causa = c.Nombre })

                .Join(Ctx.ConceptoAsociado, b => b.Id, c => c.IdConcepto, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, UserAsociado = c.IdAspNetUser })

                .Join(Ctx.Users, b => b.UserAsociado, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, UserAsociadoName = c.Name + " " + c.FirstName + " " + c.LastName })

                .Join(Ctx.AspNetUserRoles, b => b.UserAsociado, c => c.UserId, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, c.RoleId })

                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa, b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, NombreRol = c.Name })


                .Where(c => c.Estado.Value == true).Select(a => new ConceptoModel
                {
                    Id = a.Id,
                    IdAspNetUsers = a.IdAspNetUsers,
                    NombreAspNetUsers = a.Name + " " + a.FirstName + " " + a.LastName,
                    IdCausa = a.IdCausa,
                    NombreCausa = a.causa,
                    UserAsociado = a.UserAsociadoName,
                    Rol = a.NombreRol,
                    IdOrfeo = a.IdOrfeo,
                    Estado = a.Estado,
                    FechaCreacion = a.FechaCreacion
                }).OrderBy(x =>x.Id);

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
                IdOrfeo = a.IdOrfeo,
                Estado = a.Estado,
                TerminoDias = a.TerminoDias.Value,
                Observacion = a.Observacion
            });

            return lista.ToList();
        }
        public ConceptoModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
               
            var lista = Ctx.Concepto.Where(x => x.Id == id)
                 .Join(Ctx.AspNetUsers, b => b.IdAspNetUsers, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, IdUser = c.Id, b.Observacion, b.TerminoDias })

                .Join(Ctx.Users, b => b.IdUser, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, c.Name, c.FirstName, c.LastName, b.Observacion, b.TerminoDias })

                .Join(Ctx.CtCausas, b => b.IdCausa, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, causa = c.Nombre, b.Observacion, b.TerminoDias })

                .Join(Ctx.ConceptoAsociado, b => b.Id, c => c.IdConcepto, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, UserAsociado = c.IdAspNetUser, b.Observacion, b.TerminoDias })

                .Join(Ctx.Users, b => b.UserAsociado, c => c.Id_Hash, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, UserAsociadoName = c.Name + " " + c.FirstName + " " + c.LastName, b.Observacion, b.TerminoDias })

                .Join(Ctx.AspNetUserRoles, b => b.UserAsociado, c => c.UserId, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, c.RoleId, b.Observacion, b.TerminoDias })

                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) =>
                 new { b.FechaCreacion, b.Id, b.IdAspNetUsers, b.IdCausa,  b.IdOrfeo, b.Estado, b.Name, b.FirstName, b.LastName, b.causa, b.UserAsociado, b.UserAsociadoName, NombreRol = c.Name, b.Observacion, b.TerminoDias })

                .Where(c => c.Estado.Value == true).Select(a => new ConceptoModel
                {
                    Id = a.Id,
                    IdAspNetUsers = a.IdAspNetUsers,
                    NombreAspNetUsers = a.Name + " " + a.FirstName + " " + a.LastName,
                    IdCausa = a.IdCausa,
                    NombreCausa = a.causa,
                    UserAsociado = a.UserAsociadoName,
                    Rol = a.NombreRol,
                    IdOrfeo = a.IdOrfeo,
                    Estado = a.Estado,
                    FechaCreacion = a.FechaCreacion,
                    TerminoDias = a.TerminoDias.Value,
                    Observacion = a.Observacion
                }).OrderBy(x => x.Id).FirstOrDefault();

            return lista;
        }
        public ConceptoModel Actualizar(ConceptoModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var Concepto_ = Ctx.Concepto.Where(s => s.Id == a.Id).FirstOrDefault();
                if (Concepto_ != null)
                {
                    Concepto_.IdAspNetUsers = a.IdAspNetUsers;
                    Concepto_.IdCausa = a.IdCausa;
                    Concepto_.IdOrfeo = a.IdOrfeo;
                    Concepto_.Estado = true;
                    Concepto_.FechaCreacion = DateTime.Now;
                    Concepto_.Observacion = a.Observacion;
                    Concepto_.TerminoDias = a.TerminoDias;
                    Ctx.SaveChanges();

                }

                
                if (a.UserAsociado != "N/A")
                {
                    List<string> listaAdmin =
                      Ctx.AspNetRoles
                     .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                     .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new { b.rol, c.Id, b.UserId, b.RoleId })
                     .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol, c.Name, c.FirstName, c.LastName, c.Id_Hash, c.Email })
                     .Where(c => c.Id_Hash == a.UserAsociado)
                     .Select(c => c.Email).ToList();
                    EnviarCorreo(a.RutaExpediente, listaAdmin);
                    ConceptoAsociado ConceptoAsociado_ = new ConceptoAsociado
                    {
                        IdConcepto = a.Id,
                        IdAspNetUser = a.UserAsociado,
                        Estado = true,
                        FechaInsercion = a.FechaCreacion
                    };
                    Ctx.ConceptoAsociado.Add(ConceptoAsociado_);
                    Ctx.SaveChanges();
                }
                
                return a;
                
            }
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
        public String EliminarAsociado(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.ConceptoAsociado.Where(s => s.IdAsociacion == id).FirstOrDefault();
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
                .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new {  c.FirstName, c.LastName, b.RoleId, c.Id })
                .Where(c => c.RoleId == rol)
                .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new {  c.Name, c.FirstName, b.LastName, c.Id_Hash })
                .Select(a => new CtDeptoModel
                {
                    ID_CT_DEPTO = 0,
                    NOMBRE = a.Name+" "+a.FirstName + " " + a.LastName,
                    ID_CT_PAIS = 0,
                    NOMBRE_PAIS = a.Id_Hash
                });
            return lista.ToList();
        }
        public List<ConceptoModel> ConsultaUsuarioConcepto(int IdConcepto)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = 
                 Ctx.AspNetRoles
                .Join(Ctx.AspNetUserRoles, b => b.Id, c => c.RoleId, (b, c) => new { c.UserId, c.RoleId, rol = b.Name })
                .Join(Ctx.AspNetUsers, b => b.UserId, c => c.Id, (b, c) => new {b.rol,c.Id, b.UserId, b.RoleId })
                .Join(Ctx.Users, b => b.Id, c => c.Id_Hash, (b, c) => new { b.rol,  c.Name, c.FirstName, c.LastName, c.Id_Hash })
                .Join(Ctx.ConceptoAsociado, b => b.Id_Hash, c => c.IdAspNetUser, (b, c) => new { b.rol, b.Name, b.FirstName, b.LastName, b.Id_Hash, c.IdAsociacion,c.IdConcepto,c.IdAspNetUser, c.FechaInsercion , c.Estado })
                .Where(c =>c.Estado == true && c.IdConcepto == IdConcepto)
                .Select(a => new ConceptoModel
                {
                    Id = a.IdAsociacion,
                    IdExpediente = a.IdConcepto,
                    NombreAspNetUsers = a.Name + " " + a.FirstName + " " + a.LastName,
                    Rol = a.rol,
                    FechaCreacion = a.FechaInsercion,
                    Estado = a.Estado
                }).ToList();
            return lista;
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
        private void EnviarCorreo(string url , List<string> listaAdmin)
        {

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            email.To.Add(new MailAddress("oscar.ballesteros.b@gmail.com"));
            email.From = new MailAddress("oscar.ballesteros.b@gmail.com");
            email.Subject = "Notificación solicitud de concepto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "Se creo una nueva solicitud de concepto, Por favor inicie sesion y ingrese a este <a href='"+url+"'>Link</a> ";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            smtp.Host = "smtp.gmail.com";  // IP empresa/institucional
                                          //smtp.Host = "smtp.hotmail.com";
                                          //smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("oscar.ballesteros.b@gmail.com", "11Princesa");
            smtp.EnableSsl = true;
            string output ="";
           
            try
            {
                foreach (string dir in listaAdmin)
                {
                    email.To.Add(dir);
                }

                smtp.Send(email);
                email.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (SmtpException exm)
            {
                output = exm.Message.ToString();
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

        }
    }
}