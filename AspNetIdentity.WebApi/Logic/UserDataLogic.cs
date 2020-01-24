using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class UserDataLogic
    {
        Users ModCtx = new Users();
        //public UserDataModel Crear(UserDataModel a)
        //{
        //    using (ZonasFEntities Ctx = new ZonasFEntities())
        //    {
        //        Users Nuevo = new Users
        //        {
        //            ID_CT_CARGO = a.ID_CT_CARGO,
        //            NOMBRE = a.NOMBRE,
        //            DESCRIPCION = a.DESCRIPCION,
        //        };
        //        Nuevo.ESTADO = 1;
        //        Ctx.Users.Add(Nuevo);
        //        Ctx.SaveChanges();
        //        return a;
        //    }
        //}

        //public List<UserDataModel> Consulta()
        //{
        //    ZonasFEntities Ctx = new ZonasFEntities();
        //     UserDataModel b = new UserDataModel();
        //    var lista = Ctx.Users.Where(x => x.ESTADO == 1 ).Select(a => new UserDataModel
        //    {
        //        ID_CT_CARGO = a.ID_CT_CARGO,
        //        NOMBRE = a.NOMBRE,
        //        DESCRIPCION = a.DESCRIPCION,
        //    });

        //    return lista.ToList();
        //}

        public UserDataModel ConsultarId(string id)
        {
            int idU = Convert.ToInt32(id);
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Users
                 .Join(Ctx.AspNetUsers, b => b.Id_Hash, c => c.Id, (b, c) =>
                 new { b.Id_Hash, b.Name, b.FirstName, b.LastName, b.Email, b.ImageName, b.Id_User,c.UserName,c.PasswordHash })
                 .Where(b => b.Id_User == idU)
                .Select(a => new UserDataModel
                {
                    Id = a.Id_User,
                    Name = a.Name,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Image = a.ImageName,
                    NombreUsuario = a.UserName,
                    PasswordHash = a.PasswordHash,
                    PasswordHashConfir = a.PasswordHash,

                });
            return lista.FirstOrDefault();
        }
        public UserDataModel ConsultarIdHash(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Users
                 .Join(Ctx.AspNetUsers, b => b.Id_Hash, c => c.Id, (b, c) =>
                 new { b.Id_Hash, b.Name, b.FirstName, b.LastName, b.Email, b.ImageName, b.Id_User })
                 .Where(b => b.Id_Hash.Equals(id))
                .Select(a => new UserDataModel
                {
                    Id = a.Id_User,
                    Name = a.Name,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Image = a.ImageName
                });
            return lista.FirstOrDefault();
        }



        //public Int32 ConsultarProgreso(Int32 id)
        //{
        //    ZonasFEntities Ctx = new ZonasFEntities();

        //    int idA = Ctx.HV_ACTITUDES
        //                .Where(b => b.ID_DATOS_BASICOS.Equals(id))
        //                .Select(b => b.ID_ACTITUDES).FirstOrDefault();

        //    int idC = Ctx.HV_CONOCIMIENTOS
        //                .Where(b => b.ID_DATOS_BASICOS.Equals(id))
        //                .Select(b => b.ID_CONOCIMIENTOS).FirstOrDefault();

        //    int idE = Ctx.HV_ESTUDIOS
        //               .Where(b => b.ID_DATOS_BASICOS.Equals(id))
        //               .Select(b => b.ID_ESTUDIOS).FirstOrDefault();

        //    int idEx = Ctx.HV_EXPERIENCIA
        //               .Where(b => b.ID_DATOS_BASICOS.Equals(id))
        //               .Select(b => b.ID_EXPERIENCIA).FirstOrDefault();

        //    int idU = Ctx.HV_UBICACION
        //               .Where(b => b.ID_DATOS_BASICOS.Equals(id))
        //               .Select(b => b.ID_HV_HUBICACION).FirstOrDefault();

        //    int Conte = 0;
        //    if (idA > 0)
        //    { Conte++; }
        //    if (idC > 0)
        //    { Conte++; }
        //    if (idE > 0)
        //    { Conte++; }
        //    if (idEx > 0)
        //    { Conte++; }
        //    if (idU > 0)
        //    { Conte++; }
                      
        //    return Conte;
        //}

        //public Int32 ConsultarProgresoIndex(Int32 id)
        //{
        //    ZonasFEntities Ctx = new ZonasFEntities();

        //    Int32 IdDB = 0;
        //    Int32 idA = 0;
        //    Int32 idC = 0;
        //    Int32 idE = 0;
        //    Int32 idEx = 0;
        //    Int32 idU = 0;
        //    Int32 idUsers = 0;

        //    idUsers = Ctx.Users
        //            .Where(b => b.Id_User.Equals(id))
        //            .Select(b => b.Id_User).FirstOrDefault();

        //    IdDB = Ctx.HV_DATOS_BASICOS
        //           .Where(b => b.ID_USERS.Value.Equals(id))
        //           .Select(b => b.ID_DATOS_BASICOS).FirstOrDefault();

        //    idA = Ctx.HV_ACTITUDES
        //            .Where(b => b.ID_DATOS_BASICOS.Equals(IdDB))
        //            .Select(b => b.ID_ACTITUDES).FirstOrDefault();

        //    idC = Ctx.HV_CONOCIMIENTOS
        //            .Where(b => b.ID_DATOS_BASICOS.Equals(IdDB))
        //            .Select(b => b.ID_CONOCIMIENTOS).FirstOrDefault();

        //    idE = Ctx.HV_ESTUDIOS
        //            .Where(b => b.ID_DATOS_BASICOS.Equals(IdDB))
        //            .Select(b => b.ID_ESTUDIOS).FirstOrDefault();

        //    idEx = Ctx.HV_EXPERIENCIA
        //            .Where(b => b.ID_DATOS_BASICOS.Equals(IdDB))
        //            .Select(b => b.ID_EXPERIENCIA).FirstOrDefault();

        //    idU = Ctx.HV_UBICACION
        //            .Where(b => b.ID_DATOS_BASICOS.Equals(IdDB))
        //            .Select(b => b.ID_HV_HUBICACION).FirstOrDefault();

        //    int TablasLLenas = 0;

        //    if (idUsers > 0)
        //    { TablasLLenas++; }
        //    if (IdDB > 0)
        //    { TablasLLenas++; }
        //    if (idA > 0)
        //    { TablasLLenas++; }
        //    if (idC > 0)
        //    { TablasLLenas++; }
        //    if (idE > 0)
        //    { TablasLLenas++; }
        //    if (idEx > 0)
        //    { TablasLLenas++; }
        //    if (idU > 0)
        //    { TablasLLenas++; }

        //    var b10 = 7;
        //    var c10 = 100;
        //    var b11 = TablasLLenas;
        //    var respuesta = c10 * b11 / b10;

        //    return respuesta;
        //}

        //public UserDataModel Actualizar(UserDataModel a)
        //{
        //    using (var Ctx = new ZonasFEntities())
        //    {
        //        var ResCtx = Ctx.Users.Where(s => s.ID_CT_CARGO == a.ID_CT_CARGO).FirstOrDefault();
        //        if (ResCtx != null)
        //        {
        //            ResCtx.ID_CT_CARGO = a.ID_CT_CARGO;
        //            ResCtx.NOMBRE = a.NOMBRE;
        //            ResCtx.DESCRIPCION = a.DESCRIPCION;
        //            Ctx.SaveChanges();
        //        }
        //    }
        //    return a;
        //}

        //public String Eliminar(int id)
        //{
        //    using (var Ctx = new ZonasFEntities())
        //    {
        //        var ResCtx = Ctx.Users.Where(s => s.ID_CT_CARGO == id).FirstOrDefault();
        //        if (ResCtx != null)
        //        {
        //            if (ResCtx != null)
        //                ResCtx.ESTADO = 0;
        //            Ctx.SaveChanges();
        //        }
        //    }
        //    return "Realizado";
        //}
    }
}