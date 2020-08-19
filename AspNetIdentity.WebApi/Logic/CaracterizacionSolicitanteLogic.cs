using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CaracterizacionSolicitanteLogic
    {
        CaracterizacionSolicitante ModCtx = new CaracterizacionSolicitante();

        //public CaracterizacionSolicitanteModel Crear(CaracterizacionSolicitanteModel a)
        //{
        //    using (ZonasFEntities Ctx = new ZonasFEntities())
        //    {
        //        CaracterizacionSolicitante Nuevo = new CaracterizacionSolicitante
        //        {
        //            Id = a.Id,
        //            IdExpediente = a.IdExpediente,


        //            NombreSolicitante = a.NombreSolicitante,
        //            TipoDocumento = a.TipoDocumento,
        //            NumeroIdentificacion = a.NumeroIdentificacion,
        //            FechaExpedicionSolicitante = a.FechaExpedicionSolicitante,

        //            NombreConyuge = a.NombreConyuge,
        //            TipoDocumentoConyuge = a.TipoDocumentoConyuge,
        //            NumeroIdentificacionConyuge = a.NumeroIdentificacionConyuge,
        //            FechaExpedicionConyuge = a.FechaExpedicionConyuge,
                    

        //            VFechaSolicitante = a.VFechaSolicitante,
        //            VArchivoSolicitante = a.VArchivoSolicitante,
        //            VVivoSolicitante = a.VVivoSolicitante,

        //            VFechaConyuge = a.VFechaConyuge,
        //            VArchivoConyuge = a.VArchivoConyuge,
        //            VVivoConyuge = a.VVivoConyuge,


        //            PFechaSolicitante = a.PFechaSolicitante,
        //            PArchivoSolicitante = a.PArchivoSolicitante,
        //            PInhabilidadSolicitante = a.PInhabilidadSolicitante,

        //            PFechaConyuge = a.PFechaConyuge,
        //            PArchivoConyuge = a.PArchivoConyuge,
        //            PInhabilidadConyuge = a.PInhabilidadConyuge,

                    
        //            CFechaSolicitante = a.CFechaSolicitante,
        //            CArchivoSolicitante = a.CArchivoSolicitante,
        //            CInhabilidadSolicitante = a.CInhabilidadSolicitante,

        //            CFechaConyuge = a.CFechaConyuge,
        //            CArchivoConyuge = a.CArchivoConyuge,
        //            CInhabilidadConyuge = a.CInhabilidadConyuge,

        //            AFechaSolicitante = a.AFechaSolicitante,
        //            AArchivoSolicitante = a.AArchivoSolicitante,
        //            AInhabilidadSolicitante =a.AInhabilidadSolicitante,

        //            AFechaConyuge = a.AFechaConyuge,
        //            AArchivoConyuge = a.AArchivoConyuge,
        //            AInhabilidadConyuge = a.AInhabilidadConyuge,

        //            Gestion = a.Gestion,
        //            IdAspNetUser = a.IdAspNetUser,
        //            Estado = a.Estado,
        //            FechaModificacion = DateTime.Now,

        //        };

        //        Ctx.CaracterizacionSolicitante.Add(Nuevo);
        //        Ctx.SaveChanges();
        //        return a;
        //    }
        //}

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionSolicitante
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, TipoDocSol = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, TipoDocCon = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon,  TipoDocSolExp = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.TipoDocSolExp, TipoDocConExp = c })
                .Where(x => x.caracte.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                {
                    Id = a.caracte.Id,
                    IdExpediente = a.caracte.IdExpediente,
                    NumeroExpediente = a.baldios.NumeroExpediente,
                    IdDepto = a.depto.ID_CT_DEPTO,
                    NombreDepto = a.depto.NOMBRE,
                    IdMunicipio = a.munic.IdCtMuncipio,
                    NombreMunicipio = a.munic.Nombre,
                    
                    NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                    DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),
                    TipoDocSolicitanteExpediente = a.TipoDocSolExp.NOMBRE,
                    IdTipoDocSolicitanteExpediente = a.TipoDocSolExp.ID_CT_TIPO_IDENTIFICACION,
                    
                    NombreConyugeExpediente = a.baldios.NombreConyuge,
                    DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),
                    TipoDocConyugeExpediente = a.TipoDocConExp.NOMBRE,
                    IdTipoDocConyugeExpediente = a.TipoDocConExp.ID_CT_TIPO_IDENTIFICACION,

                    
                    DocVisibleSol = a.caracte.DocVisibleSol,
                    CedulaExpSol = a.caracte.CedulaExpSol,
                    NombreSolicitante = a.caracte.NombreSolicitante,
                    TipoDocumento = a.caracte.TipoDocumento,
                    NombreTipoDocumento = a.TipoDocSol.NOMBRE,
                    NumeroIdentificacion = a.caracte.NumeroIdentificacion,
                    FechaExpedicionSolicitante = a.caracte.FechaExpedicionSolicitante,
                    
                    DocVisibleCon = a.caracte.DocVisibleCon,
                    CedulaExpCon = a.caracte.CedulaExpCon,
                    NombreConyuge = a.caracte.NombreConyuge,
                    TipoDocumentoConyuge = a.caracte.TipoDocumentoConyuge,
                    NombreTipoDocumentoConyuge = a.TipoDocCon.NOMBRE,
                    NumeroIdentificacionConyuge = a.caracte.NumeroIdentificacionConyuge,
                    FechaExpedicionConyuge = a.caracte.FechaExpedicionConyuge,


                    VFechaSolicitante = a.caracte.VFechaSolicitante,
                    VArchivoSolicitante = a.caracte.VArchivoSolicitante,
                    VVivoSolicitante = a.caracte.VVivoSolicitante,

                    VFechaConyuge = a.caracte.VFechaConyuge,
                    VArchivoConyuge = a.caracte.VArchivoConyuge,
                    VVivoConyuge = a.caracte.VVivoConyuge,


                    PFechaSolicitante = a.caracte.PFechaSolicitante,
                    PArchivoSolicitante = a.caracte.PArchivoSolicitante,
                    PInhabilidadSolicitante = a.caracte.PInhabilidadSolicitante,

                    PFechaConyuge = a.caracte.PFechaConyuge,
                    PArchivoConyuge = a.caracte.PArchivoConyuge,
                    PInhabilidadConyuge = a.caracte.PInhabilidadConyuge,


                    CFechaSolicitante = a.caracte.CFechaSolicitante,
                    CArchivoSolicitante = a.caracte.CArchivoSolicitante,
                    CInhabilidadSolicitante = a.caracte.CInhabilidadSolicitante,

                    CFechaConyuge = a.caracte.CFechaConyuge,
                    CArchivoConyuge = a.caracte.CArchivoConyuge,
                    CInhabilidadConyuge = a.caracte.CInhabilidadConyuge,


                    AFechaSolicitante = a.caracte.AFechaSolicitante,
                    AArchivoSolicitante = a.caracte.AArchivoSolicitante,
                    AInhabilidadSolicitante = a.caracte.AInhabilidadSolicitante,

                    AFechaConyuge = a.caracte.AFechaConyuge,
                    AArchivoConyuge = a.caracte.AArchivoConyuge,
                    AInhabilidadConyuge = a.caracte.AInhabilidadConyuge,

                    Gestion = a.caracte.Gestion,
                    //IdAspNetUser = a.caracte.IdAspNetUser,
                    IdAspNetUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x =>x.Id_Hash).FirstOrDefault(),
                    ///NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                    NombretUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x => x.Name + " " + x.FirstName + " " + x.LastName).FirstOrDefault(),
                    RolUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser)
                                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) => new { UserRoles = c })
                                .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { c }).Select(f =>f.c.Name).FirstOrDefault(),
                    Estado = a.caracte.Estado,

                }).ToList(); 

            return lista;
        }

        public CaracterizacionSolicitanteModel ConsultarId(long id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.CaracterizacionSolicitante
                    .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                    .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                    .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                    .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                    .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, TipoDocSol = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, TipoDocCon = c })
                    .Join(Ctx.Users, b => b.caracte.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, users = c })
                    .Join(Ctx.AspNetUserRoles, b => b.users.Id_Hash, c => c.UserId, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, UserRoles = c })
                    .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, Roles = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, TipoDocSolExp = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, b.TipoDocSolExp, TipoDocConExp = c })
                    .Where(x => x.caracte.Estado == true).Where(x => x.caracte.Id == id).Select(a => new CaracterizacionSolicitanteModel
                    {
                        Id = a.caracte.Id,
                        IdExpediente = a.caracte.IdExpediente,
                        NumeroExpediente = a.baldios.NumeroExpediente,
                        IdDepto = a.depto.ID_CT_DEPTO,
                        NombreDepto = a.depto.NOMBRE,
                        IdMunicipio = a.munic.IdCtMuncipio,
                        NombreMunicipio = a.munic.Nombre,


                        NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                        DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),
                        TipoDocSolicitanteExpediente = a.TipoDocSolExp.NOMBRE,
                        IdTipoDocSolicitanteExpediente = a.TipoDocSolExp.ID_CT_TIPO_IDENTIFICACION,

                        NombreConyugeExpediente = a.baldios.NombreConyuge,
                        DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),
                        TipoDocConyugeExpediente = a.TipoDocConExp.NOMBRE,
                        IdTipoDocConyugeExpediente = a.TipoDocConExp.ID_CT_TIPO_IDENTIFICACION,


                        DocVisibleSol = a.caracte.DocVisibleSol,
                        CedulaExpSol = a.caracte.CedulaExpSol,
                        NombreSolicitante = a.caracte.NombreSolicitante,
                        TipoDocumento = a.caracte.TipoDocumento,
                        NombreTipoDocumento = a.TipoDocSol.NOMBRE,
                        NumeroIdentificacion = a.caracte.NumeroIdentificacion,
                        FechaExpedicionSolicitante = a.caracte.FechaExpedicionSolicitante,

                        DocVisibleCon = a.caracte.DocVisibleCon,
                        CedulaExpCon = a.caracte.CedulaExpCon,
                        NombreConyuge = a.caracte.NombreConyuge,
                        TipoDocumentoConyuge = a.caracte.TipoDocumentoConyuge,
                        NombreTipoDocumentoConyuge = a.TipoDocCon.NOMBRE,
                        NumeroIdentificacionConyuge = a.caracte.NumeroIdentificacionConyuge,
                        FechaExpedicionConyuge = a.caracte.FechaExpedicionConyuge,


                        VFechaSolicitante = a.caracte.VFechaSolicitante,
                        VArchivoSolicitante = a.caracte.VArchivoSolicitante,
                        VVivoSolicitante = a.caracte.VVivoSolicitante,

                        VFechaConyuge = a.caracte.VFechaConyuge,
                        VArchivoConyuge = a.caracte.VArchivoConyuge,
                        VVivoConyuge = a.caracte.VVivoConyuge,


                        PFechaSolicitante = a.caracte.PFechaSolicitante,
                        PArchivoSolicitante = a.caracte.PArchivoSolicitante,
                        PInhabilidadSolicitante = a.caracte.PInhabilidadSolicitante,

                        PFechaConyuge = a.caracte.PFechaConyuge,
                        PArchivoConyuge = a.caracte.PArchivoConyuge,
                        PInhabilidadConyuge = a.caracte.PInhabilidadConyuge,


                        CFechaSolicitante = a.caracte.CFechaSolicitante,
                        CArchivoSolicitante = a.caracte.CArchivoSolicitante,
                        CInhabilidadSolicitante = a.caracte.CInhabilidadSolicitante,

                        CFechaConyuge = a.caracte.CFechaConyuge,
                        CArchivoConyuge = a.caracte.CArchivoConyuge,
                        CInhabilidadConyuge = a.caracte.CInhabilidadConyuge,


                        AFechaSolicitante = a.caracte.AFechaSolicitante,
                        AArchivoSolicitante = a.caracte.AArchivoSolicitante,
                        AInhabilidadSolicitante = a.caracte.AInhabilidadSolicitante,

                        AFechaConyuge = a.caracte.AFechaConyuge,
                        AArchivoConyuge = a.caracte.AArchivoConyuge,
                        AInhabilidadConyuge = a.caracte.AInhabilidadConyuge,

                        Gestion = a.caracte.Gestion,
                        IdAspNetUser = a.caracte.IdAspNetUser,
                        NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                        RolUser = a.Roles.Name,
                        Estado = a.caracte.Estado,


                    }).FirstOrDefault();

            return lista;
        }

        public CaracterizacionSolicitanteModel ConsultarIdExp(long id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            CaracterizacionSolicitanteModel CaracterizacionSolicitante_ = new CaracterizacionSolicitanteModel();

            var lista = Ctx.CaracterizacionSolicitante
                    .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                    .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                    .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                    .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                    .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, TipoDocSol = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, TipoDocCon = c })
                    .Join(Ctx.Users, b => b.caracte.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, users = c })
                    .Join(Ctx.AspNetUserRoles, b => b.users.Id_Hash, c => c.UserId, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, UserRoles = c })
                    .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, Roles = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, TipoDocSolExp = c })
                    .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, b.TipoDocSolExp, TipoDocConExp = c })
                    .Where(x => x.caracte.Estado == true).Where(x => x.caracte.IdExpediente == id).Select(a => new CaracterizacionSolicitanteModel
                    {
                        Id = a.caracte.Id,
                        IdExpediente = a.caracte.IdExpediente,
                        NumeroExpediente = a.baldios.NumeroExpediente,
                        IdDepto = a.depto.ID_CT_DEPTO,
                        NombreDepto = a.depto.NOMBRE,
                        IdMunicipio = a.munic.IdCtMuncipio,
                        NombreMunicipio = a.munic.Nombre,


                        NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                        DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),
                        TipoDocSolicitanteExpediente = a.TipoDocSolExp.NOMBRE,
                        IdTipoDocSolicitanteExpediente = a.TipoDocSolExp.ID_CT_TIPO_IDENTIFICACION,

                        NombreConyugeExpediente = a.baldios.NombreConyuge,
                        DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),
                        TipoDocConyugeExpediente = a.TipoDocConExp.NOMBRE,
                        IdTipoDocConyugeExpediente = a.TipoDocConExp.ID_CT_TIPO_IDENTIFICACION,


                        DocVisibleSol = a.caracte.DocVisibleSol,
                        CedulaExpSol = a.caracte.CedulaExpSol,
                        NombreSolicitante = a.caracte.NombreSolicitante,
                        TipoDocumento = a.caracte.TipoDocumento,
                        NombreTipoDocumento = a.TipoDocSol.NOMBRE,
                        NumeroIdentificacion = a.caracte.NumeroIdentificacion,
                        FechaExpedicionSolicitante = a.caracte.FechaExpedicionSolicitante,

                        DocVisibleCon = a.caracte.DocVisibleCon,
                        CedulaExpCon = a.caracte.CedulaExpCon,
                        NombreConyuge = a.caracte.NombreConyuge,
                        TipoDocumentoConyuge = a.caracte.TipoDocumentoConyuge,
                        NombreTipoDocumentoConyuge = a.TipoDocCon.NOMBRE,
                        NumeroIdentificacionConyuge = a.caracte.NumeroIdentificacionConyuge,
                        FechaExpedicionConyuge = a.caracte.FechaExpedicionConyuge,


                        VFechaSolicitante = a.caracte.VFechaSolicitante,
                        VArchivoSolicitante = a.caracte.VArchivoSolicitante,
                        VVivoSolicitante = a.caracte.VVivoSolicitante,

                        VFechaConyuge = a.caracte.VFechaConyuge,
                        VArchivoConyuge = a.caracte.VArchivoConyuge,
                        VVivoConyuge = a.caracte.VVivoConyuge,


                        PFechaSolicitante = a.caracte.PFechaSolicitante,
                        PArchivoSolicitante = a.caracte.PArchivoSolicitante,
                        PInhabilidadSolicitante = a.caracte.PInhabilidadSolicitante,

                        PFechaConyuge = a.caracte.PFechaConyuge,
                        PArchivoConyuge = a.caracte.PArchivoConyuge,
                        PInhabilidadConyuge = a.caracte.PInhabilidadConyuge,


                        CFechaSolicitante = a.caracte.CFechaSolicitante,
                        CArchivoSolicitante = a.caracte.CArchivoSolicitante,
                        CInhabilidadSolicitante = a.caracte.CInhabilidadSolicitante,

                        CFechaConyuge = a.caracte.CFechaConyuge,
                        CArchivoConyuge = a.caracte.CArchivoConyuge,
                        CInhabilidadConyuge = a.caracte.CInhabilidadConyuge,


                        AFechaSolicitante = a.caracte.AFechaSolicitante,
                        AArchivoSolicitante = a.caracte.AArchivoSolicitante,
                        AInhabilidadSolicitante = a.caracte.AInhabilidadSolicitante,

                        AFechaConyuge = a.caracte.AFechaConyuge,
                        AArchivoConyuge = a.caracte.AArchivoConyuge,
                        AInhabilidadConyuge = a.caracte.AInhabilidadConyuge,

                        Gestion = a.caracte.Gestion,
                        IdAspNetUser = a.caracte.IdAspNetUser,
                        NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                        RolUser = a.Roles.Name,
                        Estado = a.caracte.Estado,


                    }).FirstOrDefault();

            if (lista != null )
            {
                CaracterizacionSolicitante_ = lista;
            }

            return CaracterizacionSolicitante_;
        }

        public List<CaracterizacionSolicitanteModel> ConsultarIdUser(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var lista = Ctx.CaracterizacionSolicitante
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumento, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, TipoDocSol = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.caracte.TipoDocumentoConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, TipoDocCon = c })
                .Join(Ctx.Users, b => b.caracte.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, users = c })
                .Join(Ctx.AspNetUserRoles, b => b.users.Id_Hash, c => c.UserId, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, UserRoles = c })
                .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, Roles = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacion, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, TipoDocSolExp = c })
                .Join(Ctx.CtTipoIdentificacion, b => b.baldios.IdTipoIdentificacionConyuge, c => c.ID_CT_TIPO_IDENTIFICACION, (b, c) => new { b.caracte, b.baldios, b.depto, b.munic, b.TipoDocSol, b.TipoDocCon, b.users, b.UserRoles, b.Roles, b.TipoDocSolExp, TipoDocConExp = c })
                .Where(x => x.caracte.IdAspNetUser == id && x.caracte.Estado == true).Select(a => new CaracterizacionSolicitanteModel
                {
                    Id = a.caracte.Id,
                    IdExpediente = a.caracte.IdExpediente,
                    NumeroExpediente = a.baldios.NumeroExpediente,
                    IdDepto = a.depto.ID_CT_DEPTO,
                    NombreDepto = a.depto.NOMBRE,
                    IdMunicipio = a.munic.IdCtMuncipio,
                    NombreMunicipio = a.munic.Nombre,


                    NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                    DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),
                    TipoDocSolicitanteExpediente = a.TipoDocSolExp.NOMBRE,
                    IdTipoDocSolicitanteExpediente = a.TipoDocSolExp.ID_CT_TIPO_IDENTIFICACION,

                    NombreConyugeExpediente = a.baldios.NombreConyuge,
                    DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),
                    TipoDocConyugeExpediente = a.TipoDocConExp.NOMBRE,
                    IdTipoDocConyugeExpediente = a.TipoDocConExp.ID_CT_TIPO_IDENTIFICACION,


                    DocVisibleSol = a.caracte.DocVisibleSol,
                    CedulaExpSol = a.caracte.CedulaExpSol,
                    NombreSolicitante = a.caracte.NombreSolicitante,
                    TipoDocumento = a.caracte.TipoDocumento,
                    NombreTipoDocumento = a.TipoDocSol.NOMBRE,
                    NumeroIdentificacion = a.caracte.NumeroIdentificacion,
                    FechaExpedicionSolicitante = a.caracte.FechaExpedicionSolicitante,

                    DocVisibleCon = a.caracte.DocVisibleCon,
                    CedulaExpCon = a.caracte.CedulaExpCon,
                    NombreConyuge = a.caracte.NombreConyuge,
                    TipoDocumentoConyuge = a.caracte.TipoDocumentoConyuge,
                    NombreTipoDocumentoConyuge = a.TipoDocCon.NOMBRE,
                    NumeroIdentificacionConyuge = a.caracte.NumeroIdentificacionConyuge,
                    FechaExpedicionConyuge = a.caracte.FechaExpedicionConyuge,


                    VFechaSolicitante = a.caracte.VFechaSolicitante,
                    VArchivoSolicitante = a.caracte.VArchivoSolicitante,
                    VVivoSolicitante = a.caracte.VVivoSolicitante,

                    VFechaConyuge = a.caracte.VFechaConyuge,
                    VArchivoConyuge = a.caracte.VArchivoConyuge,
                    VVivoConyuge = a.caracte.VVivoConyuge,


                    PFechaSolicitante = a.caracte.PFechaSolicitante,
                    PArchivoSolicitante = a.caracte.PArchivoSolicitante,
                    PInhabilidadSolicitante = a.caracte.PInhabilidadSolicitante,

                    PFechaConyuge = a.caracte.PFechaConyuge,
                    PArchivoConyuge = a.caracte.PArchivoConyuge,
                    PInhabilidadConyuge = a.caracte.PInhabilidadConyuge,


                    CFechaSolicitante = a.caracte.CFechaSolicitante,
                    CArchivoSolicitante = a.caracte.CArchivoSolicitante,
                    CInhabilidadSolicitante = a.caracte.CInhabilidadSolicitante,

                    CFechaConyuge = a.caracte.CFechaConyuge,
                    CArchivoConyuge = a.caracte.CArchivoConyuge,
                    CInhabilidadConyuge = a.caracte.CInhabilidadConyuge,


                    AFechaSolicitante = a.caracte.AFechaSolicitante,
                    AArchivoSolicitante = a.caracte.AArchivoSolicitante,
                    AInhabilidadSolicitante = a.caracte.AInhabilidadSolicitante,

                    AFechaConyuge = a.caracte.AFechaConyuge,
                    AArchivoConyuge = a.caracte.AArchivoConyuge,
                    AInhabilidadConyuge = a.caracte.AInhabilidadConyuge,

                    Gestion = a.caracte.Gestion,
                    IdAspNetUser =a.caracte.FechaModificacion.ToString(),
                    NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                    RolUser = a.Roles.Name,
                    Estado = a.caracte.Estado,

                }).ToList();

            return lista;
        }

        public CaracterizacionSolicitanteModel Actualizar(CaracterizacionSolicitanteModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var Entity = Ctx.CaracterizacionSolicitante.Where(s => s.Id == a.Id).FirstOrDefault();
                if (Entity != null)
                {
                    if (a.Gestion == 1)
                    {
                        if (a.NombreSolicitante != "N_A") { Entity.NombreSolicitante = a.NombreSolicitante; }

                        if (a.TipoDocumento != 0) { Entity.TipoDocumento = a.TipoDocumento; }

                        if (a.NumeroIdentificacion != 0) { Entity.NumeroIdentificacion = a.NumeroIdentificacion; }

                        if (a.NombreConyuge != "N_A") { Entity.NombreConyuge = a.NombreConyuge; }

                        if (a.TipoDocumentoConyuge != 0) { Entity.TipoDocumentoConyuge = a.TipoDocumentoConyuge; }

                        if (a.NumeroIdentificacionConyuge != 0) { Entity.NumeroIdentificacionConyuge = a.NumeroIdentificacionConyuge; }

                        string DateSol = a.FechaExpedicionSolicitante.ToString();
                        string DateCon = a.FechaExpedicionConyuge.ToString();

                        if (DateSol != "1/1/1900 00:00:00") { Entity.FechaExpedicionSolicitante = a.FechaExpedicionSolicitante; }

                        if (DateCon != "1/1/1900 00:00:00") { Entity.FechaExpedicionConyuge = a.FechaExpedicionConyuge; }

                        Entity.FModificacionExp = DateTime.Now;

                        Entity.DocVisibleSol = a.DocVisibleSol;
                        Entity.CedulaExpSol = a.CedulaExpSol;
                        Entity.DocVisibleCon = a.DocVisibleCon;
                        Entity.CedulaExpCon = a.CedulaExpCon;

                    } 
                    else if (a.Gestion == 2) {

                        Entity.VFechaSolicitante = DateTime.Now;
                        if (a.VArchivoSolicitante != "N_A") { Entity.VArchivoSolicitante = a.VArchivoSolicitante; }
                        Entity.VVivoSolicitante = a.VVivoSolicitante;

                        Entity.VFechaConyuge = a.VFechaConyuge;
                        if (a.VArchivoConyuge != "N_A") { Entity.VArchivoConyuge = a.VArchivoConyuge; }
                        Entity.VVivoConyuge = a.VVivoConyuge;


                    } 
                    else if (a.Gestion == 3) {

                        Entity.PFechaSolicitante = DateTime.Now;
                        if (a.PArchivoSolicitante != "N_A")  { Entity.PArchivoSolicitante = a.PArchivoSolicitante; }
                        Entity.PInhabilidadSolicitante = a.PInhabilidadSolicitante;

                        Entity.PFechaConyuge = DateTime.Now;
                        if (a.PArchivoConyuge != "N_A") {Entity.PArchivoConyuge = a.PArchivoConyuge;}
                        Entity.PInhabilidadConyuge = a.PInhabilidadConyuge;

                    } 
                    else if (a.Gestion == 4) {
                        
                        Entity.CFechaSolicitante = DateTime.Now;
                        if (a.CArchivoSolicitante != "N_A"){Entity.CArchivoSolicitante = a.CArchivoSolicitante;}
                        Entity.CInhabilidadSolicitante = a.CInhabilidadSolicitante;
                        
                        Entity.CFechaConyuge = DateTime.Now;
                        if (a.CArchivoConyuge != "N_A"){Entity.CArchivoConyuge = a.CArchivoConyuge;}
                        Entity.CInhabilidadConyuge = a.CInhabilidadConyuge;

                    }
                    else if (a.Gestion == 5) {
                        Entity.AFechaSolicitante = DateTime.Now;
                        if (a.AArchivoSolicitante != "N_A"){Entity.AArchivoSolicitante = a.AArchivoSolicitante;}
                        Entity.AInhabilidadSolicitante = a.AInhabilidadSolicitante;

                        Entity.AFechaConyuge = a.AFechaConyuge;
                        if (a.AArchivoConyuge != "N_A") { Entity.AArchivoConyuge = a.AArchivoConyuge; }
                        Entity.AInhabilidadConyuge = a.AInhabilidadConyuge;
                    }

                    Entity.Gestion = 1;
                    Entity.IdAspNetUser = a.IdAspNetUser;
                    Entity.Estado = true;
                    Entity.FechaModificacion = DateTime.Now;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionSolicitante.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                        ResCtx.Estado = false;
                        ResCtx.FechaModificacion = DateTime.Now;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}