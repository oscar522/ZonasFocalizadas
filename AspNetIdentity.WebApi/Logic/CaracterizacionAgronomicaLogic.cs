using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class CaracterizacionAgronomicaLogic
    {
        CaracterizacionAgronomica ModCtx = new CaracterizacionAgronomica();


        public CaracterizacionAgronomicaModel Crear(CaracterizacionAgronomicaModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                CaracterizacionAgronomica Nuevo = new CaracterizacionAgronomica
                {

                    FechaInsercion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Gestion = a.Gestion,
                    IdAspNetUser = a.IdAspNetUser,
                    IdAspNetUserModifica = a.IdAspNetUserModifica,
                    IdExpediente = a.IdExpediente,
                    Estado = a.Estado,
                    Validacion1 = a.Validacion1,
                    Validacion2 = a.Validacion2,
                    Validacion3 = a.Validacion3,
                    Validacion4 = a.Validacion4,
                    Validacion5 = a.Validacion5,
                    Validacion6 = a.Validacion6,
                    Validacion7 = a.Validacion7,
                    Validacion8 = a.Validacion8,
                    Validacion9 = a.Validacion9,
                    Validacion10 = a.Validacion10,
                    Validacion11 = a.Validacion11,
                    Validacion12 = a.Validacion12,
                    Validacion13 = a.Validacion13,
                    Validacion14 = a.Validacion14,
                    Validacion15 = a.Validacion15,
                    Validacion16 = a.Validacion16,
                    Validacion17 = a.Validacion17,
                    Validacion18 = a.Validacion18,
                    Validacion19 = a.Validacion19,
                    Validacion20 = a.Validacion20,
                    Validacion21 = a.Validacion21,
                    Validacion22 = a.Validacion22,
                    Validacion23 = a.Validacion23,
                    Validacion24 = a.Validacion24,
                    Validacion25 = a.Validacion25,
                    Validacion26 = a.Validacion26,
                    Validacion27 = a.Validacion27,
                    Validacion28 = a.Validacion28,
                    Validacion29 = a.Validacion29,
                    Validacion30 = a.Validacion30,
                    Validacion31 = a.Validacion31,
                    Validacion32 = a.Validacion32,
                    Validacion33 = a.Validacion33,
                    Validacion34 = a.Validacion34,
                    Validacion35 = a.Validacion35,
                    Validacion36 = a.Validacion36,
                    Validacion37 = a.Validacion37,
                    Validacion38 = a.Validacion38,
                    Validacion39 = a.Validacion39,
                    Validacion40 = a.Validacion40,
                    Validacion41 = a.Validacion41,
                    Validacion42 = a.Validacion42,
                    Validacion43 = a.Validacion43,
                    Validacion44 = a.Validacion44,
                    Validacion45 = a.Validacion45,
                    Validacion46 = a.Validacion46,
                    Validacion47 = a.Validacion47,
                    Validacion48 = a.Validacion48,
                    Validacion49 = a.Validacion49,
                    Validacion50 = a.Validacion50,
                    Validacion51 = a.Validacion51,
                    Validacion52 = a.Validacion52,
                    Validacion53 = a.Validacion53,
                    Validacion54 = a.Validacion54,
                    Validacion55 = a.Validacion55,
                    Validacion56 = a.Validacion56,
                    Validacion57 = a.Validacion57,
                    Validacion58 = a.Validacion58,
                    Validacion59 = a.Validacion59,
                    Validacion60 = a.Validacion60,
                    Validacion61 = a.Validacion61,
                    Validacion62 = a.Validacion62,
                    Validacion63 = a.Validacion63,
                };

                Ctx.CaracterizacionAgronomica.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<CaracterizacionSolicitanteModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionAgronomica
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

            // var tipo_ = Ctx.ResumenCaracterizacionAgronomica(id).Select(c => c).ToList(); ; //NombrePredio
            var listaBaldios = Ctx.CaracterizacionAgronomica
                 .Where(w => w.IdAspNetUser == id && w.Estado == 1).ToList();
            #region Sql
            var lista = listaBaldios

                .Select(c => new BaldiosPersonaNaturalModel
                {
                    id = c.Id,
                    NumeroExpediente =c.Validacion61, // fiso
                    IdDepto = Convert.ToInt32(c.Validacion2),
                    IdCiudad = Convert.ToInt32(c.Validacion3),
                    NombreIdDepto = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO.ToString() ==c.Validacion2).Select(y => y.NOMBRE).FirstOrDefault(),
                    NombreIdCiudad = Ctx.CtCiudad.Where(x => x.IdCtMuncipio.ToString() == c.Validacion3 && x.IdCtDepto.ToString() == c.Validacion2  ).Select(y => y.Nombre).FirstOrDefault(),
                    Vereda = c.Validacion4,
                    //NombrePredio = c.b.c.NombrePred,
                    NombreBeneficiario = c.Validacion7,
                    //NombreIdGenero = tipo.Where(x => x.IdExpediente == c.b.b.id).Select(u => u.SubTipo).FirstOrDefault(),
                    Identificacion = c.Validacion6,
                    NombreConyuge = c.Validacion9,
                    IdentificacionConyuge = c.Validacion8,

                    IdAspNetUser = c.FechaInsercion.ToString(),
                    NombreIdAspNetUser = c.FechaModificacion.ToString(),
                    // EstadoCaracterizacion = c.b.b.EstadoCaracterizacion,
                    //  RutaArchivoOriginal = c.b.b.RutaArchivoOriginal,
                    
                }).OrderByDescending(d => d.EstadoCaracterizacion).ToList();

            #endregion
            return lista;
        }

        public CaracterizacionAgronomicaModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.CaracterizacionAgronomica.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .Join(Ctx.BaldiosPersonaNatural, b => b.b.IdExpediente, ll => ll.id, (b, ll) => new { b.b, b.c, ll, b.Name })
                .FirstOrDefault();

            CaracterizacionAgronomicaModel CaracterizacionAgronomicaModel_ = new CaracterizacionAgronomicaModel();


           
            CaracterizacionAgronomicaModel_.Validacion1 = a.b.Validacion1;
            CaracterizacionAgronomicaModel_.Validacion2 = a.b.Validacion2;
            CaracterizacionAgronomicaModel_.Validacion3 = a.b.Validacion3;
            CaracterizacionAgronomicaModel_.Validacion4 = a.b.Validacion4;
            CaracterizacionAgronomicaModel_.Validacion5 = a.b.Validacion5;
            CaracterizacionAgronomicaModel_.Validacion6 = a.b.Validacion6;
            CaracterizacionAgronomicaModel_.Validacion7 = a.b.Validacion7;
            CaracterizacionAgronomicaModel_.Validacion8 = a.b.Validacion8;
            CaracterizacionAgronomicaModel_.Validacion9 = a.b.Validacion9;
            CaracterizacionAgronomicaModel_.Validacion10 = a.b.Validacion10;
            CaracterizacionAgronomicaModel_.Validacion11 = a.b.Validacion11;
            CaracterizacionAgronomicaModel_.Validacion12 = a.b.Validacion12;
            CaracterizacionAgronomicaModel_.Validacion13 = a.b.Validacion13;
            CaracterizacionAgronomicaModel_.Validacion14 = a.b.Validacion14;
            CaracterizacionAgronomicaModel_.Validacion15 = a.b.Validacion15;
            CaracterizacionAgronomicaModel_.Validacion16 = a.b.Validacion16;
            CaracterizacionAgronomicaModel_.Validacion17 = a.b.Validacion17;
            CaracterizacionAgronomicaModel_.Validacion18 = a.b.Validacion18;
            CaracterizacionAgronomicaModel_.Validacion19 = a.b.Validacion19;
            CaracterizacionAgronomicaModel_.Validacion20 = a.b.Validacion20;
            CaracterizacionAgronomicaModel_.Validacion21 = a.b.Validacion21;
            CaracterizacionAgronomicaModel_.Validacion22 = a.b.Validacion22;
            CaracterizacionAgronomicaModel_.Validacion23 = a.b.Validacion23;
            CaracterizacionAgronomicaModel_.Validacion24 = a.b.Validacion24;
            CaracterizacionAgronomicaModel_.Validacion25 = a.b.Validacion25;
            CaracterizacionAgronomicaModel_.Validacion26 = a.b.Validacion26;
            CaracterizacionAgronomicaModel_.Validacion27 = a.b.Validacion27;
            CaracterizacionAgronomicaModel_.Validacion28 = a.b.Validacion28;
            CaracterizacionAgronomicaModel_.Validacion29 = a.b.Validacion29;
            CaracterizacionAgronomicaModel_.Validacion30 = a.b.Validacion30;
            CaracterizacionAgronomicaModel_.Validacion31 = a.b.Validacion31;
            CaracterizacionAgronomicaModel_.Validacion32 = a.b.Validacion32;
            CaracterizacionAgronomicaModel_.Validacion33 = a.b.Validacion33;
            CaracterizacionAgronomicaModel_.Validacion34 = a.b.Validacion34;
            CaracterizacionAgronomicaModel_.Validacion35 = a.b.Validacion35;
            CaracterizacionAgronomicaModel_.Validacion36 = a.b.Validacion36;
            CaracterizacionAgronomicaModel_.Validacion37 = a.b.Validacion37;
            CaracterizacionAgronomicaModel_.Validacion38 = a.b.Validacion38;
            CaracterizacionAgronomicaModel_.Validacion39 = a.b.Validacion39;
            CaracterizacionAgronomicaModel_.Validacion40 = a.b.Validacion40;
            CaracterizacionAgronomicaModel_.Validacion41 = a.b.Validacion41;
            CaracterizacionAgronomicaModel_.Validacion42 = a.b.Validacion42;
            CaracterizacionAgronomicaModel_.Validacion43 = a.b.Validacion43;
            CaracterizacionAgronomicaModel_.Validacion44 = a.b.Validacion44;
            CaracterizacionAgronomicaModel_.Validacion45 = a.b.Validacion45;
            CaracterizacionAgronomicaModel_.Validacion46 = a.b.Validacion46;
            CaracterizacionAgronomicaModel_.Validacion47 = a.b.Validacion47;
            CaracterizacionAgronomicaModel_.Validacion48 = a.b.Validacion48;
            CaracterizacionAgronomicaModel_.Validacion49 = a.b.Validacion49;
            CaracterizacionAgronomicaModel_.Validacion50 = a.b.Validacion50;
            CaracterizacionAgronomicaModel_.Validacion51 = a.b.Validacion51;
            CaracterizacionAgronomicaModel_.Validacion52 = a.b.Validacion52;
            CaracterizacionAgronomicaModel_.Validacion53 = a.b.Validacion53;
            CaracterizacionAgronomicaModel_.Validacion54 = a.b.Validacion54;
            CaracterizacionAgronomicaModel_.Validacion55 = a.b.Validacion55;
            CaracterizacionAgronomicaModel_.Validacion56 = a.b.Validacion56;
            CaracterizacionAgronomicaModel_.Validacion57 = a.b.Validacion57;
            CaracterizacionAgronomicaModel_.Validacion58 = a.b.Validacion58;
            CaracterizacionAgronomicaModel_.Validacion59 = a.b.Validacion59;
            CaracterizacionAgronomicaModel_.Validacion60 = a.b.Validacion60;
            CaracterizacionAgronomicaModel_.Validacion61 = a.b.Validacion61;
            CaracterizacionAgronomicaModel_.Validacion62 = a.b.Validacion62;
            CaracterizacionAgronomicaModel_.Validacion63 = a.b.Validacion63;


            CaracterizacionAgronomicaModel_.Estado = 1;
            CaracterizacionAgronomicaModel_.IdAspNetUser = a.b.IdAspNetUser;
            CaracterizacionAgronomicaModel_.rol = a.Name;
            CaracterizacionAgronomicaModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
            CaracterizacionAgronomicaModel_.FechaModificacion = a.b.FechaModificacion.Value;

            CaracterizacionAgronomicaModel_.Id = a.b.Id;
            CaracterizacionAgronomicaModel_.FechaInsercion = a.b.FechaInsercion;
            CaracterizacionAgronomicaModel_.Gestion = a.b.Gestion;
            CaracterizacionAgronomicaModel_.IdAspNetUserModifica = a.b.IdAspNetUserModifica;

            return CaracterizacionAgronomicaModel_;
        }

        public CaracterizacionAgronomicaModel Actualizar(CaracterizacionAgronomicaModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var CaracterizacionAgronomicaModel_ = Ctx.CaracterizacionAgronomica.Where(s => s.Id == a.Id).FirstOrDefault();
                if (CaracterizacionAgronomicaModel_ != null)
                {
                    CaracterizacionAgronomicaModel_.Validacion1 = a.Validacion1;
                    CaracterizacionAgronomicaModel_.Validacion2 = a.Validacion2;
                    CaracterizacionAgronomicaModel_.Validacion3 = a.Validacion3;
                    CaracterizacionAgronomicaModel_.Validacion4 = a.Validacion4;
                    CaracterizacionAgronomicaModel_.Validacion5 = a.Validacion5;
                    CaracterizacionAgronomicaModel_.Validacion6 = a.Validacion6;
                    CaracterizacionAgronomicaModel_.Validacion7 = a.Validacion7;
                    CaracterizacionAgronomicaModel_.Validacion8 = a.Validacion8;
                    CaracterizacionAgronomicaModel_.Validacion9 = a.Validacion9;
                    CaracterizacionAgronomicaModel_.Validacion10 = a.Validacion10;
                    CaracterizacionAgronomicaModel_.Validacion11 = a.Validacion11;
                    CaracterizacionAgronomicaModel_.Validacion12 = a.Validacion12;
                    CaracterizacionAgronomicaModel_.Validacion13 = a.Validacion13;
                    CaracterizacionAgronomicaModel_.Validacion14 = a.Validacion14;
                    CaracterizacionAgronomicaModel_.Validacion15 = a.Validacion15;
                    CaracterizacionAgronomicaModel_.Validacion16 = a.Validacion16;
                    CaracterizacionAgronomicaModel_.Validacion17 = a.Validacion17;
                    CaracterizacionAgronomicaModel_.Validacion18 = a.Validacion18;
                    CaracterizacionAgronomicaModel_.Validacion19 = a.Validacion19;
                    CaracterizacionAgronomicaModel_.Validacion20 = a.Validacion20;
                    CaracterizacionAgronomicaModel_.Validacion21 = a.Validacion21;
                    CaracterizacionAgronomicaModel_.Validacion22 = a.Validacion22;
                    CaracterizacionAgronomicaModel_.Validacion23 = a.Validacion23;
                    CaracterizacionAgronomicaModel_.Validacion24 = a.Validacion24;
                    CaracterizacionAgronomicaModel_.Validacion25 = a.Validacion25;
                    CaracterizacionAgronomicaModel_.Validacion26 = a.Validacion26;
                    CaracterizacionAgronomicaModel_.Validacion27 = a.Validacion27;
                    CaracterizacionAgronomicaModel_.Validacion28 = a.Validacion28;
                    CaracterizacionAgronomicaModel_.Validacion29 = a.Validacion29;
                    CaracterizacionAgronomicaModel_.Validacion30 = a.Validacion30;
                    CaracterizacionAgronomicaModel_.Validacion31 = a.Validacion31;
                    CaracterizacionAgronomicaModel_.Validacion32 = a.Validacion32;
                    CaracterizacionAgronomicaModel_.Validacion33 = a.Validacion33;
                    CaracterizacionAgronomicaModel_.Validacion34 = a.Validacion34;
                    CaracterizacionAgronomicaModel_.Validacion35 = a.Validacion35;
                    CaracterizacionAgronomicaModel_.Validacion36 = a.Validacion36;
                    CaracterizacionAgronomicaModel_.Validacion37 = a.Validacion37;
                    CaracterizacionAgronomicaModel_.Validacion38 = a.Validacion38;
                    CaracterizacionAgronomicaModel_.Validacion39 = a.Validacion39;
                    CaracterizacionAgronomicaModel_.Validacion40 = a.Validacion40;
                    CaracterizacionAgronomicaModel_.Validacion41 = a.Validacion41;
                    CaracterizacionAgronomicaModel_.Validacion42 = a.Validacion42;
                    CaracterizacionAgronomicaModel_.Validacion43 = a.Validacion43;
                    CaracterizacionAgronomicaModel_.Validacion44 = a.Validacion44;
                    CaracterizacionAgronomicaModel_.Validacion45 = a.Validacion45;
                    CaracterizacionAgronomicaModel_.Validacion46 = a.Validacion46;
                    CaracterizacionAgronomicaModel_.Validacion47 = a.Validacion47;
                    CaracterizacionAgronomicaModel_.Validacion48 = a.Validacion48;
                    CaracterizacionAgronomicaModel_.Validacion49 = a.Validacion49;
                    CaracterizacionAgronomicaModel_.Validacion50 = a.Validacion50;
                    CaracterizacionAgronomicaModel_.Validacion51 = a.Validacion51;
                    CaracterizacionAgronomicaModel_.Validacion52 = a.Validacion52;
                    CaracterizacionAgronomicaModel_.Validacion53 = a.Validacion53;
                    CaracterizacionAgronomicaModel_.Validacion54 = a.Validacion54;
                    CaracterizacionAgronomicaModel_.Validacion55 = a.Validacion55;
                    CaracterizacionAgronomicaModel_.Validacion56 = a.Validacion56;
                    CaracterizacionAgronomicaModel_.Validacion57 = a.Validacion57;
                    CaracterizacionAgronomicaModel_.Validacion58 = a.Validacion58;
                    CaracterizacionAgronomicaModel_.Validacion59 = a.Validacion59;
                    CaracterizacionAgronomicaModel_.Validacion60 = a.Validacion60;
                    CaracterizacionAgronomicaModel_.Validacion61 = a.Validacion61;
                    CaracterizacionAgronomicaModel_.Validacion62 = a.Validacion62;
                    CaracterizacionAgronomicaModel_.Validacion63 = a.Validacion63;


                    CaracterizacionAgronomicaModel_.Id = a.Id;
                    CaracterizacionAgronomicaModel_.FechaInsercion = a.FechaInsercion;
                    CaracterizacionAgronomicaModel_.Gestion = a.Gestion;
                    CaracterizacionAgronomicaModel_.IdAspNetUserModifica = a.IdAspNetUserModifica;
                    CaracterizacionAgronomicaModel_.FechaInsercion = a.FechaInsercion;
                    CaracterizacionAgronomicaModel_.IdAspNetUser = a.IdAspNetUser;
                    CaracterizacionAgronomicaModel_.IdExpediente = a.IdExpediente;
                    CaracterizacionAgronomicaModel_.FechaModificacion = DateTime.Now;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.CaracterizacionAgronomica.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }

        public List<CaracterizacionAgronomicaCatalogosModel> ConsultarCatalogo(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.CaracterizacionAgronomicaCatalogos.Where(x => x.Tipo.Equals(id))
                .Select(a => new CaracterizacionAgronomicaCatalogosModel
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