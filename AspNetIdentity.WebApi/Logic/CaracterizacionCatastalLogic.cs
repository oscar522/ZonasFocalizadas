using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CaracterizacionCatastalLogic
    {
        CaracterizacionCatastral ModCtx = new CaracterizacionCatastral();

        public CaracterizacionCatastralModel Crear(CaracterizacionCatastralModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CaracterizacionCatastral Nuevo = new CaracterizacionCatastral
                {
                    EXPEDIENTE = a.EXPEDIENTE,

                    DEPARTAMEN = a.DEPARTAMEN,

                    MUNICIPIO = a.MUNICIPIO,

                    VeredaExpe = a.VeredaExpe,

                    NombrePred = a.NombrePred,

                    Tipo_Ubica = a.Tipo_Ubica,

                    Restriccio = a.Restriccio,

                    TipoRestri = a.TipoRestri,

                    Observacio = a.Observacio,

                    PresuntaPr = a.PresuntaPr,

                    Observac_1 = a.Observac_1,

                    NumeroPlan = a.NumeroPlan,

                    FechaPlano = a.FechaPlano,

                    DATUMplano = a.DATUMplano,

                    Correponde = a.Correponde,

                    NombreTopo = a.NombreTopo,

                    CumpleAcue = a.CumpleAcue,

                    HojaPDFPla = a.HojaPDFPla,

                    AreaTotalT = a.AreaTotalT,

                    AreaRestri = a.AreaRestri,

                    AreaUtilTe = a.AreaUtilTe,

                    Restricc_1 = a.Restricc_1,

                    CualResPla = a.CualResPla,

                    ExisteRTDL = a.ExisteRTDL,

                    Requerimie = a.Requerimie,

                    Requerim_1 = a.Requerim_1,

                    Requerim_2 = a.Requerim_2,

                    Requerim_3 = a.Requerim_3,

                    Requerim_4 = a.Requerim_4,

                    Requerim_5 = a.Requerim_5,

                    Requerim_6 = a.Requerim_6,

                    FechaEdici = a.FechaEdici,

                    UsuarioEdi = a.UsuarioEdi,

                    ExistePlan = a.ExistePlan,

                    FISO = a.FISO,

                    Inspeccion = a.Inspeccion,

                    nPlanoIO = a.nPlanoIO,

                    Colindante = a.Colindante,

                    ResConcept = a.ResConcept,

                    ConceptoAm = a.ConceptoAm,

                    Recomienda = a.Recomienda,

                    TieneRTP = a.TieneRTP,

                    FechaRTP = a.FechaRTP,

                    PlanoAprob = a.PlanoAprob,

                    RTDL = a.RTDL,

                    AreaDescon = a.AreaDescon,

                    ExisteInco = a.ExisteInco,

                    FuenteRTDL = a.FuenteRTDL,

                    FechaCAR = a.FechaCAR,

                    CARConsult = a.CARConsult,

                    TieneRespu = a.TieneRespu,

                    RespuestaC = a.RespuestaC,

                    FechaURT = a.FechaURT,

                    DireccionC = a.DireccionC,

                    TieneRes_1 = a.TieneRes_1,

                    RespuestaU = a.RespuestaU,

                    FechaINVIA = a.FechaINVIA,

                    TieneRes_2 = a.TieneRes_2,

                    RespuestaI = a.RespuestaI,

                    FechaANH = a.FechaANH,

                    TieneRes_3 = a.TieneRes_3,

                    RespuestaA = a.RespuestaA,

                    FechaANM = a.FechaANM,

                    TieneRes_4 = a.TieneRes_4,

                    Respuest_1 = a.Respuest_1,

                    Requerim_7 = a.Requerim_7,

                    FechaANI = a.FechaANI,

                    TieneRes_5 = a.TieneRes_5,

                    Respuest_2 = a.Respuest_2,

                    FechaAE = a.FechaAE,

                    TieneRes_6 = a.TieneRes_6,

                    Respuest_3 = a.Respuest_3,

                    FechaZRC = a.FechaZRC,

                    TieneRes_7 = a.TieneRes_7,

                    RespuestaZ = a.RespuestaZ,

                    Esta_Georr = a.Esta_Georr,

                    CualIncons = a.CualIncons,

                    CumpleGeom = a.CumpleGeom,

                    ObserNoCum = a.ObserNoCum,

                    CoorDigVsC = a.CoorDigVsC,

                    ExacPosici = a.ExacPosici,

                    RazonPlano = a.RazonPlano,

                    TraslapeEx = a.TraslapeEx,

                    TranslapeC = a.TranslapeC,

                    Fuente_Dat = a.Fuente_Dat,

                    Desplazado = a.Desplazado,

                    Causa_Desp = a.Causa_Desp,

                    Causa_CDgV = a.Causa_CDgV,

                    FechaInsercion = a.FechaInsercion.Value,

                    FechaModificacion = DateTime.Now,

                    IdAspNetUser = a.IdAspNetUser,

                    IdAspNetUserModifica = a.IdAspNetUserModifica,

                    Id = a.Id,

                    IdExpediente = a.IdExpediente,

                    Gestion = null,
                    Estado = 1


                };

                Ctx.CaracterizacionCatastral.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionCatastral
                .Join(Ctx.BaldiosPersonaNatural, b => b.IdExpediente, c => c.id, (b, c) => new { caracte = b, baldios = c })
                .Join(Ctx.CtDepto, b => b.baldios.IdDepto, c => c.ID_CT_DEPTO, (b, c) => new { b.caracte, b.baldios, depto = c })
                .Join(Ctx.CtCiudad, b => b.baldios.IdCiudad, c => c.IdCtMuncipio, (b, c) => new { b.caracte, b.baldios, b.depto, munic = c })
                .Where(x => x.munic.IdCtDepto == x.baldios.IdDepto)
                .Where(x => x.caracte.Estado == 1).Select(a => new CaracterizacionSolicitanteModel
                {
                  //  Id = Convert.ToInt32( a.caracte.Id),
                    IdExpediente = a.caracte.IdExpediente,
                    NumeroExpediente = a.baldios.NumeroExpediente,
                    IdDepto = a.depto.ID_CT_DEPTO,
                    NombreDepto = a.depto.NOMBRE,
                    IdMunicipio = a.munic.IdCtMuncipio,
                    NombreMunicipio = a.munic.Nombre,

                    NombreSolicitanteExpediente = a.baldios.NombreBeneficiario,
                    DocSolicitanteExpediente = a.baldios.Identificacion.ToString(),

                    NombreConyugeExpediente = a.baldios.NombreConyuge,
                    DocConyugeExpediente = a.baldios.IdentificacionConyuge.ToString(),

                    Gestion = a.caracte.Gestion,
                    //IdAspNetUser = a.caracte.IdAspNetUser,
                    IdAspNetUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x => x.Id_Hash).FirstOrDefault(),
                    ///NombretUser = a.users.Name + " " + a.users.FirstName + " " + a.users.LastName,
                    NombretUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser).Select(x => x.Name + " " + x.FirstName + " " + x.LastName).FirstOrDefault(),
                    RolUser = Ctx.Users.Where(c => c.Id_Hash == a.caracte.IdAspNetUser)
                                .Join(Ctx.AspNetUserRoles, b => b.Id_Hash, c => c.UserId, (b, c) => new { UserRoles = c })
                                .Join(Ctx.AspNetRoles, b => b.UserRoles.RoleId, c => c.Id, (b, c) => new { c }).Select(f => f.c.Name).FirstOrDefault(),
                    Estado = true,

                }).ToList();



            return lista.ToList();
        }

        public List<BaldiosPersonaNaturalModel> Consulta(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var Resumen = Ctx.PlResumenTipificacionAll(73, 73, "da825085-c7c2-48b8-ab8f-11637623e1bd")
                            .Select(c => c).ToList();
           // var tipo_ = Ctx.ResumenCaracterizacionCatastral(id).Select(c => c).ToList(); ; //NombrePredio
            var listaBaldios = Ctx.BaldiosPersonaNatural
                 .Join(Ctx.CaracterizacionCatastral, b => b.id, c => c.IdExpediente, (b, c) => new { b, c })
                 .Where(w => w.c.IdAspNetUser == id && w.c.Estado == 1).ToList();
            #region Sql
            var lista = listaBaldios
                //.Where(w => w.IdAspNetUser == IdP)
                .Join(Ctx.CtDepto, b => b.b.IdDepto, c => c.ID_CT_DEPTO, (b, c) =>
                 new { b, NombrDepto = c.NOMBRE })
                .Join(Ctx.CtCiudad, d => d.b.b.IdCiudad, c => c.IdCtMuncipio, (d, e) =>
                 new { d.b, d.NombrDepto, NombreMunicipio = e.Nombre, MunicipioIdDepto = e.IdCtDepto })
                .Join(Ctx.CtTipoIdentificacion, f => f.b.b.IdTipoIdentificacion, g => g.ID_CT_TIPO_IDENTIFICACION, (f, g) =>
                 new { f.b, f.NombrDepto, f.NombreMunicipio, NombreTipoIdentificacion = g.NOMBRE, f.MunicipioIdDepto })
                .Join(Ctx.CtGenero, h => h.b.b.IdGenero, i => i.ID_GENERO, (h, i) =>
                 new { h.b, h.NombrDepto, h.NombreMunicipio, h.NombreTipoIdentificacion, h.MunicipioIdDepto, NombreGenero = i.NOMBRE })
                .Join(Ctx.CtTipoIdentificacion, j => j.b.b.IdTipoIdentificacionConyuge, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new { j.b, j.NombrDepto, j.NombreMunicipio, j.NombreTipoIdentificacion, j.MunicipioIdDepto, j.NombreGenero, NombreTipoIdentificacionConyuge = k.NOMBRE })
                 .Where(w => w.MunicipioIdDepto == w.b.b.IdDepto)
                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.b.c.Id,
                    NumeroExpediente = c.b.b.NumeroExpediente,
                    IdDepto = c.b.b.IdDepto,
                    IdCiudad = c.b.c.Gestion,
                    Vereda = c.b.b.Vereda,
                    NombrePredio = c.b.c.NombrePred,
                    NombreBeneficiario = c.b.b.NombreBeneficiario,
                    //NombreIdGenero = tipo.Where(x => x.IdExpediente == c.b.b.id).Select(u => u.SubTipo).FirstOrDefault(),
                    IdTipoIdentificacion = c.b.b.IdTipoIdentificacion,
                    Identificacion = c.b.b.Identificacion,
                    IdGenero = c.b.b.IdGenero,
                    NombreArchivo = Resumen.Where(x => x.IdExpediente == c.b.b.id).Select(f => f.Grupo).FirstOrDefault(),
                    IdTipoIdentificacionConyuge = c.b.b.IdTipoIdentificacionConyuge,
                    IdentificacionConyuge = c.b.b.IdentificacionConyuge,
                    NombreConyuge = c.b.b.NombreConyuge,
                    EstadoInicialMigracion = c.b.b.EstadoInicialMigracion,
                    IdAspNetUser = c.b.c.FechaModificacion.ToString(),
                    NombreIdAspNetUser = c.b.c.Id.ToString(),
                    EstadoCaracterizacion = c.b.b.EstadoCaracterizacion,
                    RutaArchivoOriginal = c.b.b.RutaArchivoOriginal,
                    NombreIdDepto = c.NombrDepto,
                    NombreIdCiudad = c.NombreMunicipio,
                    NombreIdTipoIdentificacion = c.NombreTipoIdentificacion,
                    NombreIdTipoIdentificacionConyuge = c.NombreTipoIdentificacionConyuge,
                }).OrderByDescending(d => d.EstadoCaracterizacion);

            #endregion
            return lista.ToList();
        }

        public CaracterizacionCatastralModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.CaracterizacionCatastral.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new {b.b, b.c , ll, b.Name })
                .FirstOrDefault();

            CaracterizacionCatastralModel CaracterizacionCatastralModel_ = new CaracterizacionCatastralModel();

            CaracterizacionCatastralModel_.EXPEDIENTE = a.b.EXPEDIENTE;

            CaracterizacionCatastralModel_.DEPARTAMEN = a.b.DEPARTAMEN;

            CaracterizacionCatastralModel_.MUNICIPIO = a.b.MUNICIPIO;

            CaracterizacionCatastralModel_.VeredaExpe = a.b.VeredaExpe;

            CaracterizacionCatastralModel_.NombrePred = a.b.NombrePred;

            CaracterizacionCatastralModel_.Tipo_Ubica = a.b.Tipo_Ubica;

            CaracterizacionCatastralModel_.Restriccio = a.b.Restriccio;

            CaracterizacionCatastralModel_.TipoRestri = a.b.TipoRestri;

            CaracterizacionCatastralModel_.Observacio = a.b.Observacio;

            CaracterizacionCatastralModel_.PresuntaPr = a.b.PresuntaPr;

            CaracterizacionCatastralModel_.Observac_1 = a.b.Observac_1;

            CaracterizacionCatastralModel_.NumeroPlan = a.b.NumeroPlan;

            CaracterizacionCatastralModel_.FechaPlano = a.b.FechaPlano;

            CaracterizacionCatastralModel_.DATUMplano = a.b.DATUMplano;

            CaracterizacionCatastralModel_.Correponde = a.b.Correponde;

            CaracterizacionCatastralModel_.NombreTopo = a.b.NombreTopo;

            CaracterizacionCatastralModel_.CumpleAcue = a.b.CumpleAcue;

            CaracterizacionCatastralModel_.HojaPDFPla = a.b.HojaPDFPla;

            CaracterizacionCatastralModel_.AreaTotalT = a.b.AreaTotalT;

            CaracterizacionCatastralModel_.AreaRestri = a.b.AreaRestri;

            CaracterizacionCatastralModel_.AreaUtilTe = a.b.AreaUtilTe;

            CaracterizacionCatastralModel_.Restricc_1 = a.b.Restricc_1;

            CaracterizacionCatastralModel_.CualResPla = a.b.CualResPla;

            CaracterizacionCatastralModel_.ExisteRTDL = a.b.ExisteRTDL;

            CaracterizacionCatastralModel_.Requerimie = a.b.Requerimie;

            CaracterizacionCatastralModel_.Requerim_1 = a.b.Requerim_1;

            CaracterizacionCatastralModel_.Requerim_2 = a.b.Requerim_2;

            CaracterizacionCatastralModel_.Requerim_3 = a.b.Requerim_3;

            CaracterizacionCatastralModel_.Requerim_4 = a.b.Requerim_4;

            CaracterizacionCatastralModel_.Requerim_5 = a.b.Requerim_5;

            CaracterizacionCatastralModel_.Requerim_6 = a.b.Requerim_6;

            CaracterizacionCatastralModel_.FechaEdici = a.b.FechaEdici;

            CaracterizacionCatastralModel_.UsuarioEdi = a.b.UsuarioEdi;

            CaracterizacionCatastralModel_.ExistePlan = a.b.ExistePlan;

            CaracterizacionCatastralModel_.FISO = a.b.FISO;

            CaracterizacionCatastralModel_.Inspeccion = a.b.Inspeccion;

            CaracterizacionCatastralModel_.nPlanoIO = a.b.nPlanoIO;

            CaracterizacionCatastralModel_.Colindante = a.b.Colindante;

            CaracterizacionCatastralModel_.ResConcept = a.b.ResConcept;

            CaracterizacionCatastralModel_.ConceptoAm = a.b.ConceptoAm;

            CaracterizacionCatastralModel_.Recomienda = a.b.Recomienda;

            CaracterizacionCatastralModel_.TieneRTP = a.b.TieneRTP;

            CaracterizacionCatastralModel_.FechaRTP = a.b.FechaRTP;

            CaracterizacionCatastralModel_.PlanoAprob = a.b.PlanoAprob;

            CaracterizacionCatastralModel_.RTDL = a.b.RTDL;

            CaracterizacionCatastralModel_.AreaDescon = a.b.AreaDescon;

            CaracterizacionCatastralModel_.ExisteInco = a.b.ExisteInco;

            CaracterizacionCatastralModel_.FuenteRTDL = a.b.FuenteRTDL;

            CaracterizacionCatastralModel_.FechaCAR = a.b.FechaCAR;

            CaracterizacionCatastralModel_.CARConsult = a.b.CARConsult;

            CaracterizacionCatastralModel_.TieneRespu = a.b.TieneRespu;

            CaracterizacionCatastralModel_.RespuestaC = a.b.RespuestaC;

            CaracterizacionCatastralModel_.FechaURT = a.b.FechaURT;

            CaracterizacionCatastralModel_.DireccionC = a.b.DireccionC;

            CaracterizacionCatastralModel_.TieneRes_1 = a.b.TieneRes_1;

            CaracterizacionCatastralModel_.RespuestaU = a.b.RespuestaU;

            CaracterizacionCatastralModel_.FechaINVIA = a.b.FechaINVIA;

            CaracterizacionCatastralModel_.TieneRes_2 = a.b.TieneRes_2;

            CaracterizacionCatastralModel_.RespuestaI = a.b.RespuestaI;

            CaracterizacionCatastralModel_.FechaANH = a.b.FechaANH;

            CaracterizacionCatastralModel_.TieneRes_3 = a.b.TieneRes_3;

            CaracterizacionCatastralModel_.RespuestaA = a.b.RespuestaA;

            CaracterizacionCatastralModel_.FechaANM = a.b.FechaANM;

            CaracterizacionCatastralModel_.TieneRes_4 = a.b.TieneRes_4;

            CaracterizacionCatastralModel_.Respuest_1 = a.b.Respuest_1;

            CaracterizacionCatastralModel_.Requerim_7 = a.b.Requerim_7;

            CaracterizacionCatastralModel_.FechaANI = a.b.FechaANI;

            CaracterizacionCatastralModel_.TieneRes_5 = a.b.TieneRes_5;

            CaracterizacionCatastralModel_.Respuest_2 = a.b.Respuest_2;

            CaracterizacionCatastralModel_.FechaAE = a.b.FechaAE;

            CaracterizacionCatastralModel_.TieneRes_6 = a.b.TieneRes_6;

            CaracterizacionCatastralModel_.Respuest_3 = a.b.Respuest_3;

            CaracterizacionCatastralModel_.FechaZRC = a.b.FechaZRC;

            CaracterizacionCatastralModel_.TieneRes_7 = a.b.TieneRes_7;

            CaracterizacionCatastralModel_.RespuestaZ = a.b.RespuestaZ;

            CaracterizacionCatastralModel_.Esta_Georr = a.b.Esta_Georr;

            CaracterizacionCatastralModel_.CualIncons = a.b.CualIncons;

            CaracterizacionCatastralModel_.CumpleGeom = a.b.CumpleGeom;

            CaracterizacionCatastralModel_.ObserNoCum = a.b.ObserNoCum;

            CaracterizacionCatastralModel_.CoorDigVsC = a.b.CoorDigVsC;

            CaracterizacionCatastralModel_.ExacPosici = a.b.ExacPosici;

            CaracterizacionCatastralModel_.RazonPlano = a.b.RazonPlano;

            CaracterizacionCatastralModel_.TraslapeEx = a.b.TraslapeEx;

            CaracterizacionCatastralModel_.TranslapeC = a.b.TranslapeC;

            CaracterizacionCatastralModel_.Fuente_Dat = a.b.Fuente_Dat;

            CaracterizacionCatastralModel_.Desplazado = a.b.Desplazado;

            CaracterizacionCatastralModel_.Causa_Desp = a.b.Causa_Desp;

            CaracterizacionCatastralModel_.Causa_CDgV = a.b.Causa_CDgV;

            CaracterizacionCatastralModel_.FechaInsercion = a.b.FechaInsercion;

            CaracterizacionCatastralModel_.FechaModificacion = a.b.FechaModificacion;

            CaracterizacionCatastralModel_.Gestion = a.b.Gestion;

            CaracterizacionCatastralModel_.IdAspNetUser = a.b.IdAspNetUser;

            CaracterizacionCatastralModel_.IdAspNetUserModifica = a.b.IdAspNetUserModifica;

            CaracterizacionCatastralModel_.Id = a.b.Id;

            CaracterizacionCatastralModel_.IdExpediente = a.b.IdExpediente;



            CaracterizacionCatastralModel_.Estado = true;
                CaracterizacionCatastralModel_.IdAspNetUser = a.b.IdAspNetUser;
                CaracterizacionCatastralModel_.rol = a.Name;
                CaracterizacionCatastralModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
                CaracterizacionCatastralModel_.FechaModificacion = a.b.FechaModificacion;
                CaracterizacionCatastralModel_.Gestion = a.b.Gestion;


            return CaracterizacionCatastralModel_;
        }

        public CaracterizacionCatastralModel Actualizar(CaracterizacionCatastralModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var CaracterizacionCatastralModel_ = Ctx.CaracterizacionCatastral.Where(s => s.Id == a.Id).FirstOrDefault();
                if (CaracterizacionCatastralModel_ != null)
                {
                    CaracterizacionCatastralModel_.EXPEDIENTE = a.EXPEDIENTE;

                    CaracterizacionCatastralModel_.DEPARTAMEN = a.DEPARTAMEN;

                    CaracterizacionCatastralModel_.MUNICIPIO = a.MUNICIPIO;

                    CaracterizacionCatastralModel_.VeredaExpe = a.VeredaExpe;

                    CaracterizacionCatastralModel_.NombrePred = a.NombrePred;

                    CaracterizacionCatastralModel_.Tipo_Ubica = a.Tipo_Ubica;

                    CaracterizacionCatastralModel_.Restriccio = a.Restriccio;

                    CaracterizacionCatastralModel_.TipoRestri = a.TipoRestri;

                    CaracterizacionCatastralModel_.Observacio = a.Observacio;

                    CaracterizacionCatastralModel_.PresuntaPr = a.PresuntaPr;

                    CaracterizacionCatastralModel_.Observac_1 = a.Observac_1;

                    CaracterizacionCatastralModel_.NumeroPlan = a.NumeroPlan;

                    CaracterizacionCatastralModel_.FechaPlano = a.FechaPlano;

                    CaracterizacionCatastralModel_.DATUMplano = a.DATUMplano;

                    CaracterizacionCatastralModel_.Correponde = a.Correponde;

                    CaracterizacionCatastralModel_.NombreTopo = a.NombreTopo;

                    CaracterizacionCatastralModel_.CumpleAcue = a.CumpleAcue;

                    CaracterizacionCatastralModel_.HojaPDFPla = a.HojaPDFPla;

                    CaracterizacionCatastralModel_.AreaTotalT = a.AreaTotalT;

                    CaracterizacionCatastralModel_.AreaRestri = a.AreaRestri;

                    CaracterizacionCatastralModel_.AreaUtilTe = a.AreaUtilTe;

                    CaracterizacionCatastralModel_.Restricc_1 = a.Restricc_1;

                    CaracterizacionCatastralModel_.CualResPla = a.CualResPla;

                    CaracterizacionCatastralModel_.ExisteRTDL = a.ExisteRTDL;

                    CaracterizacionCatastralModel_.Requerimie = a.Requerimie;

                    CaracterizacionCatastralModel_.Requerim_1 = a.Requerim_1;

                    CaracterizacionCatastralModel_.Requerim_2 = a.Requerim_2;

                    CaracterizacionCatastralModel_.Requerim_3 = a.Requerim_3;

                    CaracterizacionCatastralModel_.Requerim_4 = a.Requerim_4;

                    CaracterizacionCatastralModel_.Requerim_5 = a.Requerim_5;

                    CaracterizacionCatastralModel_.Requerim_6 = a.Requerim_6;

                    CaracterizacionCatastralModel_.FechaEdici = a.FechaEdici;

                    CaracterizacionCatastralModel_.UsuarioEdi = a.UsuarioEdi;

                    CaracterizacionCatastralModel_.ExistePlan = a.ExistePlan;

                    CaracterizacionCatastralModel_.FISO = a.FISO;

                    CaracterizacionCatastralModel_.Inspeccion = a.Inspeccion;

                    CaracterizacionCatastralModel_.nPlanoIO = a.nPlanoIO;

                    CaracterizacionCatastralModel_.Colindante = a.Colindante;

                    CaracterizacionCatastralModel_.ResConcept = a.ResConcept;

                    CaracterizacionCatastralModel_.ConceptoAm = a.ConceptoAm;

                    CaracterizacionCatastralModel_.Recomienda = a.Recomienda;

                    CaracterizacionCatastralModel_.TieneRTP = a.TieneRTP;

                    CaracterizacionCatastralModel_.FechaRTP = a.FechaRTP;

                    CaracterizacionCatastralModel_.PlanoAprob = a.PlanoAprob;

                    CaracterizacionCatastralModel_.RTDL = a.RTDL;

                    CaracterizacionCatastralModel_.AreaDescon = a.AreaDescon;

                    CaracterizacionCatastralModel_.ExisteInco = a.ExisteInco;

                    CaracterizacionCatastralModel_.FuenteRTDL = a.FuenteRTDL;

                    CaracterizacionCatastralModel_.FechaCAR = a.FechaCAR;

                    CaracterizacionCatastralModel_.CARConsult = a.CARConsult;

                    CaracterizacionCatastralModel_.TieneRespu = a.TieneRespu;

                    CaracterizacionCatastralModel_.RespuestaC = a.RespuestaC;

                    CaracterizacionCatastralModel_.FechaURT = a.FechaURT;

                    CaracterizacionCatastralModel_.DireccionC = a.DireccionC;

                    CaracterizacionCatastralModel_.TieneRes_1 = a.TieneRes_1;

                    CaracterizacionCatastralModel_.RespuestaU = a.RespuestaU;

                    CaracterizacionCatastralModel_.FechaINVIA = a.FechaINVIA;

                    CaracterizacionCatastralModel_.TieneRes_2 = a.TieneRes_2;

                    CaracterizacionCatastralModel_.RespuestaI = a.RespuestaI;

                    CaracterizacionCatastralModel_.FechaANH = a.FechaANH;

                    CaracterizacionCatastralModel_.TieneRes_3 = a.TieneRes_3;

                    CaracterizacionCatastralModel_.RespuestaA = a.RespuestaA;

                    CaracterizacionCatastralModel_.FechaANM = a.FechaANM;

                    CaracterizacionCatastralModel_.TieneRes_4 = a.TieneRes_4;

                    CaracterizacionCatastralModel_.Respuest_1 = a.Respuest_1;

                    CaracterizacionCatastralModel_.Requerim_7 = a.Requerim_7;

                    CaracterizacionCatastralModel_.FechaANI = a.FechaANI;

                    CaracterizacionCatastralModel_.TieneRes_5 = a.TieneRes_5;

                    CaracterizacionCatastralModel_.Respuest_2 = a.Respuest_2;

                    CaracterizacionCatastralModel_.FechaAE = a.FechaAE;

                    CaracterizacionCatastralModel_.TieneRes_6 = a.TieneRes_6;

                    CaracterizacionCatastralModel_.Respuest_3 = a.Respuest_3;

                    CaracterizacionCatastralModel_.FechaZRC = a.FechaZRC;

                    CaracterizacionCatastralModel_.TieneRes_7 = a.TieneRes_7;

                    CaracterizacionCatastralModel_.RespuestaZ = a.RespuestaZ;

                    CaracterizacionCatastralModel_.Esta_Georr = a.Esta_Georr;

                    CaracterizacionCatastralModel_.CualIncons = a.CualIncons;

                    CaracterizacionCatastralModel_.CumpleGeom = a.CumpleGeom;

                    CaracterizacionCatastralModel_.ObserNoCum = a.ObserNoCum;

                    CaracterizacionCatastralModel_.CoorDigVsC = a.CoorDigVsC;

                    CaracterizacionCatastralModel_.ExacPosici = a.ExacPosici;

                    CaracterizacionCatastralModel_.RazonPlano = a.RazonPlano;

                    CaracterizacionCatastralModel_.TraslapeEx = a.TraslapeEx;

                    CaracterizacionCatastralModel_.TranslapeC = a.TranslapeC;

                    CaracterizacionCatastralModel_.Fuente_Dat = a.Fuente_Dat;

                    CaracterizacionCatastralModel_.Desplazado = a.Desplazado;

                    CaracterizacionCatastralModel_.Causa_Desp = a.Causa_Desp;

                    CaracterizacionCatastralModel_.Causa_CDgV = a.Causa_CDgV;

                    CaracterizacionCatastralModel_.FechaInsercion = a.FechaInsercion.Value;


                    CaracterizacionCatastralModel_.IdAspNetUser = a.IdAspNetUser;

                    CaracterizacionCatastralModel_.IdAspNetUserModifica = a.IdAspNetUserModifica;

                    CaracterizacionCatastralModel_.Id = a.Id;

                    CaracterizacionCatastralModel_.IdExpediente = a.IdExpediente;


                    CaracterizacionCatastralModel_.FechaModificacion = DateTime.Now;
                    CaracterizacionCatastralModel_.Gestion = 1;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionCatastral.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        public List<CaracterizacionCatastralCatalogosModel> ConsultarCatalogo(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionCatastralCatalogos.Where(x =>  x.Tipo == id)
                .Select(a => new CaracterizacionCatastralCatalogosModel
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