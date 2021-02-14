using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class Ba_MemorandoLogic
    {
        Ba_Memorando ModCtx = new Ba_Memorando();


        public Ba_MemorandoModel Crear(Ba_MemorandoModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                Ba_Memorando Nuevo = new Ba_Memorando
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

                Ctx.Ba_Memorando.Add(Nuevo);
                Ctx.SaveChanges();

                //var ConsultaVurSolicitante = a.Validacion27.Split('|');

                //foreach (var DataSolicitante in ConsultaVurSolicitante ) {

                //    var DataSolicitante_ = DataSolicitante;
                //    var itemSolicitante = DataSolicitante.Split('_');

                //    if (itemSolicitante.Length == 4 ) {

                //        Ba_MemorandoConsultaVur ConsultaSolicitanteVur = new Ba_MemorandoConsultaVur
                //        {
                //            Departamento = itemSolicitante[0],
                //            Municipio = itemSolicitante[1],
                //            Numero = itemSolicitante[2],
                //            Area = itemSolicitante[3],
                //            Tipo = "Solicitante",
                //            idCaracterizacion = Convert.ToInt32(Nuevo.Id),
                //            Estado = true
                //        };

                //        Ctx.Ba_MemorandoConsultaVur.Add(ConsultaSolicitanteVur);
                //        Ctx.SaveChanges();

                //    } 

                //}

                //var ConsultaVurConyuge = a.Validacion32.Split('|');

                //foreach (var DataConyuge in ConsultaVurConyuge)
                //{

                //    var itemConyuge = DataConyuge.Split('_');

                //    if (itemConyuge.Length == 4)
                //    {

                //        Ba_MemorandoConsultaVur ConsultaSolicitanteVur = new Ba_MemorandoConsultaVur
                //        {
                //            Departamento = itemConyuge[0],
                //            Municipio = itemConyuge[1],
                //            Numero = itemConyuge[2],
                //            Area = itemConyuge[3],
                //            Tipo = "itemConyuge",
                //            idCaracterizacion = Convert.ToInt32(Nuevo.Id),
                //            Estado = true
                //        };

                //        Ctx.Ba_MemorandoConsultaVur.Add(ConsultaSolicitanteVur);
                //        Ctx.SaveChanges();

                //    }

                //}


                return a;
            }
        }

        public List<Ba_MemorandoModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var listaBaldios = Ctx.Ba_Memorando
                 .Where(w => w.Estado == 1).ToList();
            #region Sql
            var lista = listaBaldios
                .Select(c => new Ba_MemorandoModel
                {

                    Validacion1 = c.Validacion1,
                    Validacion2 = c.Validacion2,
                    Validacion3 = c.Validacion3,
                    //Validacion4 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion4).Select(y => y.Nombre).FirstOrDefault(),
                    //Validacion5 = c.Validacion5,
                    //Validacion6 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion6).Select(y => y.Nombre).FirstOrDefault(),
                    // c.Validacion6,
                    Validacion7 = c.Validacion7,
                    Validacion8 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion8).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion9 = c.Validacion9,
                    Validacion10 = c.Validacion10,
                    Validacion11 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion11).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion12 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion12).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion13 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion13).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion14 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion14).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion15 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion15).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion16 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion16).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion17 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion17).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion18 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion18).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion19 = c.Validacion19,
                    Validacion20 = c.Validacion20,
                    Validacion21 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion21).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion22 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion22).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion23 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion23).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion24 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion24).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion25 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion25).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion26 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion26).Select(y => y.Nombre).FirstOrDefault(),
                    Validacion27 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion27).Select(y => y.Nombre).FirstOrDefault(),

                    Validacion28 = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO.ToString() == c.Validacion4).Select(y => y.NOMBRE).FirstOrDefault(),
                    Validacion29 = Ctx.CtCiudad.Where(x => x.IdCtMuncipio.ToString() == c.Validacion5 && x.IdCtDepto.ToString() == c.Validacion4).Select(y => y.Nombre).FirstOrDefault(),

                    Validacion30 = Ctx.Ba_MemorandoCatalogos.Where(x => x.Id.ToString() == c.Validacion4).Select(y => y.Nombre).FirstOrDefault(),

                    Id = c.Id,
                    FechaInsercion = c.FechaInsercion,
                    FechaModificacion = c.FechaModificacion.Value,
                    Gestion = c.Gestion,
                    IdAspNetUser = Ctx.Users.Where(x => x.Id_Hash == c.IdAspNetUser).Select(y =>   y.Name + " " + y.FirstName + " " + y.LastName ).FirstOrDefault(),
                    IdAspNetUserModifica = Ctx.Users.Where(x => x.Id_Hash == c.IdAspNetUserModifica).Select(y => y.Name + " " + y.FirstName + " " + y.LastName).FirstOrDefault(),
                    IdExpediente = c.IdExpediente,
                    Estado = c.Estado,


                }).OrderByDescending(d => d.FechaInsercion).ToList();
            #endregion
            return lista;
        }

        public List<Ba_MemorandoModel> Consulta(string id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            // var tipo_ = Ctx.ResumenBa_Memorando(id).Select(c => c).ToList(); ; //NombrePredio
            var listaBaldios = Ctx.Ba_Memorando
                 .Where(w => w.IdAspNetUser == id && w.Estado == 1).ToList();
            #region Sql
            var lista = listaBaldios

                .Select(c => new Ba_MemorandoModel
                {

                    Validacion1 = c.Validacion1,
                    Validacion2 = c.Validacion2,
                    Validacion3 = c.Validacion3,
                    Validacion4 = c.Validacion4,
                    Validacion5 = c.Validacion5,
                    Validacion6 = c.Validacion6,
                    Validacion7 = c.Validacion7,
                    Validacion8 = c.Validacion8,
                    Validacion9 = c.Validacion9,
                    Validacion10 = c.Validacion10,
                    Validacion11 = c.Validacion11,
                    Validacion12 = c.Validacion12,
                    Validacion13 = c.Validacion13,
                    Validacion14 = c.Validacion14,
                    Validacion15 = c.Validacion15,
                    Validacion16 = c.Validacion16,
                    Validacion17 = c.Validacion17,
                    Validacion18 = c.Validacion18,
                    Validacion19 = c.Validacion19,
                    Validacion20 = c.Validacion20,
                    Validacion21 = c.Validacion21,
                    Validacion22 = c.Validacion22,
                    Validacion23 = c.Validacion23,
                    Validacion24 = c.Validacion24,
                    Validacion25 = c.Validacion25,
                    Validacion26 = c.Validacion26,
                    Validacion27 = c.Validacion27,

                    Validacion28 = Ctx.CtDepto.Where(x => x.ID_CT_DEPTO.ToString() == c.Validacion4).Select(y => y.NOMBRE).FirstOrDefault(),
                    Validacion29 = Ctx.CtCiudad.Where(x => x.IdCtMuncipio.ToString() == c.Validacion5 && x.IdCtDepto.ToString() == c.Validacion4).Select(y => y.Nombre).FirstOrDefault(),


                    Id = c.Id,
                    FechaInsercion = c.FechaInsercion,
                    FechaModificacion = c.FechaModificacion.Value,
                    Gestion = c.Gestion,
                    IdAspNetUser = c.IdAspNetUser,
                    IdAspNetUserModifica = c.IdAspNetUserModifica,
                    IdExpediente = c.IdExpediente,
                    Estado = c.Estado,

                    
                }).OrderByDescending(d => d.FechaInsercion).ToList();

            #endregion
            return lista;
        }

        public Ba_MemorandoModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();

            var a = Ctx.Ba_Memorando.Where(x => x.Id == id)
                .Join(Ctx.Users, b => b.IdAspNetUser, c => c.Id_Hash, (b, c) => new { b, c })
                .Join(Ctx.AspNetUserRoles, b => b.c.Id_Hash, c => c.UserId, (b, c) => new { c.RoleId, b.b, b.c })
                .Join(Ctx.AspNetRoles, b => b.RoleId, c => c.Id, (b, c) => new { b.b, b.c, c.Name })
                .FirstOrDefault();

            Ba_MemorandoModel Ba_MemorandoModel_ = new Ba_MemorandoModel();


           
            Ba_MemorandoModel_.Validacion1 = a.b.Validacion1;
            Ba_MemorandoModel_.Validacion2 = a.b.Validacion2;
            Ba_MemorandoModel_.Validacion3 = a.b.Validacion3;
            Ba_MemorandoModel_.Validacion4 = a.b.Validacion4;
            Ba_MemorandoModel_.Validacion5 = a.b.Validacion5;
            Ba_MemorandoModel_.Validacion6 = a.b.Validacion6;
            Ba_MemorandoModel_.Validacion7 = a.b.Validacion7;
            Ba_MemorandoModel_.Validacion8 = a.b.Validacion8;
            Ba_MemorandoModel_.Validacion9 = a.b.Validacion9;
            Ba_MemorandoModel_.Validacion10 = a.b.Validacion10;
            Ba_MemorandoModel_.Validacion11 = a.b.Validacion11;
            Ba_MemorandoModel_.Validacion12 = a.b.Validacion12;
            Ba_MemorandoModel_.Validacion13 = a.b.Validacion13;
            Ba_MemorandoModel_.Validacion14 = a.b.Validacion14;
            Ba_MemorandoModel_.Validacion15 = a.b.Validacion15;
            Ba_MemorandoModel_.Validacion16 = a.b.Validacion16;
            Ba_MemorandoModel_.Validacion17 = a.b.Validacion17;
            Ba_MemorandoModel_.Validacion18 = a.b.Validacion18;
            Ba_MemorandoModel_.Validacion19 = a.b.Validacion19;
            Ba_MemorandoModel_.Validacion20 = a.b.Validacion20;
            Ba_MemorandoModel_.Validacion21 = a.b.Validacion21;
            Ba_MemorandoModel_.Validacion22 = a.b.Validacion22;
            Ba_MemorandoModel_.Validacion23 = a.b.Validacion23;
            Ba_MemorandoModel_.Validacion24 = a.b.Validacion24;
            Ba_MemorandoModel_.Validacion25 = a.b.Validacion25;
            Ba_MemorandoModel_.Validacion26 = a.b.Validacion26;
            Ba_MemorandoModel_.Validacion27 = a.b.Validacion27;
            Ba_MemorandoModel_.Validacion28 = a.b.Validacion28;
            Ba_MemorandoModel_.Validacion29 = a.b.Validacion29;
            Ba_MemorandoModel_.Validacion30 = a.b.Validacion30;
            Ba_MemorandoModel_.Validacion31 = a.b.Validacion31;
            Ba_MemorandoModel_.Validacion32 = a.b.Validacion32;
            Ba_MemorandoModel_.Validacion33 = a.b.Validacion33;
            Ba_MemorandoModel_.Validacion34 = a.b.Validacion34;
            Ba_MemorandoModel_.Validacion35 = a.b.Validacion35;
            Ba_MemorandoModel_.Validacion36 = a.b.Validacion36;
            Ba_MemorandoModel_.Validacion37 = a.b.Validacion37;
            Ba_MemorandoModel_.Validacion38 = a.b.Validacion38;
            Ba_MemorandoModel_.Validacion39 = a.b.Validacion39;
            Ba_MemorandoModel_.Validacion40 = a.b.Validacion40;
            Ba_MemorandoModel_.Validacion41 = a.b.Validacion41;
            Ba_MemorandoModel_.Validacion42 = a.b.Validacion42;
            Ba_MemorandoModel_.Validacion43 = a.b.Validacion43;
            Ba_MemorandoModel_.Validacion44 = a.b.Validacion44;
            Ba_MemorandoModel_.Validacion45 = a.b.Validacion45;
            Ba_MemorandoModel_.Validacion46 = a.b.Validacion46;
            Ba_MemorandoModel_.Validacion47 = a.b.Validacion47;
            Ba_MemorandoModel_.Validacion48 = a.b.Validacion48;
            Ba_MemorandoModel_.Validacion49 = a.b.Validacion49;
            Ba_MemorandoModel_.Validacion50 = a.b.Validacion50;
            Ba_MemorandoModel_.Validacion51 = a.b.Validacion51;
            Ba_MemorandoModel_.Validacion52 = a.b.Validacion52;
            Ba_MemorandoModel_.Validacion53 = a.b.Validacion53;
            Ba_MemorandoModel_.Validacion54 = a.b.Validacion54;
            Ba_MemorandoModel_.Validacion55 = a.b.Validacion55;
            Ba_MemorandoModel_.Validacion56 = a.b.Validacion56;
            Ba_MemorandoModel_.Validacion57 = a.b.Validacion57;
            Ba_MemorandoModel_.Validacion58 = a.b.Validacion58;
            Ba_MemorandoModel_.Validacion59 = a.b.Validacion59;
            Ba_MemorandoModel_.Validacion60 = a.b.Validacion60;
            Ba_MemorandoModel_.Validacion61 = a.b.Validacion61;
            Ba_MemorandoModel_.Validacion62 = a.b.Validacion62;
            Ba_MemorandoModel_.Validacion63 = a.b.Validacion63;


            Ba_MemorandoModel_.Estado = 1;
            Ba_MemorandoModel_.IdAspNetUser = a.b.IdAspNetUser;
            Ba_MemorandoModel_.rol = a.Name;
            Ba_MemorandoModel_.NombreIdAspNetUser = a.c.Name + " " + a.c.FirstName + " " + a.c.LastName;
            Ba_MemorandoModel_.FechaModificacion = a.b.FechaModificacion.Value;

            Ba_MemorandoModel_.Id = a.b.Id;
            Ba_MemorandoModel_.FechaInsercion = a.b.FechaInsercion;
            Ba_MemorandoModel_.Gestion = a.b.Gestion;
            Ba_MemorandoModel_.IdAspNetUserModifica = a.b.IdAspNetUserModifica;

            return Ba_MemorandoModel_;
        }

        public Ba_MemorandoModel Actualizar(Ba_MemorandoModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var Ba_MemorandoModel_ = Ctx.Ba_Memorando.Where(s => s.Id == a.Id).FirstOrDefault();
                if (Ba_MemorandoModel_ != null)
                {
                    Ba_MemorandoModel_.Validacion1 = a.Validacion1;
                    Ba_MemorandoModel_.Validacion2 = a.Validacion2;
                    Ba_MemorandoModel_.Validacion3 = a.Validacion3;
                    Ba_MemorandoModel_.Validacion4 = a.Validacion4;
                    Ba_MemorandoModel_.Validacion5 = a.Validacion5;
                    Ba_MemorandoModel_.Validacion6 = a.Validacion6;
                    Ba_MemorandoModel_.Validacion7 = a.Validacion7;
                    Ba_MemorandoModel_.Validacion8 = a.Validacion8;
                    Ba_MemorandoModel_.Validacion9 = a.Validacion9;
                    Ba_MemorandoModel_.Validacion10 = a.Validacion10;
                    Ba_MemorandoModel_.Validacion11 = a.Validacion11;
                    Ba_MemorandoModel_.Validacion12 = a.Validacion12;
                    Ba_MemorandoModel_.Validacion13 = a.Validacion13;
                    Ba_MemorandoModel_.Validacion14 = a.Validacion14;
                    Ba_MemorandoModel_.Validacion15 = a.Validacion15;
                    Ba_MemorandoModel_.Validacion16 = a.Validacion16;
                    Ba_MemorandoModel_.Validacion17 = a.Validacion17;
                    Ba_MemorandoModel_.Validacion18 = a.Validacion18;
                    Ba_MemorandoModel_.Validacion19 = a.Validacion19;
                    Ba_MemorandoModel_.Validacion20 = a.Validacion20;
                    Ba_MemorandoModel_.Validacion21 = a.Validacion21;
                    Ba_MemorandoModel_.Validacion22 = a.Validacion22;
                    Ba_MemorandoModel_.Validacion23 = a.Validacion23;
                    Ba_MemorandoModel_.Validacion24 = a.Validacion24;
                    Ba_MemorandoModel_.Validacion25 = a.Validacion25;
                    Ba_MemorandoModel_.Validacion26 = a.Validacion26;
                    Ba_MemorandoModel_.Validacion27 = a.Validacion27;
                    Ba_MemorandoModel_.Validacion28 = a.Validacion28;
                    Ba_MemorandoModel_.Validacion29 = a.Validacion29;
                    Ba_MemorandoModel_.Validacion30 = a.Validacion30;
                    Ba_MemorandoModel_.Validacion31 = a.Validacion31;
                    Ba_MemorandoModel_.Validacion32 = a.Validacion32;
                    Ba_MemorandoModel_.Validacion33 = a.Validacion33;
                    Ba_MemorandoModel_.Validacion34 = a.Validacion34;
                    Ba_MemorandoModel_.Validacion35 = a.Validacion35;
                    Ba_MemorandoModel_.Validacion36 = a.Validacion36;
                    Ba_MemorandoModel_.Validacion37 = a.Validacion37;
                    Ba_MemorandoModel_.Validacion38 = a.Validacion38;
                    Ba_MemorandoModel_.Validacion39 = a.Validacion39;
                    Ba_MemorandoModel_.Validacion40 = a.Validacion40;
                    Ba_MemorandoModel_.Validacion41 = a.Validacion41;
                    Ba_MemorandoModel_.Validacion42 = a.Validacion42;
                    Ba_MemorandoModel_.Validacion43 = a.Validacion43;
                    Ba_MemorandoModel_.Validacion44 = a.Validacion44;
                    Ba_MemorandoModel_.Validacion45 = a.Validacion45;
                    Ba_MemorandoModel_.Validacion46 = a.Validacion46;
                    Ba_MemorandoModel_.Validacion47 = a.Validacion47;
                    Ba_MemorandoModel_.Validacion48 = a.Validacion48;
                    Ba_MemorandoModel_.Validacion49 = a.Validacion49;
                    Ba_MemorandoModel_.Validacion50 = a.Validacion50;
                    Ba_MemorandoModel_.Validacion51 = a.Validacion51;
                    Ba_MemorandoModel_.Validacion52 = a.Validacion52;
                    Ba_MemorandoModel_.Validacion53 = a.Validacion53;
                    Ba_MemorandoModel_.Validacion54 = a.Validacion54;
                    Ba_MemorandoModel_.Validacion55 = a.Validacion55;
                    Ba_MemorandoModel_.Validacion56 = a.Validacion56;
                    Ba_MemorandoModel_.Validacion57 = a.Validacion57;
                    Ba_MemorandoModel_.Validacion58 = a.Validacion58;
                    Ba_MemorandoModel_.Validacion59 = a.Validacion59;
                    Ba_MemorandoModel_.Validacion60 = a.Validacion60;
                    Ba_MemorandoModel_.Validacion61 = a.Validacion61;
                    Ba_MemorandoModel_.Validacion62 = a.Validacion62;
                    Ba_MemorandoModel_.Validacion63 = a.Validacion63;


                    Ba_MemorandoModel_.Id = a.Id;
                    Ba_MemorandoModel_.FechaInsercion = a.FechaInsercion;
                    Ba_MemorandoModel_.Gestion = a.Gestion;
                    Ba_MemorandoModel_.IdAspNetUserModifica = a.IdAspNetUserModifica;
                    Ba_MemorandoModel_.FechaInsercion = a.FechaInsercion;
                    Ba_MemorandoModel_.IdAspNetUser = a.IdAspNetUser;
                    Ba_MemorandoModel_.IdExpediente = a.IdExpediente;
                    Ba_MemorandoModel_.FechaModificacion = DateTime.Now;

                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var ResCtx = Ctx.Ba_Memorando.Where(s => s.Id == id).FirstOrDefault();
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